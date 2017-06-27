<template>
    <modal title="Cadastro de Mídia" v-model="crud.create.modalIsOpen" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Colaborador</h4>
        </div>
        <form data-vv-scope="form-create" @submit.prevent="crud.create.executeAction()">
            <div class="row" v-show="formErrors.any('form-create') && crud.config.create.showAlertMessage">
                <div class="col-md-12">
                    <div class="alert alert-danger" role="alert">
                        <strong>Ops!</strong> {{ crud.config.create.alertMessage }}
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                    <label for="nome">Nome</label>
                    <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.pessoa.nome" v-validate="'required'" />
                    <small v-show="formErrors.has('form-create.nome') && crud.config.create.showFieldErrorMessage" class="help is-danger">Desculpe, este campo é obrigatório.</small>
                </div>
                <div class="form-group col-md-6">
                    <label for="apelido">Apelido</label>
                    <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="crud.create.model.pessoa.apelido">
                </div>
                <div class="form-group col-md-6">
                    <label for="account">Acesso</label>
                    <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="crud.create.model.account">
                </div>
                <div class="form-group col-md-6">
                    <label for="password">Senha</label>
                    <input type="password" class="form-control" name="password" placeholder="Senha" v-model="crud.create.model.password">
                </div>
                <div class="form-group col-md-6">
                    <label for="cPF_CNPJ">CPF</label>
                    <input type="text" class="form-control" name="cPF_CNPJ" placeholder="CPF" v-model="crud.create.model.pessoa.cPF_CNPJ">
                </div>
                <div class="form-group col-md-6">
                    <label for="rG_IE">RG</label>
                    <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="crud.create.model.pessoa.rG_IE">
                </div>
                <div class="form-group col-md-12">
                    <label for="email">Email</label>
                    <input type="text" class="form-control" name="email" placeholder="Email" v-model="crud.create.model.pessoa.email">
                </div>
                <div class="form-group col-md-6">
                    <label for="telefone">Telefone</label>
                    <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="crud.create.model.pessoa.telefone">
                </div>
                <div class="form-group col-md-6">
                    <label for="celular">Celular</label>
                    <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="crud.create.model.pessoa.celular">
                </div>
                <div class="form-group col-md-12">
                    <label class="custom-control custom-checkbox">
                        <input type="checkbox" name="Ativo" class="custom-control-input" v-model="crud.create.model.Ativo">
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description"> Ativo?</span>
                    </label>
                </div>
            </div>
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
    export default {
        name: 'create',
        props: ['crud'],
        components: { modal }
    }
</script>
