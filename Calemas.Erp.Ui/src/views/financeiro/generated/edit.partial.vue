<template>
    <modal title="Edição de Financeiro" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Financeiro</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="financeiroId" v-model="crud.edit.model.financeiroId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.dataVencimento') }">
                        <label for="dataVencimento">DataVencimento</label>
                        <input type="date" class="form-control" name="dataVencimento" v-model="crud.edit.model.dataVencimento" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.parcela') }">
                        <label for="parcela">Parcela</label>
                        <input type="text" class="form-control" name="parcela" placeholder="Parcela" v-model="crud.edit.model.parcela" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.planoContaId') }">
                        <label for="planoContaId">PlanoConta</label>
                        <select v-select="{ dataitem: 'PlanoConta', default: 'Selecione' }" v-model="crud.edit.model.planoContaId" class="form-control" name="planoContaId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorOriginal') }">
                        <label for="valorOriginal">ValorOriginal</label>
                        <input type="text" class="form-control" name="valorOriginal" placeholder="ValorOriginal" v-model="crud.edit.model.valorOriginal" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorDesconto') }">
                        <label for="valorDesconto">ValorDesconto</label>
                        <input type="text" class="form-control" name="valorDesconto" placeholder="ValorDesconto" v-model="crud.edit.model.valorDesconto" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorMultaJuros') }">
                        <label for="valorMultaJuros">ValorMultaJuros</label>
                        <input type="text" class="form-control" name="valorMultaJuros" placeholder="ValorMultaJuros" v-model="crud.edit.model.valorMultaJuros" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorFinal') }">
                        <label for="valorFinal">ValorFinal</label>
                        <input type="text" class="form-control" name="valorFinal" placeholder="ValorFinal" v-model="crud.edit.model.valorFinal" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.pessoaId') }">
                        <label for="pessoaId">Pessoa</label>
                        <select v-select="{ dataitem: 'Pessoa', default: 'Selecione' }" v-model="crud.edit.model.pessoaId" class="form-control" name="pessoaId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.edit.model.descricao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.baixado') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="baixado" class="custom-control-input" v-model="crud.edit.model.baixado">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Baixado?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.dataBaixa') }">
                        <label for="dataBaixa">DataBaixa</label>
                        <input type="date" class="form-control" name="dataBaixa" v-model="crud.edit.model.dataBaixa"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorDescontoAteVencimento') }">
                        <label for="valorDescontoAteVencimento">ValorDescontoAteVencimento</label>
                        <input type="text" class="form-control" name="valorDescontoAteVencimento" placeholder="ValorDescontoAteVencimento" v-model="crud.edit.model.valorDescontoAteVencimento" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.percentualJuros') }">
                        <label for="percentualJuros">PercentualJuros</label>
                        <input type="text" class="form-control" name="percentualJuros" placeholder="PercentualJuros" v-model="crud.edit.model.percentualJuros" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.percentualMulta') }">
                        <label for="percentualMulta">PercentualMulta</label>
                        <input type="text" class="form-control" name="percentualMulta" placeholder="PercentualMulta" v-model="crud.edit.model.percentualMulta" v-validate="'required'" />
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