<template>
	<transition name="slide">
		<nav class="nav has-shadow" id="top">
			<div class="nav-left">
				<button class="nav-item button is-white menu-button" v-on:click="changeValue()" href="javascript:void()">
					<i class="fa fa-bars"></i>
				</button>
				<a class="nav-item logo" href="../index.html">
					<img src="../assets/images/logo.png" alt="Description">
				</a>
			</div>
			<div class="nav-right">
				<button class="nav-item button is-outlined is-danger logout-button" href="javascript:void()">
					<i class="fa fa-sign-out"></i>
				</button>
			</div>
		</nav>
	</transition>
</template>

<script>
	export default {
		name: 'layout-nav',
		methods: {
			changeValue: function () {
				this.$parent.changeValue()
			}
		}
	}
</script>

<style scoped>
	.nav {
		z-index: 11;
	}

		.nav .button {
			margin: 7px;
		}

	.slide-leave-active,
	.slide-enter-active {
		transition: 1s;
	}

	.slide-enter {
		-webkit-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		-moz-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		-o-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		transition: width 300ms ease-in-out, height 300ms ease-in-out;
	}

	.slide-leave-to {
		-webkit-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		-moz-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		-o-transition: width 300ms ease-in-out, height 300ms ease-in-out;
		transition: width 300ms ease-in-out, height 300ms ease-in-out;
	}
</style>
