using Common.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calemas.Erp.Gen
{
    public class ConfigExternalResources
    {
        
        private ExternalResource ConfigExternarResourcesTemplatesBackDDD()
        {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = true,
                ResouceRepositoryName = "template-gerador-back-DDD",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/template-gerador-back-DDD.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Pessoal",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Pessoal\calemas-erp\Calemas.Erp.Gen\Templates\Back"
            };

        }        

        public IEnumerable<ExternalResource> GetConfigExternarReources()
        {

            return new List<ExternalResource>
            {
                ConfigExternarResourcesTemplatesBackDDD(),
            };

        }


    }
}
