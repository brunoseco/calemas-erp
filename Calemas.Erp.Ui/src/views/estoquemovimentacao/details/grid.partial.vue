<template>
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
                                <tr v-for="item in crud.filter.result.itens" class="animated fadeIn">
                                    <td>{{ item.userCreateDate | date }}</td>
                                    <td>{{ item.quantidade }}</td>
                                    <td>{{ item.descricao }}</td>
                                    <td>{{ item.colaborador.pessoa.nome }}</td>
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