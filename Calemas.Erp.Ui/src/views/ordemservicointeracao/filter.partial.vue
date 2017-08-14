<template>
    <div class="row">
                            <div class="form-group col-md-12" >
                        <label for="ordemServicoId">OrdemServico</label>
                        <select v-select="{ dataitem: 'OrdemServico', default: 'Selecione' }" v-model="filter.ordemServicoId" class="form-control" name="ordemServicoId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="dataConclusao">DataConclusao</label>
                        <input type="date" class="form-control" name="dataConclusao" v-model="filter.dataConclusao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="observacao">Observacao</label>
                        <input type="text" class="form-control" name="observacao" placeholder="Observacao" v-model="filter.observacao"  />
                    </div>
				<div class="form-group col-md-12">
                    <label>FoiProprioCliente</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="foiProprioCliente" v-model="filter.foiProprioCliente" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="foiProprioCliente" v-model="filter.foiProprioCliente" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="foiProprioCliente" v-model="filter.foiProprioCliente" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-12" >
                        <label for="nomeClienteResponsavel">NomeClienteResponsavel</label>
                        <input type="text" class="form-control" name="nomeClienteResponsavel" placeholder="NomeClienteResponsavel" v-model="filter.nomeClienteResponsavel"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="tecnicoId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="filter.tecnicoId" class="form-control" name="tecnicoId" ></select>
                    </div>
					<div class="form-group col-md-12" >
                        <label for="statusOrdemServicoInteracaoId">StatusOrdemServicoInteracaoId</label>
                        <input type="text" class="form-control" name="statusOrdemServicoInteracaoId" placeholder="StatusOrdemServicoInteracaoId" v-model="filter.statusOrdemServicoInteracaoId"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>