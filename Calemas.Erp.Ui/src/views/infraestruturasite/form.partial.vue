<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="infraestruturaSiteId" v-model="model.infraestruturaSiteId" />

            <div class="form-group col-md-12">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-6">
                <label for="latitude">Latitude</label>
                <input type="text" class="form-control" name="latitude" placeholder="Latitude" v-model="model.latitude" />
            </div>
            <div class="form-group col-md-6">
                <label for="longitude">Longitude</label>
                <input type="text" class="form-control" name="longitude" placeholder="Longitude" v-model="model.longitude" />
            </div>
            <div class="form-group col-md-12">
                <label for="endpoint">Endpoint</label>
                <input type="text" class="form-control" name="endpoint" placeholder="Endpoint" v-model="model.endpoint" />
            </div>
            <div class="form-group col-md-6">
                <label for="login">Login</label>
                <input type="text" class="form-control" name="login" placeholder="Login" v-model="model.login" />
            </div>
            <div class="form-group col-md-6">
                <label for="senha">Senha</label>
                <input type="text" class="form-control" name="senha" placeholder="Senha" v-model="model.senha" />
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
