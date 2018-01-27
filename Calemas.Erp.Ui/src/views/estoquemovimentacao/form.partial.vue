<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">

            <input type="hidden" class="form-control" name="estoqueMovimentacaoId" v-model="model.estoqueMovimentacaoId" />
            <input type="hidden" class="form-control" name="estoqueId" v-model="model.estoqueId" />
            <input type="hidden" class="form-control" name="entrada" v-model="model.entrada" />

            <div class="form-group col-md-6" data-reference="quantidade">
                <label for="quantidade">Quantidade</label>
                <input type="number" class="form-control" name="quantidade" placeholder="Quantidade" v-model="model.quantidade" required />
            </div>
            <div class="form-group col-md-6" data-reference="motivoEstoqueMovimentacaoId">
                <label for="motivoEstoqueMovimentacaoId">Motivo da Movimentação</label>
                <select v-select="{ dataitem: 'MotivoEstoqueMovimentacao', default: 'Selecione' }" v-model="model.motivoEstoqueMovimentacaoId" class="form-control" name="motivoEstoqueMovimentacaoId"></select>
            </div>

            <div class="form-group col-md-12" data-reference="descricao">
                <label for="descricao">Descrição</label>
                <textarea type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" required></textarea>
            </div>

            <div class="form-group col-md-6" data-reference="responsavelId">
                <label for="responsavelId">Responsável</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" required></select>
            </div>
            <div class="form-group col-md-6">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.atualizaEstoqueColaborador">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Atualizar no estoque do responsável?</span>
                </label>
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
