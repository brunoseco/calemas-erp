
const routers = [
    { path: 'nivelacesso', name: 'NivelAcesso', component: function (resolve) { require(['@/views/nivelacesso'], resolve) } },
    { path: 'colaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/colaborador'], resolve) } },
    { path: 'ordemservico', name: 'OrdemServico', component: function (resolve) { require(['@/views/ordemservico'], resolve) } },
    { path: 'setor', name: 'Setor', component: function (resolve) { require(['@/views/setor'], resolve) } },
    { path: 'prioridade', name: 'Prioridade', component: function (resolve) { require(['@/views/prioridade'], resolve) } },
    { path: 'tipoordemservico', name: 'TipoOrdemServico', component: function (resolve) { require(['@/views/tipoordemservico'], resolve) } },
    { path: 'cor', name: 'Cor', component: function (resolve) { require(['@/views/cor'], resolve) } },

];

export default routers