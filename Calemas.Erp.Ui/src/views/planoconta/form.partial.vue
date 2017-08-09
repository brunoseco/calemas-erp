<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="planoContaId" v-model="model.planoContaId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('tipoPlanoContaId') }">
                        <label for="tipoPlanoContaId">TipoPlanoConta</label>
                        <select v-select="{ dataitem: 'TipoPlanoConta', default: 'Selecione' }" v-model="model.tipoPlanoContaId" class="form-control" name="tipoPlanoContaId" v-validate="'required'"></select>
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