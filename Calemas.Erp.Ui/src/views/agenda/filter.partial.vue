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
                        <label for="dataInicio">DataInicio</label>
                        <input type="date" class="form-control" name="dataInicio" v-model="filter.dataInicio"  />
                    </div>
					<div class="form-group col-md-12" >
                        <label for="dataFim">DataFim</label>
                        <input type="date" class="form-control" name="dataFim" v-model="filter.dataFim"  />
                    </div>
                    <div class="form-group col-md-12" >
                        <label for="corId">Cor</label>
                        <select v-select="{ dataitem: 'Cor', default: 'Selecione' }" v-model="filter.corId" class="form-control" name="corId" ></select>
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>