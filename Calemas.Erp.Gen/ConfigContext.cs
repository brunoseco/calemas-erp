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
                //this.ConfigContextAngular()
            };

        }


        private Context ConfigContextCore()
        {
            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["PortalFranqueador"].ConnectionString,

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
                    new TableInfo { TableName = "OrdemServico", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "Colaborador", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true, MakeApp = true, MakeApi = true },
                    new TableInfo { TableName = "NivelAcesso", MakeCrud = true, MakeDomain = true, MakeDto = true, MakeSummary = true, MakeApp = true, MakeApi = true },

                    new TableInfo { TableName = "Pessoa", MakeCrud = true, MakeDomain = true, MakeDto = true , MakeSummary = true },
                }
            };
        }
        
        #endregion
    }
}