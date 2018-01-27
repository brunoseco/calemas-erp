<template>
    <div class="row">
        					<div class="form-group col-md-12">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>