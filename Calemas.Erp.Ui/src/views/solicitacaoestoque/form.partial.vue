<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="solicitacaoEstoqueId" v-model="model.solicitacaoEstoqueId" />

            <div class="form-group col-md-12">
                <label for="dataPrevista">Data Prevista</label>
                <input type="date" class="form-control" name="dataPrevista" v-model="model.dataPrevista" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descrição" v-model="model.descricao" required />
            </div>

            <div class="form-group col-md-12" v-show="model.solicitacaoEstoqueId > 0">
                <label for="statusSolicitacaoEstoqueMovimentacaoId">Situação</label>
                <select v-select="{ dataitem: 'StatusSolicitacaoEstoqueMovimentacao', default: 'Selecione' }" v-model="model.statusSolicitacaoEstoqueMovimentacaoId" class="form-control" name="statusSolicitacaoEstoqueMovimentacaoId" required></select>
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
