<template>
    <div class="animated fadeIn text-center">
        <div class="row justify-content-center margin-top-50">
            <div class="col-md-8">
                <div class="card-group mb-0">
                    <div class="card p-12">
                        <div class="card-block">
                            <h1>
                                Login realizado com sucesso <small>Aguarde.</small>
                            </h1>
                            <div>Estamos carregando as informações do seu usuário, você será redirecionado!</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
