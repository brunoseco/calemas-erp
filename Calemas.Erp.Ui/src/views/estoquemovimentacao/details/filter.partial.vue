<template>
    <div class="row">
        <div class="form-group col-md-3">
            <label for="userCreateDateStart">Data da Movimentação</label>
            <input type="date" class="form-control" name="userCreateDateStart" v-model="filter.userCreateDateStart" />
        </div>
        <div class="form-group col-md-3">
            <label for="userCreateDateEnd">Até</label>
            <input type="date" class="form-control" name="userCreateDateEnd" v-model="filter.userCreateDateEnd" />
        </div>
        <div class="form-group col-md-6">
            <label for="responsavelId">Responsável</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.responsavelId" class="form-control" name="responsavelId"></select>
        </div>
        <div class="form-group col-md-6">
            <label>Tipo da Movimentação</label>
            <div class="form-group">
                <label class="custom-control custom-radio">
                    <input type="radio" name="entrada" v-model="filter.entrada" value="undefined" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Todos</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="entrada" v-model="filter.entrada" value="true" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Entrada</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="entrada" v-model="filter.entrada" value="false" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Saída</span>
                </label>
            </div>
        </div>
        <div class="form-group col-md-3">
            <label for="quantidadeDe">Quantidade movimentada</label>
            <input type="number" class="form-control" name="quantidadeDe" v-model="filter.quantidadeDe" />
        </div>
        <div class="form-group col-md-3">
            <label for="quantidadeAte">Até</label>
            <input type="number" class="form-control" name="quantidadeAte" v-model="filter.quantidadeAte" />
        </div>
    </div>

</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
