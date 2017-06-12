<template>
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
