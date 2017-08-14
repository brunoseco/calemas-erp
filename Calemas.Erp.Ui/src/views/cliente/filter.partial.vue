<template>
    <div class="row">
        <div class="form-group col-md-12">
            <label for="nome">Nome</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-6">
            <label for="condominioId">Condomínio</label>
            <select v-select="{ dataitem: 'Condominio', default: 'Selecione' }" v-model="filter.condominioId" class="form-control" name="condominioId"></select>
        </div>
        <div class="form-group col-md-6">
            <label for="statusClienteId">Situação</label>
            <select v-select="{ dataitem: 'StatusCliente', default: 'Selecione' }" v-model="filter.statusClienteId" class="form-control" name="statusClienteId"></select>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>