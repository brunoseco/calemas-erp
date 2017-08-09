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
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.filter.model.nome"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.filter.model.descricao"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.modelo') }">
                        <label for="modelo">Modelo</label>
                        <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="crud.filter.model.modelo"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.fabricante') }">
                        <label for="fabricante">Fabricante</label>
                        <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="crud.filter.model.fabricante"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.referencia') }">
                        <label for="referencia">Referencia</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="crud.filter.model.referencia"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.unidadeMedidaId') }">
                        <label for="unidadeMedidaId">UnidadeMedida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="crud.filter.model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" ></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.categoriaEstoqueId') }">
                        <label for="categoriaEstoqueId">CategoriaEstoque</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="crud.filter.model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" ></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.filter.model.observacao"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidadeMinima') }">
                        <label for="quantidadeMinima">QuantidadeMinima</label>
                        <input type="text" class="form-control" name="quantidadeMinima" placeholder="QuantidadeMinima" v-model="crud.filter.model.quantidadeMinima"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.filter.model.quantidade"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorVenda') }">
                        <label for="valorVenda">ValorVenda</label>
                        <input type="text" class="form-control" name="valorVenda" placeholder="ValorVenda" v-model="crud.filter.model.valorVenda"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorCompra') }">
                        <label for="valorCompra">ValorCompra</label>
                        <input type="text" class="form-control" name="valorCompra" placeholder="ValorCompra" v-model="crud.filter.model.valorCompra"  />
                    </div>
				<div class="form-group col-md-6">
                    <label>Ativo</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="false" class="custom-control-input">
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