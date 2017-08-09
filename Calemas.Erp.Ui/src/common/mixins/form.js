import bus from '../../common/bus'

export default {
    mounted() {
        bus.$on('validate', this.onValidate)
        this.$watch(() => this.errors.items, (newValue, oldValue) => {
            bus.$emit('errors-changed', this.errors.items, [])
        })
    },
    methods: {
        onValidate() {
            this.$validator.validateAll().then(() => {
                bus.$emit('errors-changed', this.errors.items)
            });
        },
    },
    beforeDestroy() {
        bus.$emit('errors-changed', [])
        bus.$off('validate', this.onValidate)
    },
}