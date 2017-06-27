<template>
    <modal title="Cadastro de Mídia" v-model="crud.edit.modalIsOpen" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Editar de Colaborador</h4>
        </div>
        <form type="post" data-vv-scope="form-edit" @submit.prevent="crud.edit.executeAction()">
            <div class="row" v-show="formErrors.any('form-edit') && crud.config.create.showAlertMessage">
                <div class="col-md-12">
                    <div class="alert alert-danger" role="alert">
                        <strong>Ops!</strong> {{ crud.config.create.alertMessage }}
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-edit.nome') }">
                    <label for="nome">Nome</label>
                    <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.edit.model.pessoa.nome" v-validate="'required'" />
                    <small v-show="formErrors.has('form-edit.nome') && crud.config.create.showFieldErrorMessage" class="help is-danger">Desculpe, este campo é obrigatório.</small>
                </div>
                <div class="form-group col-md-6">
                    <label for="apelido">Apelido</label>
                    <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="crud.edit.model.pessoa.apelido">
                </div>
                <div class="form-group col-md-6">
                    <label for="account">Acesso</label>
                    <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="crud.edit.model.account">
                </div>
                <div class="form-group col-md-6">
                    <label for="password">Senha</label>
                    <input type="password" class="form-control" name="password" placeholder="Senha" v-model="crud.edit.model.password">
                </div>
                <div class="form-group col-md-6">
                    <label for="cPF_CNPJ">CPF</label>
                    <input type="text" class="form-control" name="cPF_CNPJ" placeholder="CPF" v-model="crud.edit.model.pessoa.cPF_CNPJ">
                </div>
                <div class="form-group col-md-6">
                    <label for="rG_IE">RG</label>
                    <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="crud.edit.model.pessoa.rG_IE">
                </div>
                <div class="form-group col-md-12">
                    <label for="email">Email</label>
                    <input type="text" class="form-control" name="email" placeholder="Email" v-model="crud.edit.model.pessoa.email">
                </div>
                <div class="form-group col-md-6">
                    <label for="telefone">Telefone</label>
                    <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="crud.edit.model.pessoa.telefone">
                </div>
                <div class="form-group col-md-6">
                    <label for="celular">Celular</label>
                    <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="crud.edit.model.pessoa.celular">
                </div>
                <div class="form-group col-md-12">
                    <label class="custom-control custom-checkbox">
                        <input type="checkbox" name="Ativo" class="custom-control-input" v-model="crud.edit.model.Ativo">
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description"> Ativo?</span>
                    </label>
                </div>
            </div>
        </form>
        <div slot="modal-footer" class="modal-footer">
            <button type="button" class="btn btn-default" @click="crud.edit.modalIsOpen = false">Fechar</button>
            <button type="button" class="btn btn-success" @click="crud.edit.executeAction()">
                <i class="fa fa-check"></i> Salvar
            </button>
        </div>
    </modal>

</template>
<script>
    import modal from 'vue-strap/src/Modal'
    export default {
        name: 'edit',
        props: ['crud'],
        components: { modal }
    }
</script>
