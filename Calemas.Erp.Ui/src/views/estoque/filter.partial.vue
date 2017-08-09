<template>

    <div class="row">
        <div class="form-group col-md-6">
            <label for="nome">Nome</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-6">
            <label for="referencia">Referência</label>
            <input type="text" class="form-control" name="referencia" placeholder="Referência" v-model="filter.referencia" />
        </div>
        <div class="form-group col-md-6">
            <label for="categoriaEstoqueId">Categoria</label>
            <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="filter.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId"></select>
        </div>
        <div class="form-group col-md-6">
            <label for="unidadeMedidaId">Unidade de Medida</label>
            <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="filter.unidadeMedidaId" class="form-control" name="unidadeMedidaId"></select>
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

    </div>

</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>