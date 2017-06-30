<template>
    <modal title="Cadastro de Ordem de serviço" v-model="crud.create.modalIsOpen" effect="fade/zoom" :success="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Ordem de serviço</h4>
        </div>
        <form data-vv-scope="form-create" v-on:submit.prevent="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <input type="hidden" class="form-control" name="ordemServicoId" v-model="crud.create.model.ordemServicoId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.protoco') }">
                        <label for="protoco">Protoco</label>
                        <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="crud.create.model.protoco" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.clienteId') }">
                        <label for="clienteId">ClienteId</label>
                        <input type="text" class="form-control" name="clienteId" placeholder="ClienteId" v-model="crud.create.model.clienteId" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nivelAcessoId') }">
                        <label for="prioridadeId">Prioridade</label>
                        <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="crud.create.model.nivelAcessoId" class="form-control" name="prioridadeId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nivelAcessoId') }">
                        <label for="setorId">Setor</label>
                        <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="crud.create.model.nivelAcessoId" class="form-control" name="setorId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.nivelAcessoId') }">
                        <label for="tipoOrdemServicoId">TipoOrdemServico</label>
                        <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="crud.create.model.nivelAcessoId" class="form-control" name="tipoOrdemServicoId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.agendaId') }">
                        <label for="agendaId">AgendaId</label>
                        <input type="text" class="form-control" name="agendaId" placeholder="AgendaId" v-model="crud.create.model.agendaId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.statusOrdemServicoId') }">
                        <label for="statusOrdemServicoId">StatusOrdemServicoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoId" placeholder="StatusOrdemServicoId" v-model="crud.create.model.statusOrdemServicoId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.dataSituacao') }">
                        <label for="dataSituacao">DataSituacao</label>
                        <input type="date" class="form-control" name="dataSituacao" v-model="crud.create.model.dataSituacao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.create.model.observacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.create.model.descricao"  />
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