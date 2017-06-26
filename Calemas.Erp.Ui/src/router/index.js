import Vue from 'vue'
import Router from 'vue-router'

// Containers
import Template from '@/template'

// Views
import Dashboard from '@/views/dashboard'
import Midia from '@/views/midia'
import Colaborador from '@/views/colaborador'
import Authorized from '@/views/authorized'

//Auth 
import Auth from '../common/auth'

Vue.use(Router)

const router = new Router({
    linkActiveClass: 'open active',
    scrollBehavior: () => ({ y: 0 }),
    routes: [
        {
            path: '/',
            redirect: '/dashboard',
            name: 'Home',
            component: Template,
            meta: { requiresAuth: true },
            children: [
                {
                    path: 'dashboard',
                    name: 'Dashboard',
                    component: Dashboard
                },
                {
                    path: 'midia',
                    name: 'Midia',
                    component: Midia
                },
                {
                    path: 'colaborador',
                    name: 'Colaborador',
                    component: Colaborador
                }

            ]
        },
        {
            path: '/authorized',
            name: 'Authorized',
            component: Authorized,
        },
        { path: "*", redirect: '/dashboard', },
    ]
});

router.beforeEach((to, from, next) => {

    if (to.matched.some(record => record.meta.requiresAuth)) {
        if (!Auth.logged()) {
            Auth.login();
            return;
        }
    }

    next();
})

export default router
