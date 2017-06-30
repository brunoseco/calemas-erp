<template>
    <modal title="Edição de Colaborador" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Colaborador</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="colaboradorId" v-model="crud.edit.model.colaboradorId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.account') }">
                        <label for="account">Account</label>
                        <input type="text" class="form-control" name="account" placeholder="Account" v-model="crud.edit.model.account" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.password') }">
                        <label for="password">Password</label>
                        <input type="text" class="form-control" name="password" placeholder="Password" v-model="crud.edit.model.password" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.ativo') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.edit.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nivelAcessoId') }">
                        <label for="nivelAcessoId">NivelAcesso</label>
                        <select v-select="{ dataitem: 'NivelAcesso', default: 'Selecione' }" v-model="crud.edit.model.nivelAcessoId" class="form-control" name="nivelAcessoId" v-validate="'required'"></select>
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

    export default {
        name: 'edit-partial',
        props: ['crud'],
        components: { modal },
        mounted() {
            this.crud.edit.setVm(this);
        }
    }
</script>