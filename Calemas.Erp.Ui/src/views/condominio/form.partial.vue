<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="condominioId" v-model="model.condominioId" />

            <div class="form-group col-md-8" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-4" data-reference="sigla">
                <label for="nome">Sigla</label>
                <input type="text" class="form-control" name="sigla" placeholder="Sigla" v-model="model.sigla" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="infraestruturaPopId">Pop</label>
                <select v-select="{ dataitem: 'InfraestruturaPop', default: 'Selecione' }" v-model="model.infraestruturaPopId" class="form-control" name="infraestruturaPopId" required></select>
            </div>
            <div class="form-group col-md-12">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.ativo">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Ativo?</span>
                </label>
            </div>

        </div>
        <legend>Endereço / Máscara</legend>
        <endereco-form :model="model.endereco" />
    </fieldset>
</template>
<script>
    import enderecoForm from '../endereco/form.partial'
    import formBase from '../../common/mixins/form'
    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
        components: { enderecoForm }
    }
</script>
