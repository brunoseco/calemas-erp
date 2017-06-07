<template>
	<transition name="slide">
		<aside class="column is-8 aside" v-show="menuOpen">
			<div class="user has-text-centered">
				<figure class="is-128x128">
					<img src="http://bulma.io/images/placeholders/128x128.png">
				</figure>
				<h2 class="title">Bruno Henrique Drey Seco</h2>
			</div>
			<div class="menu">
				<p class="menu-label">
					Menu
				</p>
				<ul class="menu-list">
					<li><router-link to="/dashboard" active-class="is-active">Dashboard</router-link></li>
					<li><router-link to="/financeiro" active-class="is-active">Financeiro</router-link></li>
					<li><router-link to="/midia" active-class="is-active">Midia</router-link></li>
				</ul>
			</div>
		</aside>
	</transition>
</template>

<script>
	export default {
		name: 'layout-aside',
		props: {
			menuOpen: Boolean
		}
	}
</script>

<style scoped>
	.aside {
		max-width: 260px;
		min-height: 100vh;
		background-color: #232B2D;
	}

		.aside .menu {
			padding: 10px;
			color: #FFF;
		}

		.aside .user {
			background-color: #2EB398;
			padding: 10px 0;
		}

			.aside .user figure {
				margin: auto;
			}

			.aside .user img {
				border-radius: 50%;
				margin-bottom: 10px;
			}

		.aside .title {
			color: #F6F7F7;
			font-size: 15px;
			font-weight: bold;
		}

	.slide-leave-active,
	.slide-enter-active {
		transition: 0.3s;
	}

	.slide-enter {
		transform: translate(-100%, 0);
	}

	.slide-leave-to {
		transform: translate(-100%, 0);
	}
</style>
