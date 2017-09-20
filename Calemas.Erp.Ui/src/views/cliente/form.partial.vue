<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <div class="form-group col-md-12" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.pessoa.nome" required />
            </div>
            <div class="form-group col-md-6" data-reference="cPF_CNPJ">
                <label for="cPF_CNPJ">CPF</label>
                <input type="text" class="form-control" name="cPF_CNPJ" placeholder="CPF" v-model="model.pessoa.cPF_CNPJ" />
            </div>
            <div class="form-group col-md-6" data-reference="rG_IE">
                <label for="rG_IE">RG</label>
                <input type="text" class="form-control" name="rG_IE" placeholder="RG" v-model="model.pessoa.rG_IE"/>
            </div>
            <div class="form-group col-md-12" data-reference="email">
                <label for="email">E-mail</label>
                <input type="text" class="form-control" name="email" placeholder="Email" v-model="model.pessoa.email"  />
            </div>
            <div class="form-group col-md-6" data-reference="telefone">
                <label for="telefone">Telefone</label>
                <input type="text" class="form-control" name="telefone" placeholder="Telefone" v-model="model.pessoa.telefone"  />
            </div>
            <div class="form-group col-md-6" data-reference="celular">
                <label for="celular">Celular</label>
                <input type="text" class="form-control" name="celular" placeholder="Celular" v-model="model.pessoa.celular"  />
            </div>
            <div class="form-group col-md-6" data-reference="dataNascimento">
                <label for="dataNascimento">Data de Nascimento</label>
                <input type="date" class="form-control" name="dataNascimento" placeholder="Data" v-model="model.pessoa.dataNascimento" />
            </div>
        </div>
        <legend>Cliente</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="clienteId" v-model="model.clienteId" />
            <div class="form-group col-md-12">
                <label for="condominioId">Condomínio</label>
                <select v-select="{ dataitem: 'Condominio', default: 'Selecione' }" v-model="model.condominioId" class="form-control" name="condominioId"></select>
            </div>
            <div class="form-group col-md-6" data-reference="responsavelId">
                <label for="responsavelId">Responsável</label>
                <select v-select="{ dataitem: 'Colaborador', default: 'Selecione' }" v-model="model.responsavelId" class="form-control" name="responsavelId" required></select>
            </div>
            <div class="form-group col-md-6" data-reference="statusClienteId">
                <label for="statusClienteId">Situação</label>
                <select v-select="{ dataitem: 'StatusCliente', default: 'Selecione' }" v-model="model.statusClienteId" class="form-control" name="statusClienteId" required></select>
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