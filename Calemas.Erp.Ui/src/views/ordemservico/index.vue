<template>
    <div class="wrapper">

        <div class="row" style="margin-bottom: 1rem;margin-top: -0.5rem;">
            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                <h6 class="page-title txt-color-blueDark">
                    <i class="fa-fw fa fa-home"></i>
                    Cadastros
                    <span>Manutenção de Ordem de serviço</span>
                </h6>
            </div>
            <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4 text-right">
                <div class="btn-group">
                    <a href="javascript:history.back()" class="btn btn-secondary btn-sm pull-right header-btn hidden-mobile">
                        <i class="fa fa-reply"></i> Voltar
                    </a>
                    <button @click="openFilter()" class="btn btn-primary btn-sm pull-right header-btn">
                        <i class="fa fa-filter"></i> Filtros
                    </button>
                    <button @click="openCreate(modelnew)" class="btn btn-success btn-sm pull-right header-btn hidden-mobile">
                        <i class="fa fa-plus"></i> Cadastrar
                    </button>
                </div>
            </div>
        </div>

        <div class="row animated fadeIn" v-if="filterPartialIsOpen">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Filtros</strong>
                    </div>
                    <div class="card-block">
                        <form v-on:keypress.enter.prevent="executeFilter()">
                            <filter-partial :filter="filter" />
                        </form>
                    </div>
                    <div class="card-footer text-right">
                        <button type="submit" class="btn btn-primary" @click="executeFilter()">
                            <i class="fa fa-search"></i> Filtrar
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Resultado</strong>
                    </div>
                    <div class="card-block no-padding">
                        <table class="table table-striped table-sm">
                            <thead class="">
                                <tr>
                                    <th>Protocolo <button @click="executeOrderBy('protoco')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Cliente <button @click="executeOrderBy('cliente.pessoa.nome')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Condomínio <button @click="executeOrderBy('cliente.condominio.sigla')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Tipo da O.S <button @click="executeOrderBy('tipoOrdemServico.nome')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Data para Realização <button @click="executeOrderBy('agenda.dataInicio')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Situação <button @click="executeOrderBy('statusOrdemServico.nome')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th class="text-center" width="150"><i class="fa fa-cog"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in result.itens" class="animated fadeIn">
                                    <td>{{ item.protoco }}</td>
                                    <td>{{ item.cliente.pessoa.nome }}</td>
                                    <td>{{ item.cliente.condominio.sigla }}</td>
                                    <td>{{ item.tipoOrdemServico.nome }}</td>
                                    <td>{{ item.agenda.dataInicio | date }}</td>
                                    <td>{{ item.statusOrdemServico.nome }}</td>
                                    <td class="text-center">
                                        <button type="button" class="btn btn-sm btn-success" v-if="item.houveInteracao" v-tooltip.left="'Detalhes'" @click="openDetail(undefined, { ordemServicoId: item.ordemServicoId })">
                                            <i class="fa fa-search"></i>
                                        </button>
                                        <button type="button" class="btn btn-sm btn-warning" v-if="item.statusOrdemServico.ativo" v-tooltip.left="'Interagir'" @click="openInteracao(item.ordemServicoId, item)">
                                            <i class="fa fa-check-square-o"></i>
                                        </button>
                                        <button type="button" class="btn btn-sm btn-primary" v-if="item.statusOrdemServico.ativo  && !item.houveInteracao" v-tooltip.left="'Editar'" @click="openEdit(item.ordemServicoId, item)">
                                            <i class="fa fa-pencil"></i>
                                        </button>
                                        <button type="button" class="btn btn-sm btn-danger" v-if="item.statusOrdemServico.ativo && !item.houveInteracao" v-tooltip.left="'Remover'" @click="openDelete(item.ordemServicoId, item)">
                                            <i class="fa fa-trash-o"></i>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="card-block no-padding">
                        <pagination :total="result.total" :page-size="filter.pageSize" :callback="executePageChanged"></pagination>
                    </div>
                </div>
            </div>
        </div>

        <modal title="Cadastro de Ordem de serviço" v-model="modalCreateIsOpen" effect="fade/zoom" type="modal-success" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Cadastro de Ordem de serviço</h4>
                <button type="button" class="close" @click="closeCreate()"><span>&times;</span></button>
            </div>
            <form v-on:keypress.enter.prevent="executeCreate(model)" id="form-create" novalidate>
                <form-partial :model="model" />
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeCreate()">Fechar</button>
                <button type="button" class="btn btn-success" @click="executeCreate(model)">
                    <i class="fa fa-check"></i> Salvar
                </button>
            </div>
        </modal>

        <modal title="Edição de Ordem de serviço" v-model="modalEditIsOpen" effect="fade/zoom" type="modal-primary" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Edição de Ordem de serviço</h4>
                <button type="button" class="close" @click="closeEdit()"><span>&times;</span></button>
            </div>
            <form v-on:keypress.enter.prevent="executeEdit(model)" id="form-edit" novalidate>
                <form-partial :model="model" />
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeEdit()">Fechar</button>
                <button type="button" class="btn btn-primary" @click="executeEdit(model)">
                    <i class="fa fa-pencil"></i> Alterar
                </button>
            </div>
        </modal>

        <modal title="Exclusão de Ordem de serviço" v-model="modalDeleteIsOpen" type="modal-danger" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Exclusão de Ordem de serviço</h4>
                <button type="button" class="close" @click="closeDelete()"><span>&times;</span></button>
            </div>
            <form type="post" v-on:keypress.enter.prevent="executeDelete(model)" id="form-delete" novalidate>
                <div class="row">
                    <div class="form-group col-md-12">
                        <h4>Confirma a remoção deste item?</h4>
                    </div>
                </div>
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-danger btn-block" @click="executeDelete(model)">
                    <i class="fa fa-trash-o"></i> Remover
                </button>
            </div>
        </modal>

        <modal title="Interação de Ordem de serviço" v-model="modalInteracaoIsOpen" effect="fade/zoom" type="modal-warning" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Interação de Ordem de serviço</h4>
                <button type="button" class="close" @click="closeInteracao()"><span>&times;</span></button>
            </div>
            <form v-on:keypress.enter.prevent="executeInteracao(interacao)" id="form-interacao">
                <interacao-partial :model="interacao" />
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeInteracao()">Fechar</button>
                <button type="button" class="btn btn-warning" @click="executeInteracao(interacao)">
                    <i class="fa fa-check"></i> Registrar
                </button>
            </div>
        </modal>

        <modal title="Registros da ordem de serviço" v-model="modalDetailIsOpen" effect="fade/zoom" type="modal-success" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Registros da ordem de serviço</h4>
                <button type="button" class="close" @click="closeDetail()"><span>&times;</span></button>
            </div>
            <detail-partial :detail="detail" />
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeDetail()">Fechar</button>
            </div>
        </modal>

    </div>
