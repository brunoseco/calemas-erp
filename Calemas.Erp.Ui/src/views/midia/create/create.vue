<template>
    <modal title="Cadastro de Mídia" v-model="crud.create.modalIsOpen" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Mídia</h4>
        </div>
        <form type="post" v-on:submit.prevent="crud.create.executeAction()">
            <div class="row">
                <div class="form-group col-md-12">
                    <label for="Nome">Nome</label>
                    <input type="text" class="form-control" name="Nome" placeholder="Nome" v-model="crud.create.model.Nome">
                </div>
                <div class="form-group col-md-12">
                    <label class="custom-control custom-checkbox">
                        <input type="checkbox" name="Ativo" class="custom-control-input" v-model="crud.create.model.Ativo">
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description"> Ativo?</span>
                    </label>
                </div>
            </div>
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
        name: 'create',
        props: ['crud'],
        components: { modal },
        mounted() {
            console.log(this.crud)
        }
    }
</script>
