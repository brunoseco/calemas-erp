<template>
    <modal title="Edição de Movimentação de estoque" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Movimentação de estoque</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="estoqueMovimentacaoId" v-model="crud.edit.model.estoqueMovimentacaoId" />

                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.estoqueId') }">
                        <label for="estoqueId">Estoque</label>
                        <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="crud.edit.model.estoqueId" class="form-control" name="estoqueId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.entrada') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="entrada" class="custom-control-input" v-model="crud.edit.model.entrada">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Entrada?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.edit.model.descricao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.edit.model.quantidade" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.responsavelId') }">
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="crud.edit.model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
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