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
    public class EnderecoApplicationService : EnderecoApplicationServiceBase
    {

        public EnderecoApplicationService(IEnderecoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Endereco> dataList)
        {
            return base.MapperDomainToResult<EnderecoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
