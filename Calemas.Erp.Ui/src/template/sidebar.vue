<template>
    <div class="sidebar">
        <nav class="sidebar-nav">
            <ul class="nav">
                <li class="nav-item">
                    <router-link :to="'/dashboard'" class="nav-link">
                        <i class="icon-home"></i> Dashboard
                    </router-link>
                </li>
                <li class="nav-item">
                    <router-link :to="'/agenda'" class="nav-link">
                        <i class="icon-calendar"></i> Agenda
                    </router-link>
                </li>
                <li class="nav-title">
                    Menu
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-people"></i> Cliente</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/cliente'" class="nav-link">Cadastrar</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/condominio'" class="nav-link">Condomínio</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/statuscliente'" class="nav-link">Situação de Cliente</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-layers"></i> Estoque</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/estoque'" class="nav-link">Cadastrar</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/estoquemovimentacao'" class="nav-link">Movimentar</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/solicitacaoestoque'" class="nav-link">Solicitar</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/unidademedida'" class="nav-link">Unidade de medida</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/categoriaestoque'" class="nav-link">Categoria de Estoque</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-docs"></i> Ordem de Serviço</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/ordemservico'" class="nav-link">Cadastrar</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/prioridade'" class="nav-link">Prioridade de Serviço</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/tipoordemservico'" class="nav-link">Tipo de Serviço</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/statusordemservico'" class="nav-link">Situação de Serviço</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/setor'" class="nav-link">Setor</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/cor'" class="nav-link">Cor</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-cloud-upload"></i> Infraestrutura</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/infraestruturasite'" class="nav-link">Site</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/infraestruturapop'" class="nav-link">POP</router-link>
                        </li>                        
                    </ul>
                </li>
            </ul>
        </nav>
    </div>
</template>
<script>

    export default {
        name: 'sidebar',
        methods: {
            handleClick(e) {
                e.preventDefault();
                e.target.parentElement.classList.toggle('open');
            }
        }
    }
</script>
<style lang="css">
    .nav-link {
        cursor: pointer;
    }
</style>
