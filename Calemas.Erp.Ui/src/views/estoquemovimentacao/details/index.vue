<template>
    <div class="wrapper">
        <div class="animated fadeIn">
            <div class="row" style="margin-bottom: 1rem;margin-top: -0.5rem;">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                    <h6 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        Estoque
                        <span>Detalhes de Movimentação de estoque</span>
                    </h6>
                </div>
                <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4 text-right">
                    <div class="btn-group">
                        <a href="javascript:history.back()" class="btn btn-secondary btn-sm pull-right header-btn hidden-mobile">
                            <i class="fa fa-reply"></i> Voltar
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="animated fadeIn">
            <div class="row animated fadeIn">
                <div class="col-sm-8">
                    <div class="card">
                        <div class="card-header">
                            <strong>Filtros</strong>
                        </div>
                        <div class="card-block">
                            <form v-on:submit.prevent="executeFilter()">
                                <filter-partial :filter="filter" />
                            </form>
                        </div>
                        <div class="card-footer text-right">
                            <button type="submit" class="btn btn-primary" @click="executeFilter()">
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

        <div class="animated fadeIn">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <strong>Resultado</strong>
                        </div>
                        <div class="card-block no-padding">
                            <table class="table table-striped table-sm">
                                <thead class="">
                                    <tr>
                                        <th>Data</th>
                                        <th>Qtde. Movimentada</th>
                                        <th>Descrição</th>
                                        <th>Responsável</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in result.itens" class="animated fadeIn">
                                        <td>{{ item.userCreateDate | date }}</td>
                                        <td>{{ item.quantidade }}</td>
                                        <td>{{ item.descricao }}</td>
                                        <td>{{ item.colaborador.pessoa.nome }}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="card-block no-padding">
                            <pagination :total="result.total" :page-size="filter.pageSize" :callback="executePageChanged"></pagination>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>
<script>

    import crudBase from '../../../common/mixins/crud'
    import filterPartial from './filter.partial'

    import { Api } from '../../../common/api'

    export default {
        name: 'estoquemovimentacaodetails',
        components: { filterPartial },
        mixins: [crudBase],
        data() {
            return {
                resource: "estoquemovimentacao",
                estoque: {},
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
