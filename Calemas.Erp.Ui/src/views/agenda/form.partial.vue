<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="agendaId" v-model="model.agendaId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataInicio') }">
                        <label for="dataInicio">DataInicio</label>
                        <input type="date" class="form-control" name="dataInicio" v-model="model.dataInicio" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataFim') }">
                        <label for="dataFim">DataFim</label>
                        <input type="date" class="form-control" name="dataFim" v-model="model.dataFim" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('corId') }">
                        <label for="corId">Cor</label>
                        <select v-select="{ dataitem: 'Cor', default: 'Selecione' }" v-model="model.corId" class="form-control" name="corId" v-validate="'required'"></select>
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