<template>
	<div>
		<div class="columns is-mobile is-gapless">
			<layout-aside :menu-open="isOpen"></layout-aside>
			<div class="column">
				<layout-nav></layout-nav>
				<router-view></router-view>
			</div>
		</div>
		<layout-footer></layout-footer>
	</div>
</template>
<script>

	import LayoutAside from './layout-aside'
	import LayoutNav from './layout-nav'
	import LayoutFooter from './layout-footer'

	export default {
		name: 'layout',
		data() {
			return {
				isOpen: true
			}
		},
		methods: {
			changeValue: function () {
				this.isOpen = !this.isOpen
			}
		},
		components: { LayoutAside, LayoutNav, LayoutFooter }
	}

</script>
<style>
	.columns.is-gapless {
		margin-bottom: 0 !important;
	}
</style>
