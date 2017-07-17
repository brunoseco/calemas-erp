<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Filtros</strong>
                    </div>
                    <div class="card-block">
                        <form v-on:submit.prevent="crud.filter.executeAction()">
                            <div class="row">
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.protoco') }">
                        <label for="protoco">Protoco</label>
                        <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="crud.filter.model.protoco"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.responsavelId') }">
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="crud.filter.model.responsavelId" class="form-control" name="responsavelId" ></select>
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.clienteId') }">
                        <label for="clienteId">ClienteId</label>
                        <input type="text" class="form-control" name="clienteId" placeholder="ClienteId" v-model="crud.filter.model.clienteId"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.prioridadeId') }">
                        <label for="prioridadeId">Prioridade</label>
                        <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="crud.filter.model.prioridadeId" class="form-control" name="prioridadeId" ></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.setorId') }">
                        <label for="setorId">Setor</label>
                        <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="crud.filter.model.setorId" class="form-control" name="setorId" ></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.tipoOrdemServicoId') }">
                        <label for="tipoOrdemServicoId">TipoOrdemServico</label>
                        <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="crud.filter.model.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" ></select>
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.agendaId') }">
                        <label for="agendaId">AgendaId</label>
                        <input type="text" class="form-control" name="agendaId" placeholder="AgendaId" v-model="crud.filter.model.agendaId"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.statusOrdemServicoId') }">
                        <label for="statusOrdemServicoId">StatusOrdemServicoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoId" placeholder="StatusOrdemServicoId" v-model="crud.filter.model.statusOrdemServicoId"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.dataOcorrencia') }">
                        <label for="dataOcorrencia">DataOcorrencia</label>
                        <input type="date" class="form-control" name="dataOcorrencia" v-model="crud.filter.model.dataOcorrencia"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.dataSituacao') }">
                        <label for="dataSituacao">DataSituacao</label>
                        <input type="date" class="form-control" name="dataSituacao" v-model="crud.filter.model.dataSituacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.observacao') }">
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="crud.filter.model.observacao"  />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.filter.model.descricao"  />
                    </div>

                            </div>
                        </form>
                    </div>
                    <div class="card-footer text-right">
                        <button type="submit" class="btn btn-primary" @click="crud.filter.executeAction()">
                            <i class="fa fa-search"></i> Filtrar
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['crud']
    }
</script>