<template>
    <div class="row">

        <div class="form-group col-md-6">
            <label for="estoqueId">Estoque</label>
            <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="filter.estoqueId" class="form-control" name="estoqueId"></select>
        </div>
        <div class="form-group col-md-3">
            <label for="referencia">Referência</label>
            <input type="text" class="form-control" name="referencia" placeholder="Referência" v-model="filter.referencia" />
        </div>
        <div class="form-group col-md-3">
            <label for="responsavelId">Responsável</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.responsavelId" class="form-control" name="responsavelId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>