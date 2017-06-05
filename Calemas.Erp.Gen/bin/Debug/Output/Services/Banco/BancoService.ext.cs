using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;

namespace Calemas.Erp.Domain.Services
{
    public class BancoService : BancoServiceBase, IBancoService
    {
        public BancoService(IBancoRepository rep, ICache cache) 
            : base(rep, cache)
        {


        }
        
    }
}
