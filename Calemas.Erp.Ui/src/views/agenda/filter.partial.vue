<template>
    <div class="row">
        <div class="form-group col-md-6">
            <label for="nome">Nome</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-6">
            <label for="colaborador">Colaborador</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.colaboradorId" class="form-control" name="colaboradorId" v-validate="'required'"></select>
        </div>
        <div class="form-group col-md-3">
            <label for="dataInicio">Data de Início</label>
            <input type="date" class="form-control" name="dataInicio" v-model="filter.dataInicio" />
        </div>
        <div class="form-group col-md-3">
            <label for="dataFim">Data de Fim</label>
            <input type="date" class="form-control" name="dataFim" v-model="filter.dataFim" />
        </div>
        <div class="form-group col-md-6">
            <label for="corId">Cor</label>
            <select v-select="{ dataitem: 'Cor', default: 'Selecione' }" v-model="filter.corId" class="form-control" name="corId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>