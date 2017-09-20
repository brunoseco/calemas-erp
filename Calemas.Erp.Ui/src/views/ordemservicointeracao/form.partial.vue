<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="ordemServicoInteracaoId" v-model="model.ordemServicoInteracaoId" />

                    <div class="form-group col-md-12" data-reference="ordemServicoId">
                        <label for="ordemServicoId">OrdemServico</label>
                        <select v-select="{ dataitem: 'OrdemServico', default: 'Selecione' }" v-model="model.ordemServicoId" class="form-control" name="ordemServicoId" required></select>
                    </div>
					<div class="form-group col-md-12" data-reference="dataConclusao">
                        <label for="dataConclusao">DataConclusao</label>
                        <input type="date" class="form-control" name="dataConclusao" v-model="model.dataConclusao" required />
                    </div>
					<div class="form-group col-md-12" data-reference="descricao">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" required />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="model.observacao"  />
                    </div>
					<div class="form-group col-md-12">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="foiProprioCliente" class="custom-control-input" v-model="model.foiProprioCliente">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> FoiProprioCliente?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="nomeClienteResponsavel">NomeClienteResponsavel</label>
                        <input type="text" class="form-control" name="nomeClienteResponsavel" placeholder="NomeClienteResponsavel" v-model="model.nomeClienteResponsavel"  />
                    </div>
                    <div class="form-group col-md-12" data-reference="tecnicoId">
                        <label for="tecnicoId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.tecnicoId" class="form-control" name="tecnicoId" required></select>
                    </div>
					<div class="form-group col-md-12" data-reference="statusOrdemServicoInteracaoId">
                        <label for="statusOrdemServicoInteracaoId">StatusOrdemServicoInteracaoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoInteracaoId" placeholder="StatusOrdemServicoInteracaoId" v-model="model.statusOrdemServicoInteracaoId" required />
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