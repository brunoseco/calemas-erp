<template>
    <footer class="app-footer">
        Versão 0.0.1 - {{Date.now() | moment("dddd, D MMMM YYYY") }}
        <span class="float-right">
            <a href="http://www.calemas.com.br">Calemas</a>
        </span>
    </footer>
</template>
<script>
    export default {
        name: 'footer'
    }
</script>
