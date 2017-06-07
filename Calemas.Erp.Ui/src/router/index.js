import Vue from 'vue'
import Router from 'vue-router'
import Layout from '../layout/layout'

Vue.use(Router)

const financeiro = resolve => { require.ensure([], () => { resolve(require('../views/financeiro/financeiro.vue')) }) }
const midia = resolve => { require.ensure([], () => { resolve(require('../views/midia/midia.vue')) }) }
const dashboard = resolve => { require.ensure([], () => { resolve(require('../views/dashboard/dashboard.vue')) }) }

export default new Router({
	mode: 'history',
	routes: [
		{
			path: '/',
			name: '',
			component: Layout,
			children: [
				{ path: '', redirect: 'dashboard' },
				{ path: 'financeiro', component: financeiro },
				{ path: 'midia', component: midia },
				{ path: 'dashboard', component: dashboard }
			]
		}
	]
})
