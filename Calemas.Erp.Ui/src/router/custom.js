
const routerscustom = [
    { path: '/estoquemovimentacao/details/:id', name: 'estoquemovimentacaodetails', component: function (resolve) { require(['@/views/estoquemovimentacao/details'], resolve) } },
    { path: '/solicitacaoestoque/details/:id', name: 'solicitacaoestoquedetails', component: function (resolve) { require(['@/views/solicitacaoestoque/details'], resolve) } }
];

export default routerscustom
