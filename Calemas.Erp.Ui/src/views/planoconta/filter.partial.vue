<template>
    <div class="row">
        					<div class="form-group col-md-12" >
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="tipoPlanoContaId">TipoPlanoConta</label>
                        <select v-select="{ dataitem: 'TipoPlanoConta', default: 'Selecione' }" v-model="filter.tipoPlanoContaId" class="form-control" name="tipoPlanoContaId" ></select>
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>