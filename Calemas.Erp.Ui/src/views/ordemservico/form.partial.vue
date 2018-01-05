<template>
    <fieldset>
        <legend>Dados Básicos</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="ordemServicoId" v-model="model.ordemServicoId" />

            <div class="form-group col-md-4" data-reference="protoco">
                <label for="protoco">Protocolo</label>
                <input type="text" class="form-control" name="protoco" placeholder="Protocolo" v-model="model.protoco" required />
            </div>
            <div class="form-group col-md-8" data-reference="clienteId">
                <label for="clienteId">Cliente</label>
                <select v-select="{ dataitem: 'Cliente', default: 'Selecione' }" v-model="model.clienteId" class="form-control" name="clienteId" required></select>
            </div>
            <div class="form-group col-md-12" data-reference="tipoOrdemServicoId">
                <label for="tipoOrdemServicoId">Tipo do Serviço</label>
                <select v-select="{ dataitem: 'TipoOrdemServico', default: 'Selecione' }" v-model="model.tipoOrdemServicoId" class="form-control" name="tipoOrdemServicoId" required></select>
            </div>
            <div class="form-group col-md-6" data-reference="dataOcorrencia">
                <label for="dataOcorrencia">Data da Ocorrência</label>
                <input type="datetime-local" class="form-control" name="dataOcorrencia" v-model="model.dataOcorrencia" required />
            </div>
            <div class="form-group col-md-6" data-reference="prioridadeId">
                <label for="prioridadeId">Prioridade</label>
                <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="model.prioridadeId" class="form-control" name="prioridadeId" required></select>
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
        <legend>Informações para Realização</legend>
        <div class="row">
            <div class="form-group col-md-12" data-reference="responsavelIds">
                <label for="responsavelIds">Técnico responsável <small>precisone ctrl para selecionar vários</small></label>
                <select v-select="{ dataitem: 'Colaborador' }" multiple v-model="model.responsavelIds" class="form-control" name="responsavelIds" required></select>
            </div>
            <div class="form-group col-md-12" data-reference="dataInicio">
                <label for="dataInicio">Data prevista de realização</label>
                <input type="datetime-local" class="form-control" name="dataInicio" v-model="model.agenda.dataInicio" required />
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
        mounted() {

        }

    }
</script>
