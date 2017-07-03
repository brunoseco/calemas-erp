<template>
    <modal title="Exclusão de Mídia" v-model="crud.delete.modalIsOpen" :danger="true" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Exclusão de Colaborador</h4>
        </div>
        <form type="post" v-on:submit="crud.delete.executeAction()">
            <div class="row">
                <div class="form-group col-md-6">
                    <label class="label">Nome</label>
                    <p>{{crud.delete.model.pessoa.nome}}</p>
                </div>
            </div>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.delete.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-danger" @click="crud.delete.executeAction()">
                <i class="fa fa-trash-o"></i> Remover
            </button>
        </div>
    </modal>
</template>
<script>
    import modal from 'vue-strap/src/Modal'
    export default {
        name: 'delete-partial',
        props: ['crud'],
        components: { modal },
        mounted() {
            this.crud.delete.setVm(this);
        }
    }
</script>
