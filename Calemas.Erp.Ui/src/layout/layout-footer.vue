<template>
	<footer class="footer is-hidden-mobile">
		<div class="container">
			<div class="has-text-centered">
				<p><em>Vue Dashboard Bulma</em> by <a href="http://brunosecco.com">Bruno Henrique</a>. Version 1.0.0</p>
			</div>
		</div>
	</footer>
</template>

<script>
	export default {
		name: 'layout-footer'
	}
</script>

<style scoped>
	.footer {
		background-color: #232b2d;
		z-index: 9998 !important;
		position: fixed;
		padding: 4px;
		width: 100%;
		bottom: 0;
		color: #fff;
		font-size: 12px;
	}
</style>
