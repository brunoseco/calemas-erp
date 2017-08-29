<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">

            <input type="hidden" class="form-control" name="ordemServicoInteracaoId" v-model="model.ordemServicoInteracaoId" />
            <input type="hidden" class="form-control" name="ordemServicoId" v-model="model.ordemServicoId" />

            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('dataConclusao') }">
                <label for="dataConclusao">Data de realização</label>
                <input type="datetime-local" class="form-control" name="dataConclusao" v-model="model.dataConclusao" v-validate="'required'" />
            </div>

            <div class="form-group col-md-6">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="foiProprioCliente" class="custom-control-input" v-model="model.foiProprioCliente">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Foi o próprio cliente que recebeu?</span>
                </label>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('nomeClienteResponsavel') }">
                <label for="nomeClienteResponsavel">Nome cliente/responsável pelo recebimento</label>
                <input type="text" class="form-control" name="Nome cliente/responsável pelo recebimento" placeholder="Protoco" v-model="model.nomeClienteResponsavel" />
            </div>


            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <textarea class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="observacao">Observação</label>
                <textarea class="form-control" name="observacao" placeholder="Observação" v-model="model.observacao" />
            </div>


            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('tecnicoId') }">
                <label for="tecnicoId">Técnico que realizou o atendimento</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.tecnicoId" class="form-control" name="tecnicoId" v-validate="'required'"></select>
            </div>

            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('statusOrdemServicoId') }">
                <label for="statusOrdemServicoId">Situação da O.S</label>
                <select v-select="{ dataitem: 'StatusOrdemServico', default: 'Selecione' }" v-model="model.statusOrdemServicoId" class="form-control" name="statusOrdemServicoId" v-validate="'required'"></select>
            </div>
            
        </div>
    </fieldset>
</template>
<script>
    import formBase from '../../common/mixins/form'
    export default {
        name: 'interacao-partial',
        props: ['model'],
        mixins: [formBase],
    }
</script>