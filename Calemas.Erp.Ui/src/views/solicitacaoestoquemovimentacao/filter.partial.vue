<template>
    <div class="row">
        <div class="form-group col-md-12">
            <label for="estoqueId">Estoque</label>
            <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="filter.estoqueId" class="form-control" name="estoqueId"></select>
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
            <label for="descricao">Descricao</label>
            <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao" />
        </div>
        <div class="form-group col-md-12">
            <label for="solicitanteId">SolicitanteId</label>
            <input type="text" class="form-control" name="solicitanteId" placeholder="SolicitanteId" v-model="filter.solicitanteId" />
        </div>
        <div class="form-group col-md-12">
            <label for="dataSolicitacao">DataSolicitacao</label>
            <input type="date" class="form-control" name="dataSolicitacao" v-model="filter.dataSolicitacao" />
        </div>
        <div class="form-group col-md-12">
            <label for="dataPrevista">DataPrevista</label>
            <input type="date" class="form-control" name="dataPrevista" v-model="filter.dataPrevista" />
        </div>
        <div class="form-group col-md-12">
            <label for="statusSolicitacaoEstoqueMovimentacaoId">StatusSolicitacaoEstoqueMovimentacao</label>
            <select v-select="{ dataitem: 'StatusSolicitacaoEstoqueMovimentacao', default: 'Selecione' }" v-model="filter.statusSolicitacaoEstoqueMovimentacaoId" class="form-control" name="statusSolicitacaoEstoqueMovimentacaoId"></select>
        </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>