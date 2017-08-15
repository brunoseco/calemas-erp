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
    public class OrdemServicoApplicationService : OrdemServicoApplicationServiceBase
    {

        public OrdemServicoApplicationService(IOrdemServicoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {

        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<OrdemServico> dataList)
        {
            return base.MapperDomainToResult<OrdemServicoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }

        protected override TDS MapperDomainToDto<TDS>(OrdemServico model)
        {
            return base.MapperDomainToDto<OrdemServicoDtoSpecialized>(model) as TDS;
        }

        protected override async Task<OrdemServico> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as OrdemServicoDtoSpecialized;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Agenda.IsNotNull())
                    domain.Agenda = new Agenda.AgendaFactory().GetDefaultInstance(_dto.Agenda, this._user);

                return domain;
            });
        }


    }
}
