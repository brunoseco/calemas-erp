<template>
    <fieldset>
        <legend>Dados</legend>
        <div class="row">
            <input type="hidden" class="form-control" name="tipoOrdemServicoId" v-model="model.tipoOrdemServicoId" />

            <div class="form-group col-md-12" data-reference="nome">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descricao</label>
                <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" />
            </div>
            <div class="form-group col-md-12">
                <label for="setorId">Setor do Serviço</label>
                <select v-select="{ dataitem: 'Setor', default: 'Selecione' }" v-model="model.setorId" class="form-control" name="setorId" required></select>
            </div>
            <div class="form-group col-md-12">
                <label for="prioridadeId">Prioridade do Serviço</label>
                <select v-select="{ dataitem: 'Prioridade', default: 'Selecione' }" v-model="model.prioridadeId" class="form-control" name="prioridadeId" required></select>
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
    </fieldset>
</template>
<script>
    import formBase from '../../common/mixins/form'
    import selectSearch from '../../common/select/select2'

    export default {
        name: 'form-partial',
        props: ['model'],
        mixins: [formBase],
        components: { selectSearch },
    }
</script>
