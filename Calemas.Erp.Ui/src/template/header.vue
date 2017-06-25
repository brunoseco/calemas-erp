<template>
    <navbar>
        <button class="navbar-toggler mobile-sidebar-toggler d-lg-none" type="button" @click="mobileSidebarToggle"><i class="icon-menu"></i></button>
        <a class="navbar-brand" href="#"></a>
        <ul class="nav navbar-nav d-md-down-none">
            <li class="nav-item">
                <a class="nav-link navbar-toggler sidebar-toggler" href="#" @click="sidebarMinimize"><i class="icon-menu"></i></a>
            </li>
        </ul>
        <ul class="nav navbar-nav ml-auto">
            <li class="nav-item d-md-down-none">
                <dropdown size="nav" class="nav-item">
                    <span slot="button">
                        <span class="d-md-down-none">{{ user.name }}</span>
                    </span>
                    <div slot="dropdown-menu" class="dropdown-menu dropdown-menu-right">
                        <div class="dropdown-header text-center"><strong>Central</strong></div>

                        <a class="dropdown-item" href="#"><i class="fa fa-bell-o"></i> Novidades<span class="badge badge-info">2</span></a>
                        <a class="dropdown-item" href="#"><i class="fa fa-envelope-o"></i> Mensagens<span class="badge badge-success">0</span></a>
                        <a class="dropdown-item" href="#"><i class="fa fa-tasks"></i> Tarefas<span class="badge badge-danger">5</span></a>
                        <a class="dropdown-item" href="#"><i class="fa fa-reply"></i> Acessar RadiusNet</a>

                        <div class="dropdown-header text-center"><strong>Acesso</strong></div>
                        <a class="dropdown-item" href="#" @click="logout"><i class="fa fa-sign-out"></i> Sair</a>
                    </div>
                </dropdown>
            </li>
            <li class="nav-item d-md-down-none">
                <a class="nav-link navbar-toggler aside-menu-toggler" href="#" @click="asideToggle">
                    <i class="icon-bell"></i><span class="badge badge-pill badge-danger">5</span>
                </a>
            </li>
        </ul>
    </navbar>
</template>
<script>

    import navbar from './Navbar'
    import { dropdown } from 'vue-strap'
    import Auth from '../common/auth'

    export default {
        name: 'header',
        data() {
            return {
                user: {},
            }
        },
        components: {
            navbar,
            dropdown
        },
        methods: {
            sidebarToggle(e) {
                e.preventDefault()
                document.body.classList.toggle('sidebar-hidden')
            },
            sidebarMinimize(e) {
                e.preventDefault()
                document.body.classList.toggle('sidebar-minimized')
            },
            mobileSidebarToggle(e) {
                e.preventDefault()
                document.body.classList.toggle('sidebar-mobile-show')
            },
            asideToggle(e) {
                e.preventDefault()
                document.body.classList.toggle('aside-menu-hidden')
            },
            login(e) {
                e.preventDefault()
                Auth.login();
            },
            logout(e) {
                e.preventDefault()
                Auth.logout();
            }
        },
        mounted() {
            this.user = Auth.userinfo();
        }
    }
</script>
