import Vue from 'vue'
import Router from 'vue-router'

// Containers
import Template from '@/template'

// Views
import Dashboard from '@/views/dashboard'
import Midia from '@/views/midia'
import Authorized from '@/views/authorized'

Vue.use(Router)

export default new Router({
    linkActiveClass: 'open active',
    scrollBehavior: () => ({ y: 0 }),
    routes: [
        {
            path: '/',
            redirect: '/dashboard',
            name: 'Home',
            component: Template,
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
})
