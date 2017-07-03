﻿using Common.Gen;
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
                    new TableInfo { TableName = "Pessoa", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true , MakeApp = true, MakeApi = true},
                    new TableInfo { TableName = "Cor", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "OrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Colaborador", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "NivelAcesso", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Setor", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Prioridade", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "TipoOrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

                    new TableInfo { TableName = "Financeiro", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "PlanoConta", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "TipoPlanoConta", MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

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
                    new TableInfo { TableName = "NivelAcesso", ClassNameFormated = "Nível de acesso", MakeFront = true,  },
                    new TableInfo { TableName = "Colaborador", ClassNameFormated = "Colaborador", MakeFront = true,  },
                    new TableInfo { TableName = "OrdemServico", ClassNameFormated = "Ordem de serviço", MakeFront = true,  },
                    new TableInfo { TableName = "Setor", ClassNameFormated = "Setor", MakeFront = true,  },
                    new TableInfo { TableName = "Prioridade", ClassNameFormated = "Prioridade", MakeFront = true,  },
                    new TableInfo { TableName = "TipoOrdemServico", ClassNameFormated = "Tipo de ordem de serviço", MakeFront = true,  },
                    new TableInfo { TableName = "Cor", ClassNameFormated = "Cores do sistema", MakeFront = true,  },

                    new TableInfo { TableName = "Financeiro", ClassNameFormated = "Financeiro", MakeFront = true,  },
                    new TableInfo { TableName = "PlanoConta", ClassNameFormated = "Plano de Conta", MakeFront = true,  },
                }
            };
        }


        #endregion
    }
}