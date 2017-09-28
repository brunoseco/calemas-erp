<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="corId" v-model="model.corId" />

            <div class="form-group col-md-12" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-4" data-reference="hash">
                <label for="hash">Hash</label>
                <input type="text" class="form-control" name="hash" placeholder="Hash" v-model="model.hash" required />
            </div>
            <div class="form-group col-md-8">
                <compact-picker v-model="colors" />
            </div>

        </div>
    </fieldset>
</template>
<script>
    import { Compact } from 'vue-color'
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
        data() {
            return {
                colors: { hex: this.model.hash }
            }
        },
        components: { 'compact-picker': Compact },
        watch: {
            colors: function (val) {
                this.model.hash = val.hex;
            },
        }
    }
</script>