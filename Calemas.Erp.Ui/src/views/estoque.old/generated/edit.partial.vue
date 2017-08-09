<template>
    <modal title="Edição de Estoque" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Estoque</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="estoqueId" v-model="crud.edit.model.estoqueId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.edit.model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.edit.model.descricao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.modelo') }">
                        <label for="modelo">Modelo</label>
                        <input type="text" class="form-control" name="modelo" placeholder="Modelo" v-model="crud.edit.model.modelo"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.fabricante') }">
                        <label for="fabricante">Fabricante</label>
                        <input type="text" class="form-control" name="fabricante" placeholder="Fabricante" v-model="crud.edit.model.fabricante"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.referencia') }">
                        <label for="referencia">Referencia</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="crud.edit.model.referencia"  />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.unidadeMedidaId') }">
                        <label for="unidadeMedidaId">UnidadeMedida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="crud.edit.model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.categoriaEstoqueId') }">
                        <label for="categoriaEstoqueId">CategoriaEstoque</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="crud.edit.model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.edit.model.observacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidadeMinima') }">
                        <label for="quantidadeMinima">QuantidadeMinima</label>
                        <input type="text" class="form-control" name="quantidadeMinima" placeholder="QuantidadeMinima" v-model="crud.edit.model.quantidadeMinima" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.edit.model.quantidade" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorVenda') }">
                        <label for="valorVenda">ValorVenda</label>
                        <input type="text" class="form-control" name="valorVenda" placeholder="ValorVenda" v-model="crud.edit.model.valorVenda"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.valorCompra') }">
                        <label for="valorCompra">ValorCompra</label>
                        <input type="text" class="form-control" name="valorCompra" placeholder="ValorCompra" v-model="crud.edit.model.valorCompra"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.ativo') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.edit.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
 
                </div>
            </fieldset>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.edit.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-primary" @click="crud.edit.executeAction()">
                <i class="fa fa-pencil"></i> Alterar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'

    export default {
        name: 'edit-partial',
        props: ['crud'],
        components: { modal },
        mounted() {
            this.crud.edit.setVm(this);
        }
    }
</script>