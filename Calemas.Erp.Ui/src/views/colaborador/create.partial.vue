<template>
    <modal title="Cadastro de Mídia" v-model="crud.create.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Colaborador</h4>
        </div>
        <form data-vv-scope="form-create" v-on:submit="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.pessoa.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.apelido') }">
                        <label for="apelido">Apelido</label>
                        <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="crud.create.model.pessoa.apelido" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.cPF_CNPJ') }">
                        <label for="cPF_CNPJ">CPF</label>
                        <input type="text" class="form-control" name="cPF_CNPJ" placeholder="CPF" v-model="crud.create.model.pessoa.cPF_CNPJ" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.rG_IE') }">
                        <label for="rG_IE">RG</label>
                        <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="crud.create.model.pessoa.rG_IE" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-create.email') }">
                        <label for="email">Email</label>
                        <input type="text" class="form-control" name="email" placeholder="Email" v-model="crud.create.model.pessoa.email" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.telefone') }">
                        <label for="telefone">Telefone</label>
                        <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="crud.create.model.pessoa.telefone" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.celular') }">
                        <label for="celular">Celular</label>
                        <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="crud.create.model.pessoa.celular" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.dataNascimento') }">
                        <label for="dataNascimento">Data de Nascimento</label>
                        <input type="date" class="form-control" name="dataNascimento" placeholder="Data" v-model="crud.create.model.pessoa.dataNascimento" v-validate="'required'" />
                    </div>
                </div>
                <legend>Acesso</legend>
                <div class="row">
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.nivelAcessoId') }">
                        <label for="nivelAcessoId">Nível de acesso</label>
                        <select v-select="{ dataitem: 'nivelacesso', default: 'Selecione' }" v-model="crud.create.model.nivelAcessoId" class="form-control" name="nivelAcessoId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.ativo') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.create.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.account') }">
                        <label for="account">Conta</label>
                        <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="crud.create.model.account" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.password') }">
                        <label for="password">Senha</label>
                        <input type="password" class="form-control" name="password" placeholder="Senha" v-model="crud.create.model.password" v-validate="'required'" />
                    </div>
                </div>
            </fieldset>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.create.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-success" @click="crud.create.executeAction()">
                <i class="fa fa-check"></i> Salvar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'
    import select from '../../common/select'

    export default {
        name: 'create-partial',
        props: ['crud'],
        components: {
            modal,
            //makeSelect
        },
        mounted() {
            this.crud.create.setVm(this);
        }

    }
</script>
