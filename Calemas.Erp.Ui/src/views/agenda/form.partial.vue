<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="agendaId" v-model="model.agendaId" />

            <div class="form-group col-md-12" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-6" data-reference="dataInicio">
                <label for="dataInicio">Data de Início</label>
                <input type="datetime-local" class="form-control" name="dataInicio" v-model="model.dataInicio" required />
            </div>
            <div class="form-group col-md-6" data-reference="dataFim">
                <label for="dataFim">Data de Fim</label>
                <input type="datetime-local" class="form-control" name="dataFim" v-model="model.dataFim" required />
            </div>
            <div class="form-group col-md-12" data-reference="corId">
                <label for="corId">Cor</label>
                <select v-select="{ dataitem: 'Cor', default: 'Selecione' }" v-model="model.corId" class="form-control" name="corId" required></select>
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