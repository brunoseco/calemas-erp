<template>
    <div>
        <div class="card" v-for="item in detail">
            <div class="card-block">
                <h4 class="card-title">{{ item.dataConclusao | date }}</h4>
                <h6 class="card-subtitle mb-2 text-muted">{{ item.descricao }}</h6>
                <p class="card-text">{{ item.observacao }}</p>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'detail-partial',
        props: ['detail'],
    }
</script>