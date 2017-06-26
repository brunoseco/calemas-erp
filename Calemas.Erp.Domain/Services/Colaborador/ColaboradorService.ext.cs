using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Services
{
    public class ColaboradorService : ColaboradorServiceBase, IColaboradorService
    {
        public ColaboradorService(IColaboradorRepository rep, ICache cache, CurrentUser user) 
            : base(rep, cache, user)
        {


        }
        
    }
}
