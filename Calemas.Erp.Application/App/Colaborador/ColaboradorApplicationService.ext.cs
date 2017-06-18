using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;

namespace Calemas.Erp.Application
{
    public class ColaboradorApplicationService : ColaboradorApplicationServiceBase
    {

        public ColaboradorApplicationService(IColaboradorService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
  
        }


    }
}
