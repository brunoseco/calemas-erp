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
                        <label for="corId">Cor</label>
                        <select v-select="{ dataitem: 'Cor', default: 'Selecione' }" v-model="filter.corId" class="form-control" name="corId" ></select>
                    </div>
				<div class="form-group col-md-12">
                    <label>Ativo</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="ativo" v-model="filter.ativo" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>