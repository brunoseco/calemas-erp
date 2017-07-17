<template>
    <modal title="Cadastro de Movimentação de estoque" v-model="crud.create.modalIsOpen" effect="fade/zoom" :success="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Movimentação de estoque</h4>
        </div>
        <form data-vv-scope="form-create" v-on:submit.prevent="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="estoqueMovimentacaoId" v-model="crud.create.model.estoqueMovimentacaoId" />
                    <input type="hidden" class="form-control" name="estoqueId" v-model="crud.create.model.estoqueId" />
                    <input type="hidden" class="form-control" name="entrada" v-model="crud.create.model.entrada" />

                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="number" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.create.model.quantidade" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.responsavelId') }">
                        <label for="responsavelId">Responsável</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="crud.create.model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descrição</label>
                        <textarea type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.create.model.descricao" v-validate="'required'"></textarea>
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