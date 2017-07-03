<template>
    <modal title="Edição de Colaborador do sistema" v-model="crud.edit.modalIsOpen" effect="fade/zoom" :primary="true" :large="true">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Edição de Colaborador</h4>
        </div>

        <form data-vv-scope="form-edit" v-on:submit="crud.edit.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.edit.model.pessoa.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.apelido') }">
                        <label for="apelido">Apelido</label>
                        <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="crud.edit.model.pessoa.apelido" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.cPF_CNPJ') }">
                        <label for="cPF_CNPJ">CPF</label>
                        <input type="text" class="form-control" name="cpF_CNPJ" placeholder="CPF" v-model="crud.edit.model.pessoa.cpF_CNPJ" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.rG_IE') }">
                        <label for="rG_IE">RG</label>
                        <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="crud.edit.model.pessoa.rG_IE" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-12" v-bind:class="{ 'has-danger': formErrors.has('form-edit.email') }">
                        <label for="email">Email</label>
                        <input type="text" class="form-control" name="email" placeholder="Email" v-model="crud.edit.model.pessoa.email" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.telefone') }">
                        <label for="telefone">Telefone</label>
                        <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="crud.edit.model.pessoa.telefone" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.celular') }">
                        <label for="celular">Celular</label>
                        <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="crud.edit.model.pessoa.celular" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.dataNascimento') }">
                        <label for="dataNascimento">Data de Nascimento</label>
                        <input type="date" class="form-control"  name="dataNascimento" placeholder="Data" v-model.date="crud.edit.model.pessoa.dataNascimento" v-validate="'required'" />
                    </div>
                </div>
                <legend>Acesso</legend>
                <div class="row">
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nivelAcessoId') }">
                        <label for="nivelAcessoId">Nível de acesso</label>
                        <select v-select="{ dataitem: 'nivelacesso', default: 'Selecione' }" v-model="crud.edit.model.nivelAcessoId" class="form-control" name="nivelAcessoId" v-validate="'required'"></select>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.ativo') }">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.edit.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.account') }">
                        <label for="account">Conta</label>
                        <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="crud.edit.model.account" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.password') }">
                        <label for="password">Senha</label>
                        <input type="password" class="form-control" name="password" placeholder="Senha" v-model="crud.edit.model.password" v-validate="'required'" />
                    </div>
                </div>
            </fieldset>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.edit.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-primary" @click="crud.edit.executeAction()">
                <i class="fa fa-pencil"></i> Alterar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'
    export default {
        name: 'edit-partial',
        props: ['crud'],
        components: { modal },
        mounted() {
            this.crud.edit.setVm(this);
        }
    }
</script>
