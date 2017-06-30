using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;

namespace Calemas.Erp.Domain.Services
{
    public class PrioridadeService : PrioridadeServiceBase, IPrioridadeService
    {

        public PrioridadeService(IPrioridadeRepository rep, ICache cache, CurrentUser user) 
            : base(rep, cache, user)
        {


        }
        
    }
}
