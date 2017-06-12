<template>
    <div class="wrapper">
        <div class="animated fadeIn">
            <div class="row" style="margin-bottom: 1rem;margin-top: -0.5rem;">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                    <h6 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        Cadastros
                        <span>Manutenção de Mídia</span>
                    </h6>
                </div>
                <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4 text-right">
                    <div class="btn-group">
                        <a href="javascript:history.back()" class="btn btn-primary btn-sm pull-right header-btn hidden-mobile">
                            <i class="fa fa-reply"></i> Voltar
                        </a>
                        <button @click="excuteCreateModal()" class="btn btn-success btn-sm pull-right header-btn hidden-mobile">
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
                            <form method="post">
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label for="Nome">Nome</label>
                                        <input type="text" id="Nome" name="Nome" class="form-control" placeholder="Nome">
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Ativo?</label>
                                        <div class="form-group">
                                            <label class="custom-control custom-radio">
                                                <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Todos</span>
                                            </label>
                                            <label class="custom-control custom-radio">
                                                <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Sim</span>
                                            </label>
                                            <label class="custom-control custom-radio">
                                                <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Não</span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-right">
                            <button type="submit" class="btn btn-primary">
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
                            Resultado
                        </div>
                        <div class="card-block no-padding">
                            <table class="table has-tickbox table-striped table-sm">
                                <thead class="">
                                    <tr>
                                        <th>#</th>
                                        <th>Nome</th>
                                        <th>Ativo</th>
                                        <th class="text-center" width="75">
                                            <i class="fa fa-cog"></i>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in list" class="animated fadeIn">
                                        <td>{{item.MidiaId}}</td>
                                        <td>{{item.Nome}}</td>
                                        <td>
                                            <span class="badge badge-pill" v-bind:class="{ 'badge-success': item.Ativo, 'badge-danger': !item.Ativo }">{{item.Ativo ? 'Sim' : 'Não'}}</span>
                                        </td>
                                        <td class="text-center">
                                            <button type="button" class="btn btn-xs btn-primary" @click="excuteEditModal(item)">
                                                <i class="fa fa-pencil"></i>
                                            </button>
                                            <button type="button" class="btn btn-xs btn-danger" @click="excuteDeleteModal(item)">
                                                <i class="fa fa-trash-o"></i>
                                            </button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="card-block no-padding">
                            <nav>
                                <ul class="pagination justify-content-center">
                                    <li class="page-item">
                                        <a class="page-link" href="#" aria-label="Previous">
                                            <span aria-hidden="true">&laquo;</span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item">
                                        <a class="page-link" href="#" aria-label="Next">
                                            <span aria-hidden="true">&raquo;</span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <modal title="Manutenção de Mídia" v-model="editModalIsOpen" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Edição de Mídia</h4>
            </div>
            <form type="post" v-on:submit="saveModel">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="Nome">Nome</label>
                        <input type="text" class="form-control" name="Nome" placeholder="Nome" v-model="model.Nome">
                    </div>
                    <div class="form-group col-md-12">
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="Ativo" class="custom-control-input" v-model="model.Ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                </div>
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="editModalIsOpen = false">Fechar</button>
                <button type="button" class="btn btn-success" @click="saveModel()">
                    <i class="fa fa-check"></i> Salvar
                </button>
            </div>
        </modal>

        <modal title="Cadastro de Mídia" v-model="createModalIsOpen" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Cadastro de Mídia</h4>
            </div>
            <form type="post" v-on:submit="saveModel">
                <div class="row">
                    <div class="form-group col-md-12">
                        <label for="Nome">Nome</label>
                        <input type="text" class="form-control" name="Nome" placeholder="Nome" v-model="model.Nome">
                    </div>
                    <div class="form-group col-md-12">
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="Ativo" class="custom-control-input" v-model="model.Ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                </div>
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="createModalIsOpen = false">Fechar</button>
                <button type="button" class="btn btn-success" @click="saveModel()">
                    <i class="fa fa-check"></i> Salvar
                </button>
            </div>
        </modal>

        <modal title="Exclusão de Mídia" v-model="deleteModalIsOpen" effect="fade/zoom">
            <div slot="modal-header" class="modal-header">
                <h4 class="modal-title">Exclusão de Mídia</h4>
            </div>
            <form type="post" v-on:submit="deleteModel">
                <div class="row">
                    <div class="form-group col-md-6">
                        <label class="label">Nome</label>
                        <p>{{model.Nome}}</p>
                    </div>
                    <div class="form-group col-md-">
                        <label class="label">Ativo?</label>
                        <p>
                            <span class="badge badge-pill" v-bind:class="{ 'badge-success': model.Ativo, 'badge-danger': !model.Ativo }">{{model.Ativo ? 'Sim' : 'Não'}}</span>
                        </p>
                    </div>
                </div>
            </form>
            <div slot="modal-footer" class="modal-footer">
                <button type="button" class="btn btn-default" @click="deleteModalIsOpen = false">Fechar</button>
                <button type="button" class="btn btn-danger" @click="deleteModel()">
                    <i class="fa fa-trash-o"></i> Remover
                </button>
            </div>
        </modal>

    </div>
</template>
<script>

    import modal from 'vue-strap/src/Modal'
    import { Api } from '../../common/api'

    export default {
        name: 'midia',
        components: { modal },
        data() {
            return {
                model: {
                    Nome: '',
                    Ativo: true
                },
                createModalIsOpen: false,
                editModalIsOpen: false,
                deleteModalIsOpen: false,
                list: []
            }
        },
        methods: {
            loadList() {
                var api = new Api("midia");
                api.Get().then(data => { this.list = data.DataList; });
            },
            saveModel() {
                var api = new Api("midia");
                api.Post(this.model).then(data => {
                    this.loadList();
                    this.createModalIsOpen = false;
                    this.editModalIsOpen = false;
                });
            },
            deleteModel() {
                var api = new Api("midia");
                api.Filter = this.model;
                api.Delete().then(data => {
                    this.loadList();
                    this.deleteModalIsOpen = false;
                });
            },
            excuteCreateModal() {
                this.model = {};
                this.createModalIsOpen = true;
            },
            excuteEditModal(model) {
                var api = new Api("midia");
                api.Filter = model;
                api.GetMethodCustom("GetByModel").then(data => {
                    this.editModalIsOpen = true;
                    this.model = data.Data;
                });

            },
            excuteDeleteModal(model) {
                var api = new Api("midia");
                api.Filter = model;
                api.GetMethodCustom("GetByModel").then(data => {
                    this.deleteModalIsOpen = true;
                    this.model = data.Data;
                });

            }
        },
        mounted() {
            this.loadList()
        }
    }
</script>
