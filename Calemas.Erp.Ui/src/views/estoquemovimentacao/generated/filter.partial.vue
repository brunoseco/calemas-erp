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
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.estoqueId') }">
                        <label for="estoqueId">Estoque</label>
                        <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="crud.filter.model.estoqueId" class="form-control" name="estoqueId" ></select>
                    </div>
				<div class="form-group col-md-6">
                    <label>Entrada</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="crud.filter.model.entrada" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="crud.filter.model.entrada" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="crud.filter.model.entrada" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.descricao') }">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="crud.filter.model.descricao"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.quantidade') }">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" placeholder="Quantidade" v-model="crud.filter.model.quantidade"  />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.responsavelId') }">
                        <label for="responsavelId">Colaborador</label>
                        <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="crud.filter.model.responsavelId" class="form-control" name="responsavelId" ></select>
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