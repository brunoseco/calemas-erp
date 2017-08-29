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
using System;

namespace Calemas.Erp.Application
{
    public class OrdemServicoInteracaoApplicationService : OrdemServicoInteracaoApplicationServiceBase
    {
        private IOrdemServicoService _serviceOrdemServico;
        public OrdemServicoInteracaoApplicationService(IOrdemServicoInteracaoService service, IOrdemServicoService serviceOrdemServico, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
            this._serviceOrdemServico = serviceOrdemServico;
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<OrdemServicoInteracao> dataList)
        {
            return base.MapperDomainToResult<OrdemServicoInteracaoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }

        protected override TDS MapperDomainToDto<TDS>(OrdemServicoInteracao model)
        {
            return base.MapperDomainToDto<OrdemServicoInteracaoDtoSpecialized>(model) as TDS;
        }

        protected override async Task<OrdemServicoInteracao> MapperDtoToDomain<TDS>(TDS dto)
        {
            return await Task.Run(() =>
            {
                var _dto = dto as OrdemServicoInteracaoDtoSpecialized;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.OrdemServico.IsNotNull())
                {
                    var ordemServico = this._serviceOrdemServico.GetOne(new OrdemServicoFilter { OrdemServicoId = domain.OrdemServicoId }).Result;
                    domain.OrdemServico = ordemServico;
                    domain.OrdemServico.StatusOrdemServico = null;
                    domain.OrdemServico.SetarDataSituacao(DateTime.Now);
                    domain.OrdemServico.SetarSituacao(_dto.StatusOrdemServicoId);
                }

                return domain;
            });
        }
    }
}
