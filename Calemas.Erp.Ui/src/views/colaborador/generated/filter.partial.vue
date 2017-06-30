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
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.account') }">
                        <label for="account">Account</label>
                        <input type="text" class="form-control" name="account" placeholder="Account" v-model="crud.filter.model.account"  />
                    </div>
					<div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.password') }">
                        <label for="password">Password</label>
                        <input type="text" class="form-control" name="password" placeholder="Password" v-model="crud.filter.model.password"  />
                    </div>
				<div class="form-group col-md-6">
                    <label>Ativo</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="crud.filter.model.ativo" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-filter.nivelAcessoId') }">
                        <label for="nivelAcessoId">NivelAcesso</label>
                        <select v-select="{ dataitem: 'NivelAcesso', default: 'Selecione' }" v-model="crud.filter.model.nivelAcessoId" class="form-control" name="nivelAcessoId" ></select>
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