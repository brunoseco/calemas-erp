
const routers = [
    { path: 'nivelacesso', name: 'NivelAcesso', component: function (resolve) { require(['@/views/nivelacesso'], resolve) } },
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'ordemservico', name: 'OrdemServico', component: function (resolve) { require(['@/views/ordemservico'], resolve) } },
    { path: 'setor', name: 'Setor', component: function (resolve) { require(['@/views/setor'], resolve) } },
    { path: 'prioridade', name: 'Prioridade', component: function (resolve) { require(['@/views/prioridade'], resolve) } },
    { path: 'tipoordemservico', name: 'TipoOrdemServico', component: function (resolve) { require(['@/views/tipoordemservico'], resolve) } },
    { path: 'cor', name: 'Cor', component: function (resolve) { require(['@/views/cor'], resolve) } },
    { path: 'financeiro', name: 'Financeiro', component: function (resolve) { require(['@/views/financeiro'], resolve) } },
    { path: 'planoconta', name: 'PlanoConta', component: function (resolve) { require(['@/views/planoconta'], resolve) } },
    { path: 'categoriaestoque', name: 'CategoriaEstoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'unidademedida', name: 'UnidadeMedida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoquemovimentacao', name: 'EstoqueMovimentacao', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },

];

export default routers