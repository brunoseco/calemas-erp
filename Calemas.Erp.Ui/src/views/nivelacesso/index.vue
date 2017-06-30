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

    import headerPartial from './generated/header.partial'
    import filterPartial from './generated/filter.partial'
    import gridPartial from './generated/grid.partial'
    import createPartial from './generated/create.partial'
    import editPartial from './generated/edit.partial'
    import deletePartial from './generated/delete.partial'

    import { Crud } from '../../common/crud'

    export default {
        name: 'nivelacesso',
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
                    resource: "nivelacesso",
                    vm: this,
                    create: { model: { } },
                    edit: { model: { } },
                    delete: { model: { } }
                }),
            }
        },
        mounted() {
            this.crud.filter.executeAction();
        }
    }
</script>
