import bus from '../../common/bus'

import Vue from 'vue'
import VueMask from 'di-vue-mask'
Vue.use(VueMask);

export default {
    mounted() {
        bus.$on('validate', this.onValidate)
        this.$watch(() => this.errors.items, () => {
            bus.$emit('errors-changed', this.errors.items)
        })
    },
    methods: {
        onValidate() {
            this.$validator.validateAll().then(res => {
                bus.$emit('errors-changed', this.errors.items)
            });
        },
    },
    beforeDestroy() {
        bus.$emit('errors-changed', [])
        bus.$off('validate', this.onValidate)
    },
}