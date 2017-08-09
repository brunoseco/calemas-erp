<template>
    <div class="row">
        					<div class="form-group col-md-12" >
                        <label for="dataVencimento">DataVencimento</label>
                        <input type="date" class="form-control" name="dataVencimento" v-model="filter.dataVencimento"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="parcela">Parcela</label>
                        <input type="text" class="form-control" name="parcela" placeholder="Parcela" v-model="filter.parcela"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="planoContaId">PlanoConta</label>
                        <select v-select="{ dataitem: 'PlanoConta', default: 'Selecione' }" v-model="filter.planoContaId" class="form-control" name="planoContaId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorOriginal">ValorOriginal</label>
                        <input type="text" class="form-control" name="valorOriginal" placeholder="ValorOriginal" v-model="filter.valorOriginal"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorDesconto">ValorDesconto</label>
                        <input type="text" class="form-control" name="valorDesconto" placeholder="ValorDesconto" v-model="filter.valorDesconto"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorMultaJuros">ValorMultaJuros</label>
                        <input type="text" class="form-control" name="valorMultaJuros" placeholder="ValorMultaJuros" v-model="filter.valorMultaJuros"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorFinal">ValorFinal</label>
                        <input type="text" class="form-control" name="valorFinal" placeholder="ValorFinal" v-model="filter.valorFinal"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="pessoaId">Pessoa</label>
                        <select v-select="{ dataitem: 'Pessoa', default: 'Selecione' }" v-model="filter.pessoaId" class="form-control" name="pessoaId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>
				<div class="form-group col-md-12">
                    <label>Baixado</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="filter.baixado" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="filter.baixado" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="baixado" v-model="filter.baixado" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-12" >
                        <label for="dataBaixa">DataBaixa</label>
                        <input type="date" class="form-control" name="dataBaixa" v-model="filter.dataBaixa"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorDescontoAteVencimento">ValorDescontoAteVencimento</label>
                        <input type="text" class="form-control" name="valorDescontoAteVencimento" placeholder="ValorDescontoAteVencimento" v-model="filter.valorDescontoAteVencimento"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="percentualJuros">PercentualJuros</label>
                        <input type="text" class="form-control" name="percentualJuros" placeholder="PercentualJuros" v-model="filter.percentualJuros"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="percentualMulta">PercentualMulta</label>
                        <input type="text" class="form-control" name="percentualMulta" placeholder="PercentualMulta" v-model="filter.percentualMulta"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>