using Common.Gen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calemas.Erp.Gen
{
    public class ConfigContext
    {
        #region Config Contexts

        public IEnumerable<Context> GetConfigContext()
        {

            return new List<Context>
            {
                this.ConfigContextCore(),
                this.ConfigContextVue()
            };

        }


        private Context ConfigContextCore()
        {
            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["Core"].ConnectionString,

                Namespace = "Calemas.Erp",
                ContextName = "Core",
                LengthBigField = 150,

                OutputClassDomain = ConfigurationManager.AppSettings["outputClassDomain"],
                OutputClassInfra = ConfigurationManager.AppSettings["outputClassInfra"],
                OutputClassDto = ConfigurationManager.AppSettings["outputClassDto"],
                OutputClassApp = ConfigurationManager.AppSettings["outputClassApp"],
                OutputClassApi = ConfigurationManager.AppSettings["outputClassApi"],
                OutputClassFilter = ConfigurationManager.AppSettings["outputClassFilter"],
                OutputClassSummary = ConfigurationManager.AppSettings["outputClassSummary"],

                Arquiteture = ArquitetureType.DDD,

                TableInfo = new UniqueListTableInfo
                {
                    new TableInfo { TableName = "Agenda", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "AgendaColaborador", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},

                    new TableInfo { TableName = "Cliente", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "Condominio", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "Endereco", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "StatusCliente", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "Pessoa", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "Colaborador", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "NivelAcesso", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

                    new TableInfo { TableName = "Cor", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "OrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Setor", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Prioridade", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "TipoOrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "StatusOrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

                    new TableInfo { TableName = "Financeiro", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "PlanoConta", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "TipoPlanoConta", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

                    new TableInfo { TableName = "CategoriaEstoque", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "UnidadeMedida", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Estoque", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "EstoqueMovimentacao", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },


                }
            };
        }

        private Context ConfigContextVue()
        {
            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["Core"].ConnectionString,

                Namespace = "calemas.erp",

                OutputAngular = ConfigurationManager.AppSettings["OutputVue"],
                CamelCasing = true,
                MakeFront = true,
                AlertNotFoundTable = true,

                TableInfo = new UniqueListTableInfo
                {
                    new TableInfo { TableName = "Colaborador", ClassNameFormated = "Colaborador", MakeFront = true,  },

                    new TableInfo { TableName = "CategoriaEstoque", ClassNameFormated = "Categoria de estoque", MakeFront = true,  },
                    new TableInfo { TableName = "UnidadeMedida", ClassNameFormated = "Unidade de medida", MakeFront = true,  },
                    new TableInfo { TableName = "Estoque", ClassNameFormated = "Estoque", MakeFront = true,  },
                    new TableInfo { TableName = "EstoqueMovimentacao", ClassNameFormated = "Movimentação de estoque", MakeFront = true,  },

                    new TableInfo { TableName = "Cliente", ClassNameFormated = "Cliente", MakeFront = true,  },
                    new TableInfo { TableName = "Condominio", ClassNameFormated = "Condomínio", MakeFront = true,  },

                    new TableInfo { TableName = "Agenda", ClassNameFormated = "Agenda", MakeFront = true,  },

                    new TableInfo { TableName = "StatusCliente", ClassNameFormated = "Situação do cliente", MakeFront = true,  },


                }
            };
        }


        #endregion
    }
}