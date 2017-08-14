
const routers = [
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'categoriaestoque', name: 'CategoriaEstoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'unidademedida', name: 'UnidadeMedida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoquemovimentacao', name: 'EstoqueMovimentacao', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },
    { path: 'ordemservico', name: 'OrdemServico', component: function (resolve) { require(['@/views/ordemservico'], resolve) } },
    { path: 'ordemservicointeracao', name: 'OrdemServicoInteracao', component: function (resolve) { require(['@/views/ordemservicointeracao'], resolve) } },
    { path: 'setor', name: 'Setor', component: function (resolve) { require(['@/views/setor'], resolve) } },
    { path: 'prioridade', name: 'Prioridade', component: function (resolve) { require(['@/views/prioridade'], resolve) } },
    { path: 'tipoordemservico', name: 'TipoOrdemServico', component: function (resolve) { require(['@/views/tipoordemservico'], resolve) } },
    { path: 'statusordemservico', name: 'StatusOrdemServico', component: function (resolve) { require(['@/views/statusordemservico'], resolve) } },
    { path: 'cor', name: 'Cor', component: function (resolve) { require(['@/views/cor'], resolve) } },
    { path: 'cliente', name: 'Cliente', component: function (resolve) { require(['@/views/cliente'], resolve) } },
    { path: 'condominio', name: 'Condominio', component: function (resolve) { require(['@/views/condominio'], resolve) } },
    { path: 'statuscliente', name: 'StatusCliente', component: function (resolve) { require(['@/views/statuscliente'], resolve) } },
    { path: 'agenda', name: 'Agenda', component: function (resolve) { require(['@/views/agenda'], resolve) } },

];

export default routers