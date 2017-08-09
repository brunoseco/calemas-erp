<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="colaboradorId" v-model="model.colaboradorId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('account') }">
                        <label for="account">Account</label>
                        <input type="text" class="form-control" name="account" placeholder="Account" v-model="model.account" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('password') }">
                        <label for="password">Password</label>
                        <input type="text" class="form-control" name="password" placeholder="Password" v-model="model.password" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('nivelAcessoId') }">
                        <label for="nivelAcessoId">NivelAcesso</label>
                        <select v-select="{ dataitem: 'NivelAcesso', default: 'Selecione' }" v-model="model.nivelAcessoId" class="form-control" name="nivelAcessoId" v-validate="'required'"></select>
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