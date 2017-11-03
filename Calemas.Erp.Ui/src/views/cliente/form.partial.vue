<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="clienteId" v-model="model.clienteId" />
            <div class="form-group col-md-12" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.pessoa.nome" />
            </div>
            <div class="form-group col-md-6" data-reference="cPF_CNPJ">
                <label for="cPF_CNPJ">CPF</label>
                <input type="text" class="form-control" name="cpF_CNPJ" placeholder="CPF" v-mask="masks.cpf_cnpj" v-model="model.pessoa.cpF_CNPJ" />
            </div>
            <div class="form-group col-md-6" data-reference="rG_IE">
                <label for="rG_IE">RG</label>
                <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-mask="masks.rg" v-model="model.pessoa.rG_IE" />
            </div>
            <div class="form-group col-md-12" data-reference="email">
                <label for="email">E-mail</label>
                <input type="email" class="form-control" name="email" placeholder="Email" v-model="model.pessoa.email" />
            </div>
            <div class="form-group col-md-6" data-reference="telefone">
                <label for="telefone">Telefone</label>
                <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-mask="masks.telefone" v-model="model.pessoa.telefone" />
            </div>
            <div class="form-group col-md-6" data-reference="celular">
                <label for="celular">Celular</label>
                <input type="text" class="form-control" name="celular" placeholder="Celular" v-mask="masks.celular" v-model="model.pessoa.celular" />
            </div>
            <div class="form-group col-md-6" data-reference="dataNascimento">
                <label for="dataNascimento">Data de Nascimento</label>
                <input type="date" class="form-control" name="dataNascimento" placeholder="Data" v-model="model.pessoa.dataNascimento" />
            </div>
            <div class="form-group col-md-6" data-reference="statusClienteId">
                <label for="statusClienteId">Situação</label>
                <select v-select="{ dataitem: 'StatusCliente', default: 'Selecione' }" v-model="model.statusClienteId" class="form-control" name="statusClienteId"></select>
            </div>
        </div>

        <legend>Endereço</legend>
        <div class="row">
            <div class="form-group col-md-12">
                <label for="condominioId">Condomínio</label>
                <select @change="findAddress()" v-select="{ dataitem: 'Condominio', default: 'Selecione' }" v-model="model.condominioId" class="form-control" name="condominioId"></select>
            </div>
        </div>

        <endereco-form :model="model.pessoa.endereco" />

    </fieldset>
</template>
<script>
    import enderecoForm from '../endereco/form.partial'
    import formBase from '../../common/mixins/form'
    import { Api } from '../../common/api'

    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
        components: { enderecoForm },
        methods: {
            findAddress: function () {
                if (!this.model.condominioId)
                    return;

                var api = new Api('endereco');
                api.filters.condominioId = this.model.condominioId
                api.get().then(data => {
                    if (data.dataList.length > 0) {
                        var endereco = data.dataList[0];

                        if (this.model.pessoa == null)
                            this.model.pessoa = {};

                        if (this.model.pessoa.endereco == null)
                            this.model.pessoa.endereco = {};

                        this.model.pessoa.endereco.cep = endereco.cep;
                        this.model.pessoa.endereco.bairro = endereco.bairro;
                        this.model.pessoa.endereco.cidade = endereco.cidade;
                        this.model.pessoa.endereco.complemento = endereco.complemento;
                        this.model.pessoa.endereco.numero = endereco.numero;
                        this.model.pessoa.endereco.rua = endereco.rua;
                        this.model.pessoa.endereco.uf = endereco.uf;
                    }
                })
            }
        }
    }
</script>
