<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="categoriaEstoqueId" v-model="model.categoriaEstoqueId" />

					<div class="form-group col-md-12" data-reference="nome">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
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