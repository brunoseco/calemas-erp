<template>
    <div class="row">
        <div class="form-group col-md-4">
            <label for="dataSolicitacao">Data da Solicitação</label>
            <input type="date" class="form-control" name="dataSolicitacao" v-model="filter.dataSolicitacao" />
        </div>
        <div class="form-group col-md-4">
            <label for="dataPrevista">Data Prevista</label>
            <input type="date" class="form-control" name="dataPrevista" v-model="filter.dataPrevista" />
        </div>
        <div class="form-group col-md-4">
            <label for="solicitanteId">Solicitante</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.solicitanteId" class="form-control" name="solicitanteId"></select>
        </div>
        <div class="form-group col-md-4">
            <label for="statusSolicitacaoEstoqueMovimentacaoId">Situação</label>
            <select v-select="{ dataitem: 'StatusSolicitacaoEstoqueMovimentacao', default: 'Selecione' }" v-model="filter.statusSolicitacaoEstoqueMovimentacaoId" class="form-control" name="statusSolicitacaoEstoqueMovimentacaoId"></select>
        </div>
        <div class="form-group col-md-8">
            <label for="descricao">Descrição</label>
            <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao" />
        </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
