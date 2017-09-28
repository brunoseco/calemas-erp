<template>
    <div class="wrapper">

        <div class="row" style="margin-bottom: 1rem;margin-top: -0.5rem;">
            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                <h6 class="page-title txt-color-blueDark">
                    <i class="fa-fw fa fa-home"></i>
                    Cadastros
                    <span>Manutenção de Condomínio</span>
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
                    <button @click="openCreate({endereco: {}})" class="btn btn-success btn-sm pull-right header-btn hidden-mobile">
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
                        <form v-on:submit.prevent="executeFilter()">
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
                        <table class="table has-tickbox table-striped table-sm">
                            <thead class="">
                                <tr>
                                    <th>#</th>
                                    <th>Sigla<button @click="executeOrderBy('sigla')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Nome<button @click="executeOrderBy('nome')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Endereço<button @click="executeOrderBy('endereco.rua')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>
                                    <th>Ativo<button @click="executeOrderBy('ativo')" class="btn btn-sm btn-link no-border pull-right hide"><i class="fa fa-sort"></i></button></th>

                                    <th class="text-center" width="75"><i class="fa fa-cog"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in result.itens" class="animated fadeIn">
                                    <td>{{ item.condominioId }}</td>
                                    <td>{{ item.sigla }}</td>
                                    <td>{{ item.nome }}</td>
                                    <td>{{ item.endereco.rua }} - {{ item.endereco.bairro }}</td>
                                    <td><span class="badge badge-pill" v-bind:class="{ 'badge-success': item.ativo, 'badge-danger': !item.ativo }">{{item.ativo ? 'Sim' : 'Não'}}</span></td>

                                    <td class="text-center">
                                        <button type="button" class="btn btn-sm btn-primary" v-tooltip.left="'Editar'" @click="openEdit(item.condominioId, item)">
                                            <i class="fa fa-pencil"></i>
                                        </button>
                                        <button type="button" class="btn btn-sm btn-danger" v-tooltip.left="'Remover'" @click="openDelete(item.condominioId, item)">
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

        <modal title="Cadastro de Estoque" v-model="modalCreateIsOpen" effect="fade/zoom" type="modal-success" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Cadastro de Condomínio</h4>
                <button type="button" class="close" @click="closeCreate()"><span>&times;</span></button>
            </div>
            <form v-on:submit.prevent="executeCreate(model)" id="form-create" novalidate>
                <form-partial :model="model" />
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeCreate()">Fechar</button>
                <button type="button" class="btn btn-success" @click="executeCreate(model)">
                    <i class="fa fa-check"></i> Salvar
                </button>
            </div>
        </modal>

        <modal title="Edição de Estoque" v-model="modalEditIsOpen" effect="fade/zoom" type="modal-primary" :large="true">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Edição de Condomínio</h4>
                <button type="button" class="close" @click="closeEdit()"><span>&times;</span></button>
            </div>
            <form v-on:submit.prevent="executeEdit(model)" id="form-edit" novalidate>
                <form-partial :model="model" />
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="closeEdit()">Fechar</button>
                <button type="button" class="btn btn-primary" @click="executeEdit(model)">
                    <i class="fa fa-pencil"></i> Alterar
                </button>
            </div>
        </modal>

        <modal title="Exclusão de Estoque" v-model="modalDeleteIsOpen" type="modal-danger" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Exclusão de Condomínio</h4>
                <button type="button" class="close" @click="closeDelete()"><span>&times;</span></button>
            </div>
            <form type="post" v-on:submit.prevent="executeDelete(model)" id="form-delete" novalidate>
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

    </div>
</template>
<script>


    import crudBase from '../../common/mixins/crud'

    import formPartial from './form.partial'
    import filterPartial from './filter.partial'

    export default {
        name: "condominio",
        components: { formPartial, filterPartial },
        mixins: [crudBase],
        data() {
            return {
                model: { endereco: {} },
                resource: "condominio",
            }
        }
    }
</script>