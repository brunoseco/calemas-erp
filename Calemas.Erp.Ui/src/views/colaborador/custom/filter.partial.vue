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
                                <div class="form-group col-md-6">
                                    <label for="Nome">Nome</label>
                                    <input type="text" name="Nome" v-model="crud.filter.model.Nome" class="form-control" placeholder="Nome" required />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>Ativo?</label>
                                    <div class="form-group">
                                        <label class="custom-control custom-radio">
                                            <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="undefined" class="custom-control-input">
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Todos</span>
                                        </label>
                                        <label class="custom-control custom-radio">
                                            <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="true" class="custom-control-input">
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Sim</span>
                                        </label>
                                        <label class="custom-control custom-radio">
                                            <input type="radio" name="Ativo" v-model="crud.filter.model.Ativo" value="false" class="custom-control-input">
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Não</span>
                                        </label>
                                    </div>
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
