<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
                                <input type="hidden" class="form-control" name="corId" v-model="model.corId" />

					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('nome') }">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" v-validate="'required'" />
                    </div>
					<div class="form-group col-md-12" v-bind:class="{ 'has-danger': errors.has('hash') }">
                        <label for="hash">Hash</label>
                        <input type="text" class="form-control" name="hash" placeholder="Hash" v-model="model.hash" v-validate="'required'" />
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