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
                    <div class="form-group col-md-9" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-create.referencia') }">
                        <label for="referencia">Referência</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="crud.create.model.referencia" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.unidadeMedidaId') }">
                        <label for="unidadeMedidaId">Unidade de Medida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="crud.create.model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.categoriaEstoqueId') }">
                        <label for="categoriaEstoqueId">Categoria</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="crud.create.model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descrição</label>
                        <textarea class="form-control" name="descricao" placeholder="Descrição" v-model="crud.create.model.descricao"></textarea>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observação</label>
                        <textarea class="form-control" name="observacao" placeholder="Observação" v-model="crud.create.model.observacao"></textarea>
                    </div>
					<div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidadeMinima') }">
                        <label for="quantidadeMinima">Quantidade Mínima</label>
                        <input type="text" class="form-control" name="quantidadeMinima" placeholder="Quantidade Mínima" v-model="crud.create.model.quantidadeMinima" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorVenda') }">
                        <label for="valorVenda">Valor de Venda</label>
                        <input type="text" class="form-control" name="valorVenda" placeholder="Valor de Venda" v-model="crud.create.model.valorVenda"  />
                    </div>
					<div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorCompra') }">
                        <label for="valorCompra">Valor de Compra</label>
                        <input type="text" class="form-control" name="valorCompra" placeholder="Valor de Compra" v-model="crud.create.model.valorCompra"  />
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