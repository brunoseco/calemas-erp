import Vue from 'vue'
import App from './app'
import router from './router'

import '../static/scss/style.scss'

import VeeValidate from 'vee-validate';
Vue.use(VeeValidate, {
    errorBagName: 'formErrors',
    fieldsBagName: 'formFields',
    locale: 'pt'
});

const Moment = require('moment')
require('moment/locale/pt')
Vue.use(require('vue-moment'), { Moment });

new Vue({
    el: '#app',
    router,
    template: '<App/>',
    components: { App }
})
