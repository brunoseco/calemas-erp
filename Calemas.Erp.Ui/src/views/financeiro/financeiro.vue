<template>
    <div>
        <nav class="nav menu">
            <div class="nav-left is-hidden-mobile">
                <a class="nav-item is-tab">Home</a>
                <a class="nav-item is-tab is-active">Banco</span>
                </a>
            </div>
            <div class="nav-right">
                <div class="nav-item is-tab is-hidden-mobile">
                    <strong>2 items selected</strong>
                </div>
                <a class="nav-item is-tab is-warning is-hidden-mobile">
                    <span class="icon-btn">
                        <i class="fa fa-print"></i>
                    </span>
                </a>
                <a class="nav-item is-tab">
                    <span class="icon-btn">
                        <i class="fa fa-trash"></i>
                    </span>
                </a>
                <a class="nav-item is-tab" @click="toggleCreateModal">
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
                                    <th>Qtde. Contas Atreladas</th>
                                    <th>Número</th>
                                    <th>Dígito</th>
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
                                    <td>{{item.BancoId}}</td>
                                    <td>{{item.Nome}}</td>
                                    <td>
                                        <span class="tag">
                                            {{item.TotalContas}}
                                        </span>
                                    </td>
                                    <td>{{item.Numero}}</td>
                                    <td>{{item.Digito}}</td>
                                    <td>
                                        <span class="tag" v-bind:class="{ 'is-success': item.Ativo, 'is-danger': !item.Ativo }">{{item.Ativo}}</span>
                                    </td>
                                    <td class="text-center">
                                        <button type="button" class="button is-primary is-small">
                                            <span class="icon is-small">
                                                <i class="fa fa-pencil is-small"></i>
                                            </span>
                                        </button>
                                        <button type="button" class="button is-danger is-small">
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
    
        <card-modal :visible="createModalIsOpen" :title="'Manutenção de banco'" @before-leave="toggleCreateModal" @ok="saveModel">
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
    </div>
</template>

<script>

import { Api } from '../../common/api'
import { CardModal } from '../../common/modal'

export default {
    name: 'financeiro',
    components: { CardModal },
    data() {
        return {
            model: {
                Nome: '',
                Ativo: true
            },
            createModalIsOpen: false,
            list: []
        }
    },
    methods: {
        toggleCreateModal() {
            this.createModalIsOpen = !this.createModalIsOpen;
        },
        loadList() {
            var api = new Api("banco");
            api.Get().then(data => { this.list = data.DataList; });
        },
        saveModel() {
            var api = new Api("banco");
            api.Data = this.model;
            api.Post().then(data => { this.list = data.DataList; });
        }
    },
    mounted() {
        this.loadList()
    }
}

</script>
