<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="estoqueMovimentacaoId" v-model="model.estoqueMovimentacaoId" />

                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('estoqueId') }">
                        <label for="estoqueId">Estoque</label>
                        <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="model.estoqueId" class="form-control" name="estoqueId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="entrada" class="custom-control-input" v-model="model.entrada">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Entrada?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="model.quantidade" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('responsavelId') }">
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
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