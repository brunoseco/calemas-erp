<template>
    <modal title="Edição de Cores do sistema" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Cores do sistema</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="corId" v-model="crud.edit.model.corId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.edit.model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.hash') }">
                        <label for="hash">Hash</label>
                        <div class="row">
                            <div class="col-md-6">
                                <input type="text" class="form-control" name="hash" placeholder="Hash" v-model="crud.edit.model.hash" v-validate="'required'" />
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
            <button type="button" class="btn btn-default" @click="crud.edit.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-primary" @click="crud.edit.executeAction()">
                <i class="fa fa-pencil"></i> Alterar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'
    import { Compact } from 'vue-color'

    export default {
        name: 'edit-partial',
        props: ['crud'],
        components: {
            modal,
            'compact-picker': Compact
        },
        data() {
            return {
                colors: {
                    hex: this.crud.edit.model.hash
                }
            }
        },
        watch: {
            colors: function (val) {
                this.crud.edit.model.hash = val.hex;
            },
        },
        mounted() {
            this.crud.edit.setVm(this);
        }
    }
</script>