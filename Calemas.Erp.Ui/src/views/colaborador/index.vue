<template>
    <div class="wrapper">

        <header-partial :crud="crud" />
        <filter-partial :crud="crud" />
        <grid-partial :crud="crud" />
        <create-partial :crud="crud" />
        <edit-partial :crud="crud" />
        <delete-partial :crud="crud" />

    </div>
</template>
<script>

    import headerPartial from './header.partial'
    import filterPartial from './filter.partial'
    import gridPartial from './grid.partial'
    import createPartial from './create.partial'
    import editPartial from './edit.partial'
    import deletePartial from './delete.partial'

    import { Crud } from '../../common/crud'

    export default {
        name: 'colaborador',
        components: {
            headerPartial,
            filterPartial,
            gridPartial,
            createPartial,
            editPartial,
            deletePartial
        },
        data() {
            return {
                crud: new Crud({
                    resource: "colaborador",
                    vm: this,
                    create: { model: { pessoa: {} } },
                    edit: { model: { pessoa: {} } },
                    delete: { model: { pessoa: {} } }
                }),
            }
        },
        mounted() {
            this.crud.filter.executeAction();
        }
    }
</script>