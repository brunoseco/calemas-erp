<template>
    <div class="app">
        <template-header />
        <div class="app-body">
            <template-sidebar />
            <main class="main">
                <template-breadcrumb :list="list" />
                <div class="container-fluid">
                    <router-view></router-view>
                </div>
            </main>
            <template-aside />
        </div>
        <template-footer />
    </div>
</template>
<script>

    import TemplateHeader from './header'
    import TemplateSidebar from './sidebar'
    import TemplateAside from './aside'
    import TemplateBreadcrumb from './breadcrumb'
    import TemplateFooter from './footer'

    export default {
        name: 'full',
        components: {
            TemplateHeader,
            TemplateSidebar,
            TemplateAside,
            TemplateBreadcrumb,
            TemplateFooter
        },
        computed: {
            name() {
                return this.$route.name
            },

            list() {
                return this.$route.matched
            }
        }
    }
</script>
<style>
</style>
