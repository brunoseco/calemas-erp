<template>
    <div class="row">
        <input type="hidden" class="form-control" name="enderecoId" v-model="model.enderecoId" />

        <div class="form-group col-md-6">
            <label for="cep">CEP</label>
            <input type="text" class="form-control" name="cep" placeholder="CEP" v-mask="masks.cep" v-model="model.cep" />
        </div>
        <div class="form-group col-md-10">
            <label for="rua">Rua</label>
            <input type="text" class="form-control" name="rua" placeholder="Rua" v-model="model.rua" />
        </div>
        <div class="form-group col-md-2">
            <label for="numero">Nº</label>
            <input type="text" class="form-control" name="numero" placeholder="Número" v-model="model.numero" />
        </div>
        <div class="form-group col-md-6">
            <label for="complemento">Complemento</label>
            <input type="text" class="form-control" name="complemento" placeholder="Complemento" v-model="model.complemento" />
        </div>
        <div class="form-group col-md-6">
            <label for="bairro">Bairro</label>
            <input type="text" class="form-control" name="bairro" placeholder="Bairro" v-model="model.bairro" />
        </div>
        <div class="form-group col-md-10">
            <label for="cidade">Cidade</label>
            <input type="text" class="form-control" name="cidade" placeholder="Cidade" v-model="model.cidade" />
        </div>
        <div class="form-group col-md-2">
            <label for="uF">UF</label>
            <input type="text" class="form-control" name="uf" placeholder="UF"  v-mask="'AA'" v-model="model.uf" />
        </div>
    </div>
</template>
<script>
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
    }
</script>