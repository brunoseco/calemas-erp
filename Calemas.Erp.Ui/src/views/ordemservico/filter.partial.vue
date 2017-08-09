<template>
    <div class="row">
        					<div class="form-group col-md-12" >
                        <label for="protoco">Protoco</label>
                        <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="filter.protoco"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.responsavelId" class="form-control" name="responsavelId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="clienteId">ClienteId</label>
                        <input type="text" class="form-control" name="clienteId" placeholder="ClienteId" v-model="filter.clienteId"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="prioridadeId">Prioridade</label>
                        <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="filter.prioridadeId" class="form-control" name="prioridadeId" ></select>
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="setorId">Setor</label>
                        <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="filter.setorId" class="form-control" name="setorId" ></select>
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="tipoOrdemServicoId">TipoOrdemServico</label>
                        <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="filter.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="agendaId">AgendaId</label>
                        <input type="text" class="form-control" name="agendaId" placeholder="AgendaId" v-model="filter.agendaId"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="statusOrdemServicoId">StatusOrdemServicoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoId" placeholder="StatusOrdemServicoId" v-model="filter.statusOrdemServicoId"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="dataOcorrencia">DataOcorrencia</label>
                        <input type="date" class="form-control" name="dataOcorrencia" v-model="filter.dataOcorrencia"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="dataSituacao">DataSituacao</label>
                        <input type="date" class="form-control" name="dataSituacao" v-model="filter.dataSituacao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="filter.observacao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>