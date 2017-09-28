<template>
    <div class="row">
        					<div class="form-group col-md-12">
                        <label for="cep">CEP</label>
                        <input type="text" class="form-control" name="cep" placeholder="CEP" v-model="filter.cep"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="rua">Rua</label>
                        <input type="text" class="form-control" name="rua" placeholder="Rua" v-model="filter.rua"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="numero">Numero</label>
                        <input type="text" class="form-control" name="numero" placeholder="Numero" v-model="filter.numero"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="complemento">Complemento</label>
                        <input type="text" class="form-control" name="complemento" placeholder="Complemento" v-model="filter.complemento"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="pontoReferencia">PontoReferencia</label>
                        <input type="text" class="form-control" name="pontoReferencia" placeholder="PontoReferencia" v-model="filter.pontoReferencia"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="cidade">Cidade</label>
                        <input type="text" class="form-control" name="cidade" placeholder="Cidade" v-model="filter.cidade"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="estadoId">EstadoId</label>
                        <input type="text" class="form-control" name="estadoId" placeholder="EstadoId" v-model="filter.estadoId"  />
                    </div>

    </div>
</template>
<script>
    export default {
        name: 'filter-partial',
        props: ['filter'],    
    }
</script>