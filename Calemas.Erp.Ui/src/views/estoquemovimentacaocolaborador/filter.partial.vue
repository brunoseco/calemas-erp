<template>
    <div class="row">
        <div class="form-group col-md-6">
            <label for="colaboradorId">Colaborador</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.colaboradorId" class="form-control" name="colaboradorId"></select>
        </div>
        <div class="form-group col-md-6">
            <label for="colaboradorId">Estoque</label>
            <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="filter.estoqueId" class="form-control" name="estoqueId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
