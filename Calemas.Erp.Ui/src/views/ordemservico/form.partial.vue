<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="ordemServicoId" v-model="model.ordemServicoId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('protoco') }">
                        <label for="protoco">Protoco</label>
                        <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="model.protoco" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('responsavelId') }">
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('clienteId') }">
                        <label for="clienteId">ClienteId</label>
                        <input type="text" class="form-control" name="clienteId" placeholder="ClienteId" v-model="model.clienteId" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('prioridadeId') }">
                        <label for="prioridadeId">Prioridade</label>
                        <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="model.prioridadeId" class="form-control" name="prioridadeId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('setorId') }">
                        <label for="setorId">Setor</label>
                        <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="model.setorId" class="form-control" name="setorId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('tipoOrdemServicoId') }">
                        <label for="tipoOrdemServicoId">TipoOrdemServico</label>
                        <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="model.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" v-validate="'required'"></select>
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('agendaId') }">
                        <label for="agendaId">AgendaId</label>
                        <input type="text" class="form-control" name="agendaId" placeholder="AgendaId" v-model="model.agendaId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('statusOrdemServicoId') }">
                        <label for="statusOrdemServicoId">StatusOrdemServicoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoId" placeholder="StatusOrdemServicoId" v-model="model.statusOrdemServicoId" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataOcorrencia') }">
                        <label for="dataOcorrencia">DataOcorrencia</label>
                        <input type="date" class="form-control" name="dataOcorrencia" v-model="model.dataOcorrencia" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataSituacao') }">
                        <label for="dataSituacao">DataSituacao</label>
                        <input type="date" class="form-control" name="dataSituacao" v-model="model.dataSituacao" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="model.observacao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao"  />
                    </div>

        </div>
    </fieldset>
</template>
<script>
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],        
    }
</script>