<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Filtros</strong>
                    </div>
                    <div class="card-block">
                        <form v-on:submit.prevent="crud.filter.executeAction()">
                            <div class="row">
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.dataVencimento') }">
                        <label for="dataVencimento">DataVencimento</label>
                        <input type="date" class="form-control" name="dataVencimento" v-model="crud.filter.model.dataVencimento"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.parcela') }">
                        <label for="parcela">Parcela</label>
                        <input type="text" class="form-control" name="parcela" placeholder="Parcela" v-model="crud.filter.model.parcela"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.planoContaId') }">
                        <label for="planoContaId">PlanoConta</label>
                        <select v-select="{ dataitem: 'PlanoConta', default: 'Selecione' }" v-model="crud.filter.model.planoContaId" class="form-control" name="planoContaId" ></select>
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorOriginal') }">
                        <label for="valorOriginal">ValorOriginal</label>
                        <input type="text" class="form-control" name="valorOriginal" placeholder="ValorOriginal" v-model="crud.filter.model.valorOriginal"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorDesconto') }">
                        <label for="valorDesconto">ValorDesconto</label>
                        <input type="text" class="form-control" name="valorDesconto" placeholder="ValorDesconto" v-model="crud.filter.model.valorDesconto"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorMultaJuros') }">
                        <label for="valorMultaJuros">ValorMultaJuros</label>
                        <input type="text" class="form-control" name="valorMultaJuros" placeholder="ValorMultaJuros" v-model="crud.filter.model.valorMultaJuros"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorFinal') }">
                        <label for="valorFinal">ValorFinal</label>
                        <input type="text" class="form-control" name="valorFinal" placeholder="ValorFinal" v-model="crud.filter.model.valorFinal"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.pessoaId') }">
                        <label for="pessoaId">Pessoa</label>
                        <select v-select="{ dataitem: 'Pessoa', default: 'Selecione' }" v-model="crud.filter.model.pessoaId" class="form-control" name="pessoaId" ></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.filter.model.descricao"  />
                    </div>
				<div class="form-group col-md-6">
                    <label>Baixado</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="crud.filter.model.baixado" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="crud.filter.model.baixado" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="crud.filter.model.baixado" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.dataBaixa') }">
                        <label for="dataBaixa">DataBaixa</label>
                        <input type="date" class="form-control" name="dataBaixa" v-model="crud.filter.model.dataBaixa"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorDescontoAteVencimento') }">
                        <label for="valorDescontoAteVencimento">ValorDescontoAteVencimento</label>
                        <input type="text" class="form-control" name="valorDescontoAteVencimento" placeholder="ValorDescontoAteVencimento" v-model="crud.filter.model.valorDescontoAteVencimento"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.percentualJuros') }">
                        <label for="percentualJuros">PercentualJuros</label>
                        <input type="text" class="form-control" name="percentualJuros" placeholder="PercentualJuros" v-model="crud.filter.model.percentualJuros"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.percentualMulta') }">
                        <label for="percentualMulta">PercentualMulta</label>
                        <input type="text" class="form-control" name="percentualMulta" placeholder="PercentualMulta" v-model="crud.filter.model.percentualMulta"  />
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
    </div>

</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['crud']
    }
</script>