
const routers = [
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'categoriaestoque', name: 'CategoriaEstoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'unidademedida', name: 'UnidadeMedida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoquemovimentacao', name: 'EstoqueMovimentacao', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },

];

export default routers