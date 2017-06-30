import Vue from 'vue'
import Router from 'vue-router'
import Template from '@/template'
import Auth from '../common/auth'

import Dashboard from '@/views/dashboard'
import Authorized from '@/views/authorized'

import routers from './generated'

Vue.use(Router)

routers.push({
    path: 'dashboard',
    name: 'Dashboard',
    component: Dashboard
})

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
            children: routers
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
