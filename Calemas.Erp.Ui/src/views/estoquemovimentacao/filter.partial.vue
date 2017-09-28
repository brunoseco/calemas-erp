<template>
    <div class="row">
        <div class="form-group col-md-6">
            <label for="estoqueId">Estoque</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome do item" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-3">
            <label for="referencia">Código</label>
            <input type="text" class="form-control" name="referencia" placeholder="Referência" v-model="filter.referencia" />
        </div>
        <div class="form-group col-md-3">
            <label for="responsavelId">Responsável</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.responsavelId" class="form-control" name="responsavelId"></select>
        </div>

        <div class="form-group col-md-6">
            <label for="categoriaEstoqueId">Categoria de Estoque</label>
            <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="filter.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId"></select>
        </div>
        <div class="form-group col-md-3">
            <label for="referencia">Fabricante</label>
            <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="filter.fabricante" />
        </div>
        <div class="form-group col-md-3">
            <label for="referencia">Modelo</label>
            <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="filter.modelo" />
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>