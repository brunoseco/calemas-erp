<template>
    <div class="row">
        <div class="form-group col-md-4">
            <label for="protoco">Protocolo</label>
            <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="filter.protoco" />
        </div>
        <div class="form-group col-md-8">
            <label for="clienteId">Cliente</label>
            <select v-select="{ dataitem: 'Cliente', default: 'Selecione' }" v-model="filter.clienteId" class="form-control" name="clienteId"></select>
        </div>
        <div class="form-group col-md-4">
            <label for="setorId">Setor</label>
            <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="filter.setorId" class="form-control" name="setorId"></select>
        </div>
        <div class="form-group col-md-4">
            <label for="prioridadeId">Prioridade</label>
            <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="filter.prioridadeId" class="form-control" name="prioridadeId"></select>
        </div>
        <div class="form-group col-md-4">
            <label for="statusOrdemServicoId">Situação</label>
            <select v-select="{ dataitem: 'StatusOrdemServico', default: 'Selecione' }" v-model="filter.statusOrdemServicoId" class="form-control" name="statusOrdemServicoId"></select>
        </div>
        <div class="form-group col-md-4">
            <label for="tipoOrdemServicoId">Tipo do Serviço</label>
            <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="filter.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId"></select>
        </div>
        <div class="form-group col-md-8">
            <label for="responsavelId">Responsável</label>
            <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.responsavelId" class="form-control" name="responsavelId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
