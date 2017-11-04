<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="solicitacaoEstoqueMovimentacaoId" v-model="model.solicitacaoEstoqueMovimentacaoId" />
            <input type="hidden" class="form-control" name="solicitacaoEstoqueId" v-model="model.solicitacaoEstoqueId" />
            <div class="form-group col-md-12">
                <label for="estoqueId">Estoque</label>
                <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="model.estoqueId" class="form-control" name="estoqueId" required></select>
            </div>
            <div class="form-group col-md-12">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="entrada" class="custom-control-input" v-model="model.entrada">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Entrada?</span>
                </label>
            </div>
            <div class="form-group col-md-12">
                <label for="quantidade">Quantidade</label>
                <input type="number" class="form-control" name="quantidade" placeholder="Quantidade" v-model="model.quantidade" required />
            </div>

        </div>
    </fieldset>
</template>
<script>
    import formBase from '../../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
    }
</script>
