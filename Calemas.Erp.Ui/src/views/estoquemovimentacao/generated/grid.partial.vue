<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Resultado</strong>
                    </div>
                    <div class="card-block no-padding">
                        <table class="table has-tickbox table-striped table-sm">
                            <thead class="">
                                <tr>
                                    <th>#</th>
                                    <th>
                                        Entrada
                                        <button @click="crud.filter.orderBy('nome')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th>
                                        Descricao
                                        <button @click="crud.filter.orderBy('nome')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th>
                                        Quantidade
                                        <button @click="crud.filter.orderBy('nome')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>

                                    <th class="text-center" width="75">
                                        <i class="fa fa-cog"></i>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in crud.filter.result.itens" class="animated fadeIn">
                                    <td>{{ item.estoqueMovimentacaoId }}</td>
                                    <td><span class="badge badge-pill" v-bind:class="{ 'badge-success': item.entrada, 'badge-danger': !item.entrada }">{{item.entrada ? 'Sim' : 'Não'}}</span></td>
                                    <td>{{ item.descricao }}</td>
                                    <td>{{ item.quantidade }}</td>

                                    <td class="text-center">
                                        <button type="button" class="btn btn-xs btn-primary" @click="crud.edit.executeModal(item.estoqueMovimentacaoId, item)">
                                            <i class="fa fa-pencil"></i>
                                        </button>
                                        <button type="button" class="btn btn-xs btn-danger" @click="crud.delete.executeModal(item.estoqueMovimentacaoId, item)">
                                            <i class="fa fa-trash-o"></i>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="card-block no-padding">
                        <pagination :total="crud.filter.result.total" :page-size="crud.filter.options.pageSize" :callback="crud.filter.executePageChanged"></pagination>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
<script>
    import pagination from 'vue-pagination-bootstrap'

    export default {
        name: 'grid-partial',
        props: ['crud'],
        components: {
            pagination
        },

    }
</script>