<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="solicitacaoEstoqueMovimentacaoId" v-model="model.solicitacaoEstoqueMovimentacaoId" />

            <div class="form-group col-md-12">
                <label for="estoqueId">Estoque</label>
                <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="model.estoqueId" class="form-control" name="estoqueId" required></select>
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descrição" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="solicitanteId">Quem fará a retirada?</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.solicitanteId" class="form-control" name="solicitanteId" required></select>
            </div>
            <div class="form-group col-md-6" data-reference="quantidade">
                <label for="quantidade">Quantidade</label>
                <input type="number" class="form-control" name="quantidade" placeholder="Quantidade" v-model="model.quantidade" required />
            </div>
            <div class="form-group col-md-6">
                <label for="dataPrevista">Data prevista para movimentação</label>
                <input type="datetime-local" class="form-control" name="dataPrevista" v-model="model.dataPrevista" required />
            </div>
            <div class="form-group col-md-12">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="entrada" class="custom-control-input" v-model="model.entrada">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Está solicitando uma entrada de itens?</span>
                </label>
                <div class="clearfix"><small><em>Se for uma saída, não selecione este campo</em></small></div>
            </div>

            <div class="form-group col-md-12" v-show="model.solicitacaoEstoqueMovimentacaoId > 0">
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
