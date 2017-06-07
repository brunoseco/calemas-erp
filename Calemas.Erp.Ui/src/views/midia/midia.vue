<template>
	<div>
		<nav class="nav menu">
			<div class="nav-left is-hidden-mobile">
				<a class="nav-item is-tab">Home</a>
				<a class="nav-item is-tab is-active">
					Midia
				</a>
			</div>
			<div class="nav-right">
				<a class="nav-item is-tab is-warning is-hidden-mobile" tooltip-bottom="Ajuda">
					<span class="icon-btn">
						<i class="fa fa-question-circle-o"></i>
					</span>
				</a>
				<a class="nav-item is-tab is-warning is-hidden-mobile" tooltip-bottom="Reportar um bug">
					<span class="icon-btn">
						<i class="fa fa-bug"></i>
					</span>
				</a>
				<a class="nav-item is-tab is-warning is-hidden-mobile" tooltip-bottom="Imprimir">
					<span class="icon-btn">
						<i class="fa fa-print"></i>
					</span>
				</a>
				<a class="nav-item is-tab" @click="excuteCreateModal()">
					<span class="button is-success">
						<span class="icon">
							<i class="fa fa-plus"></i>
						</span>
						<span>Adicionar novo</span>
					</span>
				</a>
			</div>
		</nav>
		<section class="section">
			<div class="content">
				<nav class="panel">
					<div class="panel-heading">
						Filtros
					</div>
					<div class="panel-block">
						<form class="control">
							<div class="columns">
								<div class="column is-half">
									<div class="field">
										<label class="label">Nome</label>
										<label class="control">
											<input class="input" type="text" placeholder="Nome">
										</label>
									</div>
								</div>
								<div class="column is-half">
									<div class="field">
										<label class="label">Ativo?</label>
										<label class="control">
											<label class="radio">
												<input type="radio" name="question"> Todos
											</label>
											<label class="radio">
												<input type="radio" name="question"> Sim
											</label>
											<label class="radio">
												<input type="radio" name="question"> Não
											</label>
										</label>
									</div>
								</div>
							</div>
						</form>
					</div>
					<div class="panel-footer">
						<div class="columns">
							<div class="column">
								<div class="field is-grouped pull-right">
									<button class="button is-success">
										<span class="icon is-small">
											<i class="fa fa-search"></i>
										</span>
										<span>Filtrar</span>
									</button>
								</div>
							</div>
						</div>
					</div>
				</nav>

				<nav class="panel">
					<div class="panel-heading">
						Resultado
					</div>
					<div class="panel-block no-padding">
						<table class="table is-narrow is-striped">
							<thead>
								<tr>
									<th>#</th>
									<th>Nome</th>
									<th>Ativo</th>
									<th class="text-center">
										<span class="icon is-small">
											<i class="fa fa-cog"></i>
										</span>
									</th>
								</tr>
							</thead>
							<tbody>
								<tr v-for="item in list">
									<td>{{item.MidiaId}}</td>
									<td>{{item.Nome}}</td>
									<td>
										<span class="tag" v-bind:class="{ 'is-success': item.Ativo, 'is-danger': !item.Ativo }">{{item.Ativo}}</span>
									</td>
									<td class="text-center">
										<button type="button" tooltip-top="Editar" class="button is-primary is-small" @click="excuteEditModal(item)">
											<span class="icon is-small">
												<i class="fa fa-pencil is-small"></i>
											</span>
										</button>
										<button type="button" tooltip-top="Excluir" class="button is-danger is-small" @click="excuteDeleteModal(item)">
											<span class="icon is-small">
												<i class="fa fa-trash"></i>
											</span>
										</button>
									</td>
								</tr>
							</tbody>
						</table>
					</div>
				</nav>
			</div>
		</section>

		<card-modal :visible="createModalIsOpen" :title="'Manutenção de mídia'" @before-leave="createModalIsOpen = false" @ok="saveModel">
			<template slot="content">
				<form class="control" type="post" v-on:submit="saveModel">
					<div class="columns">
						<div class="column is-half">
							<div class="field">
								<label class="label">Nome</label>
								<label class="control">
									<input class="input" type="text" name="Nome" placeholder="Nome" v-model="model.Nome">
								</label>
							</div>
						</div>
						<div class="column is-half">
							<div class="field">
								<label class="control">
									<label class="checkbox">
										<input type="checkbox" name="Ativo" v-model="model.Ativo"> Ativo?
									</label>
								</label>
							</div>
						</div>
					</div>
				</form>
			</template>
		</card-modal>

		<card-modal :visible="editModalIsOpen" :title="'Manutenção de mídia'" @before-leave="editModalIsOpen = false" @ok="saveModel">
			<template slot="content">
				<form class="control" type="post" v-on:submit="saveModel">
					<div class="columns">
						<div class="column is-half">
							<div class="field">
								<label class="label">Nome</label>
								<label class="control">
									<input class="input" type="text" name="Nome" placeholder="Nome" v-model="model.Nome">
								</label>
							</div>
						</div>
						<div class="column is-half">
							<div class="field">
								<label class="control">
									<label class="checkbox">
										<input type="checkbox" name="Ativo" v-model="model.Ativo"> Ativo?
									</label>
								</label>
							</div>
						</div>
					</div>
				</form>
			</template>
		</card-modal>

		<card-modal :visible="deleteModalIsOpen" :title="'Manutenção de mídia'" @before-leave="deleteModalIsOpen = false" @ok="deleteModel">
			<template slot="content">
				<form class="control" type="post" v-on:submit="deleteModel">
					<div class="columns">
						<div class="column is-half">
							<div class="field">
								<label class="label">Nome</label>
								<label>{{model.Nome}}</label>
							</div>
						</div>
						<div class="column is-half">
							<div class="field">
								<label class="label">Ativo?</label>
								<label>
									<span class="tag" v-bind:class="{ 'is-success': model.Ativo, 'is-danger': !model.Ativo }">{{model.Ativo}}</span>
								</label>
							</div>
						</div>
					</div>
				</form>
			</template>
		</card-modal>

	</div>
</template>

<script>

	import { Api } from '../../common/api'
	import { CardModal } from '../../common/modal'

	export default {
		name: 'midia',
		components: { CardModal },
		data() {
			return {
				model: {
					Nome: '',
					Ativo: true
				},
				createModalIsOpen: false,
				editModalIsOpen: false,
				deleteModalIsOpen: false,
				list: []
			}
		},
		methods: {
			loadList() {
				var api = new Api("midia");
				api.Get().then(data => { this.list = data.DataList; });
			},
			saveModel() {
				var api = new Api("midia");
				api.Post(this.model).then(data => {
					this.loadList();
					this.createModalIsOpen = false;
					this.editModalIsOpen = false;
				});
			},
			deleteModel() {
				var api = new Api("midia");
				api.Filter = this.model;
				api.Delete().then(data => {
					this.loadList();
					this.deleteModalIsOpen = false;
				});
			},
			excuteCreateModal() {
				this.model = {};
				this.createModalIsOpen = true;
			},
			excuteEditModal(model) {
				var api = new Api("midia");
				api.Filter = model;
				api.GetMethodCustom("GetByModel").then(data => {
					this.editModalIsOpen = true;
					this.model = data.Data;
				});

			},
			excuteDeleteModal(model) {
				var api = new Api("midia");
				api.Filter = model;
				api.GetMethodCustom("GetByModel").then(data => {
					this.deleteModalIsOpen = true;
					this.model = data.Data;
				});

			}
		},
		mounted() {
			this.loadList()
		}
	}

</script>
