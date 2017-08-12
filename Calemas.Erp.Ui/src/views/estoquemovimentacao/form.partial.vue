<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="estoqueMovimentacaoId" v-model="model.estoqueMovimentacaoId" />
            <input type="hidden" class="form-control" name="estoqueId" v-model="model.estoqueId" />
            <input type="hidden" class="form-control" name="entrada" v-model="model.entrada" />
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('quantidade') }">
                <label for="quantidade">Quantidade</label>
                <input type="number" class="form-control" name="quantidade" placeholder="Quantidade" v-model="model.quantidade" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('responsavelId') }">
                <label for="responsavelId">Responsável</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('descricao') }">
                <label for="descricao">Descrição</label>
                <textarea type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" v-validate="'required'"></textarea>
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