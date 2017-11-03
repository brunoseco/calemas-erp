<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="infraestruturaPopId" v-model="model.infraestruturaPopId" />

            <div class="form-group col-md-12">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="latitude">Latitude</label>
                <input type="text" class="form-control" name="latitude" placeholder="Latitude" v-model="model.latitude" />
            </div>
            <div class="form-group col-md-12">
                <label for="longitude">Longitude</label>
                <input type="text" class="form-control" name="longitude" placeholder="Longitude" v-model="model.longitude" />
            </div>
            <div class="form-group col-md-12">
                <label for="infraestruturaSiteId">Site</label>
                <select v-select="{ dataitem: 'InfraestruturaSite', default: 'Selecione' }" v-model="model.infraestruturaSiteId" class="form-control" name="infraestruturaSiteId" required></select>
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
