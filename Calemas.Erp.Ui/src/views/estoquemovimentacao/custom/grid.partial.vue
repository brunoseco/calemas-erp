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
                                        Referência
                                        <button @click="crud.filter.orderBy('referencia')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th>
                                        Nome
                                        <button @click="crud.filter.orderBy('nome')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th>
                                        Qtde. Mínima
                                        <button @click="crud.filter.orderBy('quantidadeMinima')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th>
                                        Qtde. Atual
                                        <button @click="crud.filter.orderBy('quantidade')" class="btn btn-xs btn-link no-border pull-right">
                                            <i class="fa fa-sort"></i>
                                        </button>
                                    </th>
                                    <th class="text-center" width="100">
                                        <i class="fa fa-cog"></i>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in crud.filter.result.itens" class="animated fadeIn">
                                    <td>{{ item.estoqueId }}</td>
                                    <td>{{ item.referencia }}</td>
                                    <td>{{ item.nome }}</td>
                                    <td>{{ item.quantidadeMinima }}</td>
                                    <td>{{ item.quantidade }}</td>
                                    <td class="text-center">
                                        <button type="button" class="btn btn-xs btn-default" @click="crud.details.executeModal(null, {estoqueId:item.estoqueId})">
                                            <i class="fa fa-history"></i>
                                        </button>
                                        <button type="button" class="btn btn-xs btn-danger" @click="crud.create.executeModal({ estoqueId: item.estoqueId, entrada: false })">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-xs btn-success" @click="crud.create.executeModal({ estoqueId: item.estoqueId, entrada: true })">
                                            <i class="fa fa-plus"></i>
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