<!--<template>
    <div class="wrapper">
        <header-partial :crud="crud" />
        <filter-partial :crud="crud" />
        <grid-partial :crud="crud" />
    </div>
</template>
<script>

    import headerPartial from './header.partial'
    import filterPartial from './filter.partial'
    import gridPartial from './grid.partial'

    import { Crud } from '../../../common/crud'

    export default {
        name: 'estoquemovimentacaodetails',
        components: {
            headerPartial,
            filterPartial,
            gridPartial,
        },
        data() {
            return {
                crud: new Crud({
                    resource: "estoquemovimentacao",
                    vm: this
                })
            }
        },
        mounted() {
            let id = this.$route.params.id;
            this.crud.filter.model = { estoqueId: id };
            this.crud.filter.executeAction();
        }
    }
</script>-->
