import Vue from 'vue'
import App from './app'
import router from './router'
import validation from 'jquery-validation'

import Notifications from 'vue-notification'
Vue.use(Notifications)

import select from './common/select'

require('vue-strap/dist/vue-strap-lang.js')

const _moment = require('moment')
require('moment/locale/pt')
Vue.use(require('vue-moment'), { _moment });

Vue.filter('date', function (value) {
    if (value) return _moment(String(value)).format('DD/MM/YYYY HH:mm')
});

import '../static/scss/style.scss'

new Vue({
    el: '#app',
    router,
    template: '<App/>',
    components: { App }
})
