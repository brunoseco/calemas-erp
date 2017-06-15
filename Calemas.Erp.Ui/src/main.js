import Vue from 'vue'
import App from './app'
import router from './router'

const Moment = require('moment')
require('moment/locale/pt')
Vue.use(require('vue-moment'), { Moment });

new Vue({
    el: '#app',
    router,
    template: '<App/>',
    components: { App }
})
