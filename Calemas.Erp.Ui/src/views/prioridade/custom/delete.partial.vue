<template>
    <modal title="Exclusão de Prioridade" v-model="crud.delete.modalIsOpen" :danger="true" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Exclusão de Prioridade</h4>
        </div>
        <form type="post" v-on:submit.prevent="crud.delete.executeAction()">
            <div class="row">
                <div class="form-group col-md-12">
                    <h4>Confirma a remoção deste item?</h4>
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
