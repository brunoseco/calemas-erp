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

    import headerPartial from './custom/header.partial'
    import filterPartial from './custom/filter.partial'
    import gridPartial from './custom/grid.partial'
    import createPartial from './custom/create.partial'
    import editPartial from './custom/edit.partial'
    import deletePartial from './custom/delete.partial'

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
