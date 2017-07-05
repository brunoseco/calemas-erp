<template>
    <div class="sidebar">
        <nav class="sidebar-nav">
            <ul class="nav">
                <li class="nav-item">
                    <router-link :to="'/dashboard'" class="nav-link">
                        <i class="icon-home"></i> Dashboard
                    </router-link>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-list"></i> Administrativo</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/colaborador'" class="nav-link" exact><i class="icon-user"></i> Colaborador</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-chart"></i> Financeiro</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/financeiro'" class="nav-link" exact><i class="icon-wallet"></i> Lançamentos</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/planoconta'" class="nav-link" exact><i class="icon-notebook"></i> Plano de conta</router-link>
                        </li>
                    </ul>
                </li>
                <li class="nav-item nav-dropdown">
                    <div class="nav-link nav-dropdown-toggle" @click="handleClick"><i class="icon-pencil"></i> Cadastros</div>
                    <ul class="nav-dropdown-items">
                        <li class="nav-item">
                            <router-link :to="'/nivelacesso'" class="nav-link" exact><i class="icon-anchor"></i> Nível de acesso</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/prioridade'" class="nav-link" exact><i class="icon-loop"></i> Prioridade</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/setor'" class="nav-link" exact><i class="icon-people"></i> Setor</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/tipoordemservico'" class="nav-link" exact><i class="icon-paper-clip"></i> Tipo de OS</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/cor'" class="nav-link" exact><i class="icon-drawer"></i> Cor</router-link>
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
