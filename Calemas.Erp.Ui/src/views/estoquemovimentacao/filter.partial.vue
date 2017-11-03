<template>
    <div class="row">
        <div class="form-group col-md-2">
            <label for="referencia">Código</label>
            <input type="text" class="form-control" name="referencia" placeholder="Código" v-model="filter.referencia" />
        </div>
        <div class="form-group col-md-4">
            <label for="nome">Nome</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-3">
            <label for="modelo">Modelo</label>
            <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="filter.modelo" />
        </div>
        <div class="form-group col-md-3">
            <label for="fabricante">Fabricante</label>
            <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="filter.fabricante" />
        </div>
        <div class="form-group col-md-6">
            <label for="unidadeMedidaId">Unidade de Medida</label>
            <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="filter.unidadeMedidaId" class="form-control" name="unidadeMedidaId"></select>
        </div>
        <div class="form-group col-md-6">
            <label for="categoriaEstoqueId">Categoria de Estoque</label>
            <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="filter.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId"></select>
        </div>
        <div class="form-group col-md-6">
            <label>Ativo</label>
            <div class="form-group">
                <label class="custom-control custom-radio">
                    <input type="radio" name="ativo" v-model="filter.ativo" value="undefined" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Todos</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="ativo" v-model="filter.ativo" value="true" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Sim</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="ativo" v-model="filter.ativo" value="false" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Não</span>
                </label>
            </div>
        </div>
        <div class="form-group col-md-6">
            <label>Abaixo ou igual a Quantidade Mínima</label>
            <div class="form-group">
                <label class="custom-control custom-radio">
                    <input type="radio" name="abaixoMinimo" v-model="filter.abaixoMinimo" value="undefined" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Todos</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="abaixoMinimo" v-model="filter.abaixoMinimo" value="true" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Sim</span>
                </label>
                <label class="custom-control custom-radio">
                    <input type="radio" name="abaixoMinimo" v-model="filter.abaixoMinimo" value="false" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Não</span>
                </label>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
