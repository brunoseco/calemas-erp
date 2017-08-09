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
                    <div class="form-group col-md-9" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.edit.model.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-edit.referencia') }">
                        <label for="referencia">Referência</label>
                        <input type="text" class="form-control" name="referencia" placeholder="Referencia" v-model="crud.edit.model.referencia" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.unidadeMedidaId') }">
                        <label for="unidadeMedidaId">Unidade de Medida</label>
                        <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="crud.edit.model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.categoriaEstoqueId') }">
                        <label for="categoriaEstoqueId">Categoria</label>
                        <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="crud.edit.model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.descricao') }">
                        <label for="descricao">Descrição</label>
                        <textarea class="form-control" name="descricao" placeholder="Descrição" v-model="crud.edit.model.descricao"></textarea>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.observacao') }">
                        <label for="observacao">Observação</label>
                        <textarea class="form-control" name="observacao" placeholder="Observação" v-model="crud.edit.model.observacao"></textarea>
                    </div>
                    <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-edit.quantidadeMinima') }">
                        <label for="quantidadeMinima">Quantidade Mínima</label>
                        <input type="number" class="form-control" name="quantidadeMinima" placeholder="Quantidade Mínima" v-model="crud.edit.model.quantidadeMinima" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-edit.valorVenda') }">
                        <label for="valorVenda">Valor de Venda</label>
                        <input type="number" class="form-control" name="valorVenda" placeholder="Valor de Venda" v-model="crud.edit.model.valorVenda" />
                    </div>
                    <div class="form-group col-md-3" v-bind:class="{ 'has-danger': formErrors.has('form-edit.valorCompra') }">
                        <label for="valorCompra">Valor de Compra</label>
                        <input type="number" class="form-control" name="valorCompra" placeholder="Valor de Compra" v-model="crud.edit.model.valorCompra" />
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