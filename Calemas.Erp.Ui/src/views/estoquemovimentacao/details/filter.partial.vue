<template>
    <div class="row">
        <div class="form-group col-md-3">
            <label for="userCreateDateStart">Data da Movimentação</label>
            <input type="date" class="form-control" name="userCreateDateStart" v-model="filter.userCreateDateStart" />
        </div>
        <div class="form-group col-md-3">
            <label for="UserCreateDateEnd">Até</label>
            <input type="date" class="form-control" name="UserCreateDateEnd" v-model="filter.UserCreateDateEnd" />
        </div>
        <div class="form-group col-md-6">
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