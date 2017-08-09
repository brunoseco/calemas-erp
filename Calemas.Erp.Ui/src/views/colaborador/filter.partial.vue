<template>
    <div class="row">
        					<div class="form-group col-md-12" >
                        <label for="account">Account</label>
                        <input type="text" class="form-control" name="account" placeholder="Account" v-model="filter.account"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="password">Password</label>
                        <input type="text" class="form-control" name="password" placeholder="Password" v-model="filter.password"  />
                    </div>
				<div class="form-group col-md-12">
                    <label>Ativo</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
                    <div class="form-group col-md-12" >
                        <label for="nivelAcessoId">NivelAcesso</label>
                        <select v-select="{ dataitem: 'NivelAcesso', default: 'Selecione' }" v-model="filter.nivelAcessoId" class="form-control" name="nivelAcessoId" ></select>
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>