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
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Enums.Domain;

namespace Calemas.Erp.Application
{
    public class OrdemServicoApplicationService : OrdemServicoApplicationServiceBase
    {
        private IPrioridadeRepository _prioridadeRepository;

        public OrdemServicoApplicationService(IOrdemServicoService service, IPrioridadeRepository prioridadeRepository, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
            this._prioridadeRepository = prioridadeRepository;
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

                if (!_dto.StatusOrdemServicoId.IsSent())
                    _dto.StatusOrdemServicoId = (int)EStatusOrdemServico.Pendente;

                if (!_dto.DataSituacao.IsSent())
                    _dto.DataSituacao = DateTime.Now;

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Agenda.IsNotNull())
                {
                    var prioridade = this._prioridadeRepository.GetById(new PrioridadeFilter { PrioridadeId = _dto.PrioridadeId }).Result;
                    _dto.Agenda.CorId = prioridade.CorId;
                    domain.Agenda = new Agenda.AgendaFactory().GetDefaultInstance(_dto.Agenda, this._user);
                }

                return domain;
            });
        }


    }
}
