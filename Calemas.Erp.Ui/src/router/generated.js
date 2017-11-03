
const routers = [
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'categoriaestoque', name: 'Categoria de estoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'unidademedida', name: 'Unidade de medida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoquemovimentacao', name: 'Movimentação de estoque', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },
    { path: 'solicitacaoestoquemovimentacao', name: 'Solicitação de movimentação de estoque', component: function (resolve) { require(['@/views/solicitacaoestoquemovimentacao'], resolve) } },
    { path: 'ordemservico', name: 'Ordem de serviço', component: function (resolve) { require(['@/views/ordemservico'], resolve) } },
    { path: 'ordemservicointeracao', name: 'Interação com ordem de serviço', component: function (resolve) { require(['@/views/ordemservicointeracao'], resolve) } },
    { path: 'setor', name: 'Setor', component: function (resolve) { require(['@/views/setor'], resolve) } },
    { path: 'prioridade', name: 'Prioridade', component: function (resolve) { require(['@/views/prioridade'], resolve) } },
    { path: 'tipoordemservico', name: 'Tipo de ordem de serviço', component: function (resolve) { require(['@/views/tipoordemservico'], resolve) } },
    { path: 'statusordemservico', name: 'Situação de ordem de serviço', component: function (resolve) { require(['@/views/statusordemservico'], resolve) } },
    { path: 'cor', name: 'Cores do sistema', component: function (resolve) { require(['@/views/cor'], resolve) } },
    { path: 'cliente', name: 'Cliente', component: function (resolve) { require(['@/views/cliente'], resolve) } },
    { path: 'condominio', name: 'Condomínio', component: function (resolve) { require(['@/views/condominio'], resolve) } },
    { path: 'endereco', name: 'Endereço', component: function (resolve) { require(['@/views/endereco'], resolve) } },
    { path: 'statuscliente', name: 'Situação do cliente', component: function (resolve) { require(['@/views/statuscliente'], resolve) } },
    { path: 'agenda', name: 'Agenda', component: function (resolve) { require(['@/views/agenda'], resolve) } },
    { path: 'infraestruturasite', name: 'Infraestrutura - Site', component: function (resolve) { require(['@/views/infraestruturasite'], resolve) } },
    { path: 'infraestruturapop', name: 'Infraestrutura - POP', component: function (resolve) { require(['@/views/infraestruturapop'], resolve) } },

];

export default routers