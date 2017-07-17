<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Filtros</strong>
                    </div>
                    <div class="card-block">
                        <form v-on:submit.prevent="crud.filter.executeAction()">
                            <div class="row">
                                <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.estoqueId') }">
                                    <label for="estoqueId">Estoque/Produto</label>
                                    <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="crud.filter.model.estoqueId" class="form-control" name="estoqueId"></select>
                                </div>
                                <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-filter.referencia') }">
                                    <label for="referencia">Referência</label>
                                    <input type="text" class="form-control" name="referencia" placeholder="Referência" v-model="crud.filter.model.referencia" />
                                </div>
                                <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-filter.responsavelId') }">
                                    <label for="responsavelId">Responsável</label>
                                    <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="crud.filter.model.responsavelId" class="form-control" name="responsavelId"></select>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="card-footer text-right">
                        <button type="submit" class="btn btn-primary" @click="crud.filter.executeAction()">
                            <i class="fa fa-search"></i> Filtrar
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['crud']
    }
</script>