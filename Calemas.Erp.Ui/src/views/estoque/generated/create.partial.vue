<template>
    <modal title="Cadastro de Estoque" v-model="crud.create.modalIsOpen" effect="fade/zoom" :success="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Estoque</h4>
        </div>
        <form data-vv-scope="form-create" v-on:submit.prevent="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="estoqueId" v-model="crud.create.model.estoqueId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.create.model.descricao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.referencia') }">
                        <label for="referencia">Referencia</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="crud.create.model.referencia"  />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.unidadeMedidaId') }">
                        <label for="unidadeMedidaId">UnidadeMedida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="crud.create.model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.categoriaEstoqueId') }">
                        <label for="categoriaEstoqueId">CategoriaEstoque</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="crud.create.model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.create.model.observacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidadeMinima') }">
                        <label for="quantidadeMinima">QuantidadeMinima</label>
                        <input type="text" class="form-control" name="quantidadeMinima" placeholder="QuantidadeMinima" v-model="crud.create.model.quantidadeMinima" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.create.model.quantidade" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorVenda') }">
                        <label for="valorVenda">ValorVenda</label>
                        <input type="text" class="form-control" name="valorVenda" placeholder="ValorVenda" v-model="crud.create.model.valorVenda"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorCompra') }">
                        <label for="valorCompra">ValorCompra</label>
                        <input type="text" class="form-control" name="valorCompra" placeholder="ValorCompra" v-model="crud.create.model.valorCompra"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.ativo') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.create.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
 
                </div>
            </fieldset>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.create.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-success" @click="crud.create.executeAction()">
                <i class="fa fa-check"></i> Salvar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'

    export default {
        name: 'create-partial',
        props: ['crud'],
        components: { modal },
        mounted() {
            this.crud.create.setVm(this);
        }
    }
</script>