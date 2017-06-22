<template>
    <div class="animated fadeIn">
        Login realizado com sucesso. Aguarde, redirecionando!
    </div>
</template>
<script>

    import Auth from '../../common/auth'

    export default {
        name: 'authorized',
        mounted() {
            Auth.verifyLogin();
        }
    }
</script>
