<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-8">
                <div class="card">
                    <div class="card-header">
                        <strong>Filtros</strong>
                    </div>
                    <div class="card-block">
                        <form v-on:submit.prevent="crud.filter.executeAction()">
                            <div class="row">
                                <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-filter.userCreateDateStart') }">
                                    <label for="userCreateDateStart">Data da Movimentação</label>
                                    <input type="date" class="form-control" name="userCreateDateStart" v-model="crud.filter.model.userCreateDateStart" />
                                </div>
                                <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-filter.UserCreateDateEnd') }">
                                    <label for="UserCreateDateEnd">Até</label>
                                    <input type="date" class="form-control" name="UserCreateDateEnd" v-model="crud.filter.model.UserCreateDateEnd" />
                                </div>
                                <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.estoqueId') }">
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

            <div class="col-sm-4">
                <div class="card">
                    <div class="card-block">
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label for="estoqueId">Estoque</label>
                                <h6>{{ estoque.nome }}</h6>
                            </div>
                            <div class="form-group col-md-12">
                                <label for="estoqueId">Quantidade Mínima</label>
                                <h6>{{ estoque.quantidadeMinima }}</h6>
                            </div>
                            <div class="form-group col-md-12">
                                <label for="estoqueId">Quantidade Atual</label>
                                <h6>{{ estoque.quantidade }}</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
<script>

    import { Api } from '../../../common/api'

    export default {
        name: 'filter-partial',
        props: ['crud'],
        data() {
            return {
                estoque: {}
            }
        },
        mounted() {
            let id = this.$route.params.id;
            let api = new Api("estoque");
            api.filters.id = id;
            api.get().then(data => {
                this.estoque = data.data;
            });

        }
    }
</script>