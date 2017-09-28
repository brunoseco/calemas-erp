import Vue from 'vue'
import VueMask from 'di-vue-mask'
Vue.use(VueMask);

export default {
    data() {
        return {
            masks: {
                celular: '(99) 9 9999-9999',
                telefone: '(99) 9999-9999',
                rg: '99999999A',
                cpf: '999.999.999-99',
                cnpj: '99.999.999/9999-99',
                cep: '99999-999',
            }
        }
    },
}