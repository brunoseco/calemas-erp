<template>
    <div class="wrapper">
        <div class="animated fadeIn">
            <div class="row" style="margin-bottom: 1rem;margin-top: -0.5rem;">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                    <h6 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        Cadastros
                        <span>Manutenção de Colaboradores</span>
                    </h6>
                </div>
                <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4 text-right">
                    <div class="btn-group">
                        <a href="javascript:history.back()" class="btn btn-primary btn-sm pull-right header-btn hidden-mobile">
                            <i class="fa fa-reply"></i> Voltar
                        </a>
                        <button @click="crud.create.executeModal()" class="btn btn-success btn-sm pull-right header-btn hidden-mobile">
                            <i class="fa fa-plus"></i> Cadastrar
                        </button>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <strong>Filtros</strong>
                        </div>
                        <div class="card-block">
                            <form v-on:submit.prevent="crud.filter.executeAction()">
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label for="Nome">Nome</label>
                                        <input type="text" name="Nome" v-model="crud.filter.model.Nome" class="form-control" placeholder="Nome" required />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Ativo?</label>
                                        <div class="form-group">
                                            <label class="custom-control custom-radio">
                                                <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="undefined" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Todos</span>
                                            </label>
                                            <label class="custom-control custom-radio">
                                                <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="true" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Sim</span>
                                            </label>
                                            <label class="custom-control custom-radio">
                                                <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="false" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Não</span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-right">
                            <button type="submit" class="btn btn-primary" @click="crud.filter.executeAction()">
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
                                        <th>Nome</th>
                                        <th>Email</th>
                                        <th>Telefone</th>
                                        <th>Conta/Acesso</th>
                                        <th>Ativo</th>
                                        <th class="text-center" width="75">
                                            <i class="fa fa-cog"></i>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in crud.filter.result.itens" class="animated fadeIn">
                                        <td>{{ item.colaboradorId }}</td>
                                        <td>{{ item.pessoa.nome }}</td>
                                        <td>{{ item.pessoa.email }}</td>
                                        <td>{{ item.pessoa.telefone }}</td>
                                        <td>{{ item.account }}</td>
                                        <td>
                                            <span class="badge badge-pill" v-bind:class="{ 'badge-success': item.Ativo, 'badge-danger': !item.Ativo }">{{item.Ativo ? 'Sim' : 'Não'}}</span>
                                        </td>
                                        <td class="text-center">
                                            <button type="button" class="btn btn-xs btn-primary" @click="crud.edit.executeModal(item)">
                                                <i class="fa fa-pencil"></i>
                                            </button>
                                            <button type="button" class="btn btn-xs btn-danger" @click="crud.delete.executeModal(item)">
                                                <i class="fa fa-trash-o"></i>
                                            </button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="card-block no-padding">
                            <pagination :total="crud.filter.result.total" :page-size="crud.filter.options.pageSize" :callback="crud.filter.executePageChanged"></pagination>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <create :crud="crud" />

        <!--<modal title="Exclusão de Mídia" v-model="crud.delete.modalIsOpen" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Exclusão de Colaborador</h4>
            </div>
            <form type="post" v-on:submit="crud.delete.executeAction()">
                <div class="row">
                    <div class="form-group col-md-6">
                        <label class="label">Nome</label>
                        <p>{{crud.delete.model.pessoa.nome}}</p>
                    </div>
                </div>
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="crud.delete.modalIsOpen = false">Fechar</button>
                <button type="button" class="btn btn-danger" @click="crud.delete.executeAction()">
                    <i class="fa fa-trash-o"></i> Remover
                </button>
            </div>
        </modal>-->

    </div>
</template>
<script>

    import modal from 'vue-strap/src/Modal'
    import pagination from 'vue-pagination-bootstrap'
    import { Api } from '../../common/api'
    import { Crud } from '../../common/crud'
    import create from './create/create'

    export default {
        name: 'colaborador',
        components: { modal, pagination, create },
        data() {
            return {
                crud: new Crud(
                    {
                        resource: "colaborador",
                        vm: this,
                        create: {
                            model: {
                                pessoa: {}
                            }
                        }
                    }),
            }
        },
        mounted() {
            this.crud.filter.executeAction();
        }
    }
</script>
