<template>
    <modal title="Cadastro de Mídia" v-model="crud.create.modalIsOpen" effect="fade/zoom">
        <div slot="modal-header" class="modal-header">
            <h4 class="modal-title">Cadastro de Colaborador</h4>
        </div>
        <form data-vv-scope="form-create" @submit.prevent="crud.create.executeAction()">
            <fieldset>
                <legend>Dados</legend>
                <div class="row">
                    <div class="form-group col-md-6" v-bind:class="{ 'has-danger': formErrors.has('form-create.nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="crud.create.model.pessoa.nome" v-validate="'required'" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="apelido">Apelido</label>
                        <input type="text" class="form-control" name="apelido" placeholder="Apelido" v-model="crud.create.model.pessoa.apelido">
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
                    <div class="form-group col-md-6">
                        <label for="dataNascimento">Data de Nascimento</label>
                        <datepicker v-model="crud.create.model.pessoa.dataNascimento" icons-font="fa" format="dd/MM/yyyy" placeholder="__/__/____"></datepicker>

                    </div>
                </div>
                <legend>Acesso</legend>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="nivelAcessoId">Nível de acesso</label>
                        <make-select v-model="crud.create.model.nivelAcessoId" name="nivelAcessoId" data-item="nivelacesso"></make-select>
                    </div>
                    <div class="form-group col-md-6">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="ativo" class="custom-control-input" v-model="crud.create.model.ativo">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Ativo?</span>
                        </label>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="account">Conta</label>
                        <input type="text" class="form-control" name="account" placeholder="Acesso" v-model="crud.create.model.account">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="password">Senha</label>
                        <input type="password" class="form-control" name="password" placeholder="Senha" v-model="crud.create.model.password">
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
    import makeSelect from '../../common/select'
    import Datepicker from 'vue-strap/src/Datepicker'

    export default {
        name: 'create-partial',
        props: ['crud'],
        components: { modal, makeSelect, Datepicker },
        data: function () {
            return {
                datee: '10/09/2015',
                placeholder: '__/__/____',
            }
        },
        mounted() {
            this.crud.create.setVm(this);
        }

    }
</script>
