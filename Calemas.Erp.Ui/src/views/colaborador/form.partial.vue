<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('nome') }">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.pessoa.nome" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('apelido') }">
                <label for="apelido">Apelido</label>
                <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="model.pessoa.apelido" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('cPF_CNPJ') }">
                <label for="cPF_CNPJ">CPF</label>
                <input type="text" class="form-control" name="cPF_CNPJ" placeholder="CPF" v-model="model.pessoa.cPF_CNPJ" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('rG_IE') }">
                <label for="rG_IE">RG</label>
                <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="model.pessoa.rG_IE" v-validate="'required'" />
            </div>
            <div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('email') }">
                <label for="email">Email</label>
                <input type="text" class="form-control" name="email" placeholder="Email" v-model="model.pessoa.email" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('telefone') }">
                <label for="telefone">Telefone</label>
                <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="model.pessoa.telefone" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('celular') }">
                <label for="celular">Celular</label>
                <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="model.pessoa.celular" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('dataNascimento') }">
                <label for="dataNascimento">Data de Nascimento</label>
                <input type="date" class="form-control" name="dataNascimento" placeholder="Data" v-model="model.pessoa.dataNascimento" v-validate="'required'" />
            </div>
        </div>
        <legend>Acesso</legend>
        <div class="row">
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('nivelAcessoId') }">
                <label for="nivelAcessoId">Nível de acesso</label>
                <select v-select="{ dataitem: 'nivelacesso', default: 'Selecione' }" v-model="model.nivelAcessoId" class="form-control" name="nivelAcessoId" v-validate="'required'"></select>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('ativo') }">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.ativo">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Ativo?</span>
                </label>
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('account') }">
                <label for="account">Conta</label>
                <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="model.account" v-validate="'required'" />
            </div>
            <div class="form-group col-md-6" v-bind:class="{ 'has-danger': errors.has('password') }">
                <label for="password">Senha</label>
                <input type="password" class="form-control" name="password" placeholder="Senha" v-model="model.password" v-validate="'required'" />
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