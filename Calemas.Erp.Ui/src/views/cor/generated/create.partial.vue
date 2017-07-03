<template>
    <modal title="Cadastro de Cores do sistema" v-model="crud.create.modalIsOpen" effect="fade/zoom" :success="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Cores do sistema</h4>
        </div>
        <form data-vv-scope="form-create" v-on:submit.prevent="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="corId" v-model="crud.create.model.corId" />

                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.hash') }">
                        <label for="hash">Hash</label>
                        <div class="row">
                            <div class="col-md-6">
                                <input type="text" class="form-control" name="hash" placeholder="Hash" v-model="crud.create.model.hash" v-validate="'required'" />
                            </div>
                            <div class="col-md-6">
                                <compact-picker v-model="colors"></compact-picker>
                            </div>
                        </div>
                    </div>

                </div>
            </fieldset>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.create.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-success" @click="crud.create.executeAction()">
                <i class="fa fa-check"></i> Salvar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'
    import { Compact } from 'vue-color'

    export default {
        name: 'create-partial',
        props: ['crud'],
        components: {
            modal,
            'compact-picker': Compact
        },
        data() {
            return {
                colors: {
                    hex: this.crud.create.model.hash
                }
            }
        },
        watch: {
            colors: function (val) {
                this.crud.create.model.hash = val.hex;
            },
        },
        mounted() {
            this.crud.create.setVm(this);
        }
    }
</script>