</template>
<script>

    import { Api } from '../../common/api'

    import Vue from 'vue'
    const _moment = require('moment')
    require('moment/locale/pt')
    Vue.use(require('vue-moment'), { _moment });

    import crudBase from '../../common/mixins/crud'

    import formPartial from './form.partial'
    import filterPartial from './filter.partial'
    import interacaoPartial from './interacao.partial'
    import detailPartial from './detail.partial'

    export default {
        name: "ordemservico",
        components: { formPartial, filterPartial, interacaoPartial, detailPartial },
        mixins: [crudBase],
        data() {
            return {
                resource: "ordemservico",

                modelnew: {
                    dataOcorrencia: _moment().format('YYYY-MM-DDTHH:mm'),
                    agenda: {},
                    responsavelIds: []
                },

                model: { agenda: {}, responsavelIds: [] },
                resources: {
                    detail: "ordemservicointeracao"
                },

                interacao: { ordemServico: {} },
                modalInteracaoIsOpen: false,
                apiInteracao: new Api("ordemservicointeracao")
            }
        },
        methods: {

            openInteracao: function (id, item) {

                this.interacao = {
                    dataConclusao: _moment().format('YYYY-MM-DDTHH:mm'),
                    ordemServicoId: id,
                    ordemServico: {}
                }

                this.modalInteracaoIsOpen = true;
            },
            closeInteracao: function () {
                this.modalInteracaoIsOpen = false;
            },
            executeInteracao: function (model) {

                if (this.formValid(this.formCustom("form-interacao")) == false)
                    return;

                this.defaultBeforeAction();
                this.apiInteracao.post(model).then(data => {
                    this.notification.success("Sucesso", "Registrado.")
                    this.defaultSuccessResult(data);
                    this.executeFilter();
                    this.modalInteracaoIsOpen = false;
                }, err => { this.defaultErrorResult(err); })
            },
        }

    }
</script>