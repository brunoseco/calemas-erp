using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;

namespace Calemas.Erp.Application
{
    public class NivelAcessoApplicationService : NivelAcessoApplicationServiceBase
    {

        public NivelAcessoApplicationService(INivelAcessoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<NivelAcesso> dataList)
        {
            return base.MapperDomainToResult<NivelAcessoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
