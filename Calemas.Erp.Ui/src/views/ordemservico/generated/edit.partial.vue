<template>
    <modal title="Edição de Ordem de serviço" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Ordem de serviço</h4>
        </div>
        <form data-vv-scope="form-edit" v-on:submit.prevent="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="ordemServicoId" v-model="crud.edit.model.ordemServicoId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.protoco') }">
                        <label for="protoco">Protoco</label>
                        <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="crud.edit.model.protoco" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.clienteId') }">
                        <label for="clienteId">ClienteId</label>
                        <input type="text" class="form-control" name="clienteId" placeholder="ClienteId" v-model="crud.edit.model.clienteId" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.prioridadeId') }">
                        <label for="prioridadeId">Prioridade</label>
                        <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="crud.edit.model.prioridadeId" class="form-control" name="prioridadeId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.setorId') }">
                        <label for="setorId">Setor</label>
                        <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="crud.edit.model.setorId" class="form-control" name="setorId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.tipoOrdemServicoId') }">
                        <label for="tipoOrdemServicoId">TipoOrdemServico</label>
                        <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="crud.edit.model.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.agendaId') }">
                        <label for="agendaId">AgendaId</label>
                        <input type="text" class="form-control" name="agendaId" placeholder="AgendaId" v-model="crud.edit.model.agendaId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.statusOrdemServicoId') }">
                        <label for="statusOrdemServicoId">StatusOrdemServicoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoId" placeholder="StatusOrdemServicoId" v-model="crud.edit.model.statusOrdemServicoId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.dataSituacao') }">
                        <label for="dataSituacao">DataSituacao</label>
                        <input type="date" class="form-control" name="dataSituacao" v-model="crud.edit.model.dataSituacao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.edit.model.observacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.edit.model.descricao"  />
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