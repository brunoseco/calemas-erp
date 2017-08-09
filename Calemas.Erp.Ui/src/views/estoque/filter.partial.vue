<template>
    <div class="row">
        					<div class="form-group col-md-12" >
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="modelo">Modelo</label>
                        <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="filter.modelo"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="fabricante">Fabricante</label>
                        <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="filter.fabricante"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="referencia">Referencia</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="filter.referencia"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="unidadeMedidaId">UnidadeMedida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="filter.unidadeMedidaId" class="form-control" name="unidadeMedidaId" ></select>
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="categoriaEstoqueId">CategoriaEstoque</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="filter.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="filter.observacao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="quantidadeMinima">QuantidadeMinima</label>
                        <input type="text" class="form-control" name="quantidadeMinima" placeholder="QuantidadeMinima" v-model="filter.quantidadeMinima"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="filter.quantidade"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorVenda">ValorVenda</label>
                        <input type="text" class="form-control" name="valorVenda" placeholder="ValorVenda" v-model="filter.valorVenda"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="valorCompra">ValorCompra</label>
                        <input type="text" class="form-control" name="valorCompra" placeholder="ValorCompra" v-model="filter.valorCompra"  />
                    </div>
				<div class="form-group col-md-12">
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