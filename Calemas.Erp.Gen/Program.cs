using Common.Gen;
using System;

namespace Calemas.Erp.Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperFlow.Flow(args, () =>
            {
                return new ConfigExternalResources().GetConfigExternarReources();
            }, new HelperSysObjects(new ConfigContext().GetConfigContext()));
        }

        
    }
}
