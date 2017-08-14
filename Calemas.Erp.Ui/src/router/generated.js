
const routers = [
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'categoriaestoque', name: 'CategoriaEstoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'unidademedida', name: 'UnidadeMedida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoquemovimentacao', name: 'EstoqueMovimentacao', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },
    { path: 'cliente', name: 'Cliente', component: function (resolve) { require(['@/views/cliente'], resolve) } },
    { path: 'condominio', name: 'Condominio', component: function (resolve) { require(['@/views/condominio'], resolve) } },
    { path: 'agenda', name: 'Agenda', component: function (resolve) { require(['@/views/agenda'], resolve) } },
    { path: 'statuscliente', name: 'StatusCliente', component: function (resolve) { require(['@/views/statuscliente'], resolve) } },

];

export default routers