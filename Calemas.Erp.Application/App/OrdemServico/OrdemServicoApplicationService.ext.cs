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
        private ITipoOrdemServicoRepository _tipoOrdemServicoRepository;

        public OrdemServicoApplicationService(IOrdemServicoService service,
            IPrioridadeRepository prioridadeRepository,
            ITipoOrdemServicoRepository tipoOrdemServicoRepository,
            IClienteRepository clienteRepository,
            IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache, user)
        {
            this._prioridadeRepository = prioridadeRepository;
            this._clienteRepository = clienteRepository;
            this._tipoOrdemServicoRepository = tipoOrdemServicoRepository;
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
                    _dto.ResponsavelId = _user.GetSubjectId<int>();
                }

                var domain = base.MapperDtoToDomain(_dto).Result;

                if (_dto.Agenda.IsNotNull())
                {
                    this.DefineCorAgendaPelaPrioridade(_dto);
                    this.DefineTituloAgendaPeloTipoOrdemServico(_dto);
                    this.DefineDescricaoAgendaPeloCliente(_dto);
                    this.DefineDataFimAgenda(_dto);
                    domain.Agenda = new Agenda.AgendaFactory().GetDefaultInstance(_dto.Agenda, this._user);

                    if (_dto.ResponsavelIds.IsAny())
                        this.ConfiguraAgendaColaborador(_dto, domain);
                }

                return domain;
            });
        }

        private void DefineDataFimAgenda(OrdemServicoDtoSpecialized dto)
        {
            dto.Agenda.DataFim = dto.Agenda.DataInicio.AddHours(1);
        }

        private void DefineTituloAgendaPeloTipoOrdemServico(OrdemServicoDtoSpecialized dto)
        {
            var tipoOrdemServico = this._tipoOrdemServicoRepository.GetById(new TipoOrdemServicoFilter { TipoOrdemServicoId = dto.TipoOrdemServicoId }).Result;
            dto.Agenda.Nome = string.Format("{0} de {1}", "O.S.", tipoOrdemServico.Nome);
        }

        private void DefineDescricaoAgendaPeloCliente(OrdemServicoDtoSpecialized dto)
        {
            var cliente = this._clienteRepository.GetById(new ClienteFilter { ClienteId = dto.ClienteId }).Result;

            var condominio = cliente.Condominio;
            if (condominio.IsNotNull())
                dto.Agenda.Descricao = string.Format("{0} - ", condominio.Sigla);

            dto.Agenda.Descricao += cliente.Pessoa.Nome;
        }

        private void ConfiguraAgendaColaborador(OrdemServicoDtoSpecialized dto, OrdemServico domain)
        {
            domain.Agenda.CollectionAgendaColaborador = new List<AgendaColaborador>();

            foreach (var item in dto.ResponsavelIds)
                domain.Agenda.CollectionAgendaColaborador.Add(new AgendaColaborador(domain.Agenda.AgendaId, item));
        }

        private void DefineCorAgendaPelaPrioridade(OrdemServicoDtoSpecialized dto)
        {
            var prioridade = this._prioridadeRepository.GetById(new PrioridadeFilter { PrioridadeId = dto.PrioridadeId }).Result;
            dto.Agenda.CorId = prioridade.CorId;
        }

    }
}
