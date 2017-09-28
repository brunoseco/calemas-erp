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
using System.Threading.Tasks;

namespace Calemas.Erp.Application
{
    public class CondominioApplicationService : CondominioApplicationServiceBase
    {

        public CondominioApplicationService(ICondominioService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Condominio> dataList)
        {
            return base.MapperDomainToResult<CondominioDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }
        protected override TDS MapperDomainToDto<TDS>(Condominio model)
        {
            return base.MapperDomainToDto<CondominioDtoSpecialized>(model) as TDS;
        }

        protected override async Task<Condominio> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as CondominioDtoSpecialized;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Endereco.IsNotNull())
                    domain.Endereco = new Endereco.EnderecoFactory().GetDefaultInstance(_dto.Endereco, this._user);

                return domain;
            });
        }


    }
}
