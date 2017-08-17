<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="estoqueId" v-model="model.estoqueId" />

            <div class="form-group col-md-8" v-bind:class="{ 'has-danger': errors.has('nome') }">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" v-validate="'required'" />
            </div>
            <div class="form-group col-md-4">
                <label for="referencia">Referência</label>
                <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="model.referencia" />
            </div>
            <div class="form-group col-md-6">
                <label for="modelo">Modelo</label>
                <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="model.modelo" />
            </div>
            <div class="form-group col-md-6">
                <label for="fabricante">Fabricante</label>
                <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="model.fabricante" />
            </div>
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('unidadeMedidaId') }">
                <label for="unidadeMedidaId">Unidade de Medida</label>
                <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('categoriaEstoqueId') }">
                <label for="categoriaEstoqueId">Categoria de Estoque</label>
                <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-12">
                <label for="observacao">Observação</label>
                <textarea class="form-control" name="observacao" placeholder="Observação" v-model="model.observacao" />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <textarea class="form-control" name="descricao" placeholder="Descrição" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-4" v-bind:class="{ 'has-danger': errors.has('quantidadeMinima') }">
                <label for="quantidadeMinima">Quantidade Mínim</label>
                <input type="number" class="form-control" name="quantidadeMinima" placeholder="Quantidade Mínima" v-model="model.quantidadeMinima" v-validate="'required'" />
            </div>
            <div class="form-group col-md-4">
                <label for="valorVenda">Valor de Venda</label>
                <input type="text" class="form-control" name="valorVenda" v-mask-decimal="2" placeholder="Valor de Venda" v-model="model.valorVenda" />
            </div>
            <div class="form-group col-md-4">
                <label for="valorCompra">Valor de Compra</label>
                <input type="text" class="form-control" name="valorCompra" v-mask-decimal="2" placeholder="Valor de Compra" v-model="model.valorCompra" />
            </div>
            <div class="form-group col-md-12">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.ativo">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Ativo?</span>
                </label>
            </div>

        </div>
    </fieldset>
</template>
<script>
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
    }
</script>