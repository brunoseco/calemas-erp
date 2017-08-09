<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="financeiroId" v-model="model.financeiroId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataVencimento') }">
                        <label for="dataVencimento">DataVencimento</label>
                        <input type="date" class="form-control" name="dataVencimento" v-model="model.dataVencimento" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('parcela') }">
                        <label for="parcela">Parcela</label>
                        <input type="text" class="form-control" name="parcela" placeholder="Parcela" v-model="model.parcela" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('planoContaId') }">
                        <label for="planoContaId">PlanoConta</label>
                        <select v-select="{ dataitem: 'PlanoConta', default: 'Selecione' }" v-model="model.planoContaId" class="form-control" name="planoContaId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('valorOriginal') }">
                        <label for="valorOriginal">ValorOriginal</label>
                        <input type="text" class="form-control" name="valorOriginal" placeholder="ValorOriginal" v-model="model.valorOriginal" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('valorDesconto') }">
                        <label for="valorDesconto">ValorDesconto</label>
                        <input type="text" class="form-control" name="valorDesconto" placeholder="ValorDesconto" v-model="model.valorDesconto" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('valorMultaJuros') }">
                        <label for="valorMultaJuros">ValorMultaJuros</label>
                        <input type="text" class="form-control" name="valorMultaJuros" placeholder="ValorMultaJuros" v-model="model.valorMultaJuros" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('valorFinal') }">
                        <label for="valorFinal">ValorFinal</label>
                        <input type="text" class="form-control" name="valorFinal" placeholder="ValorFinal" v-model="model.valorFinal" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('pessoaId') }">
                        <label for="pessoaId">Pessoa</label>
                        <select v-select="{ dataitem: 'Pessoa', default: 'Selecione' }" v-model="model.pessoaId" class="form-control" name="pessoaId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="baixado" class="custom-control-input" v-model="model.baixado">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Baixado?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="dataBaixa">DataBaixa</label>
                        <input type="date" class="form-control" name="dataBaixa" v-model="model.dataBaixa"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('valorDescontoAteVencimento') }">
                        <label for="valorDescontoAteVencimento">ValorDescontoAteVencimento</label>
                        <input type="text" class="form-control" name="valorDescontoAteVencimento" placeholder="ValorDescontoAteVencimento" v-model="model.valorDescontoAteVencimento" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('percentualJuros') }">
                        <label for="percentualJuros">PercentualJuros</label>
                        <input type="text" class="form-control" name="percentualJuros" placeholder="PercentualJuros" v-model="model.percentualJuros" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('percentualMulta') }">
                        <label for="percentualMulta">PercentualMulta</label>
                        <input type="text" class="form-control" name="percentualMulta" placeholder="PercentualMulta" v-model="model.percentualMulta" v-validate="'required'" />
                    </div>

        </div>
    </fieldset>
</template>
<script>
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],        
    }
</script>