<template>
    <div class="row">
        <div class="form-group col-md-6">
            <label for="nome">Nome</label>
            <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
        </div>
        <div class="form-group col-md-3">
            <label for="latitude">Latitude</label>
            <input type="text" class="form-control" name="latitude" placeholder="Latitude" v-model="filter.latitude" />
        </div>
        <div class="form-group col-md-3">
            <label for="longitude">Longitude</label>
            <input type="text" class="form-control" name="longitude" placeholder="Longitude" v-model="filter.longitude" />
        </div>
        <div class="form-group col-md-6">
            <label for="endpoint">Endpoint</label>
            <input type="text" class="form-control" name="endpoint" placeholder="Endpoint" v-model="filter.endpoint" />
        </div>
        <div class="form-group col-md-6">
            <label for="login">Login</label>
            <input type="text" class="form-control" name="login" placeholder="Login" v-model="filter.login" />
        </div>
    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],
    }
</script>
