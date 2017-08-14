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
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-list"></i> Administrativo</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/estoquemovimentacao'" class="nav-link">Movimentação de Estoque</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-pencil"></i> Cadastros</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/estoque'" class="nav-link">Estoque</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/unidademedida'" class="nav-link">Unidade de medida</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/categoriaestoque'" class="nav-link">Categorias de estoque</router-link>
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
