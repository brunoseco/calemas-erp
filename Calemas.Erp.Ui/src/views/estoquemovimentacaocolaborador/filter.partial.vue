<template>
    <div class="row">
        <div class="form-group col-md-12">
            <label for="colaboradorId">Colaborador</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.colaboradorId" class="form-control" name="colaboradorId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
