<template>
    <fieldset>
        <legend>Básico</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="ordemServicoId" v-model="model.ordemServicoId" />

            <div class="form-group col-md-4" v-bind:class="{ 'has-danger': errors.has('protoco') }">
                <label for="protoco">Protoco</label>
                <input type="text" class="form-control" name="protoco" placeholder="Protoco" v-model="model.protoco" v-validate="'required'" />
            </div>
            <div class="form-group col-md-8" v-bind:class="{ 'has-danger': errors.has('clienteId') }">
                <label for="clienteId">Cliente</label>
                <select v-select="{ dataitem: 'Cliente', default: 'Selecione' }" v-model="model.clienteId" class="form-control" name="clienteId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('setorId') }">
                <label for="setorId">Setor</label>
                <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="model.setorId" class="form-control" name="setorId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('tipoOrdemServicoId') }">
                <label for="tipoOrdemServicoId">Tipo da O.S</label>
                <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="model.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('dataOcorrencia') }">
                <label for="dataOcorrencia">Data da Ocorrência</label>
                <input type="date" class="form-control" name="dataOcorrencia" v-model="model.dataOcorrencia" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('prioridadeId') }">
                <label for="prioridadeId">Prioridade</label>
                <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="model.prioridadeId" class="form-control" name="prioridadeId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <textarea class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="observacao">Observação</label>
                <textarea class="form-control" name="observacao" placeholder="Observacao" v-model="model.observacao" />
            </div>
        </div>
        <legend>Realização</legend>
        <div class="row">
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('responsavelId') }">
                <label for="responsavelId">Técnico</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataInicio') }">
                <label for="dataInicio">Data prevista de realização</label>
                <input type="datetime-local" class="form-control" name="dataInicio" v-model="model.agenda.dataInicio" v-validate="'required'" />
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