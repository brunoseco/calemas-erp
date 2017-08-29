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
        private IClienteRepository _clienteRepository;

        public OrdemServicoApplicationService(IOrdemServicoService service, IPrioridadeRepository prioridadeRepository, IClienteRepository clienteRepository, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
            this._prioridadeRepository = prioridadeRepository;
            this._clienteRepository = clienteRepository;
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
                {
                    _dto.StatusOrdemServicoId = (int)EStatusOrdemServico.Pendente;
                    _dto.DataSituacao = DateTime.Now;
                }

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Agenda.IsNotNull())
                {
                    this.DefineCorAgendaPelaPrioridade(_dto);
                    this.DefineTituloPeloCliente(_dto);
                    domain.Agenda = new Agenda.AgendaFactory().GetDefaultInstance(_dto.Agenda, this._user);

                    this.ConfiguraAgendaColaborador(domain);
                }

                return domain;
            });
        }

        private void DefineTituloPeloCliente(OrdemServicoDtoSpecialized dto)
        {
            var cliente = this._clienteRepository.GetById(new ClienteFilter { ClienteId = dto.ClienteId }).Result;
            dto.Agenda.Descricao = cliente.Pessoa.Nome;
        }

        private void ConfiguraAgendaColaborador(OrdemServico domain)
        {
            var agendaColaborador = new AgendaColaborador(domain.Agenda.AgendaId, domain.ResponsavelId);
            domain.Agenda.CollectionAgendaColaborador = new List<AgendaColaborador>() { agendaColaborador };
        }

        private void DefineCorAgendaPelaPrioridade(OrdemServicoDtoSpecialized _dto)
        {
            var prioridade = this._prioridadeRepository.GetById(new PrioridadeFilter { PrioridadeId = _dto.PrioridadeId }).Result;
            _dto.Agenda.CorId = prioridade.CorId;
        }

    }
}
