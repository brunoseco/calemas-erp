<template>
    <div class="row">
                            <div class="form-group col-md-12">
                        <label for="solicitacaoEstoqueId">SolicitacaoEstoque</label>
                        <select v-select="{ dataitem: 'SolicitacaoEstoque', default: 'Selecione' }" v-model="filter.solicitacaoEstoqueId" class="form-control" name="solicitacaoEstoqueId" ></select>
                    </div>
                    <div class="form-group col-md-12">
                        <label for="estoqueId">Estoque</label>
                        <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="filter.estoqueId" class="form-control" name="estoqueId" ></select>
                    </div>
				<div class="form-group col-md-12">
                    <label>Entrada</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-12">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="filter.quantidade"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>