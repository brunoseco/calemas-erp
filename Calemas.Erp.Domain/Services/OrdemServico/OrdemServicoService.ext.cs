using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;
using Common.Domain.Base;
using System.Linq;

namespace Calemas.Erp.Domain.Services
{
    public class OrdemServicoService : OrdemServicoServiceBase, IOrdemServicoService
    {
        protected IAgendaRepository _repAgenda;
        protected IAgendaColaboradorRepository _repAgendaColaborador;
        public OrdemServicoService(IOrdemServicoRepository rep, IAgendaRepository repAgenda, IAgendaColaboradorRepository repAgendaColaborador, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repAgenda = repAgenda;
            this._repAgendaColaborador = repAgendaColaborador;
        }

        public override void Remove(OrdemServico model)
        {
            var alvo = this._rep.GetAll(_ => _.Agenda.CollectionAgendaColaborador).Where(_ => _.OrdemServicoId == model.OrdemServicoId).SingleOrDefault();

            if (alvo.Agenda.IsNotNull())
            {
                if (alvo.Agenda.CollectionAgendaColaborador.IsAny())
                    this._repAgendaColaborador.RemoveRange(alvo.Agenda.CollectionAgendaColaborador);

                this._repAgenda.Remove(alvo.Agenda);
            }

            this._rep.Remove(alvo);
        }

        public override Task<OrdemServico> DomainOrchestration(OrdemServico entity, OrdemServico entityOld)
        {
            if (entityOld.IsNull())
                entity.SetarDataSituacao(DateTime.Now);

            return base.DomainOrchestration(entity, entityOld);
        }

        public override OrdemServico AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var ordemServico = base.AuditDefault(entity, entityOld);
            if (ordemServico.Agenda.IsNotNull())
                base.AuditDefault(ordemServico.Agenda, entityOld);

            return ordemServico;
        }

        protected override OrdemServico UpdateDefault(OrdemServico ordemServico, OrdemServico ordemservicoOld)
        {
            if (ordemServico.Agenda.IsNotNull())
            {
                if (ordemServico.Agenda.CollectionAgendaColaborador.IsAny())
                {
                    this.RemoveCollectionAgendaColaborador(ordemServico, ordemservicoOld);
                    this.AdicionaCollectionAgendaColaborador(ordemServico, ordemservicoOld);
                }

                _repAgenda.Update(ordemServico.Agenda);
            }

            return base.UpdateDefault(ordemServico, ordemservicoOld);
        }

        private void AdicionaCollectionAgendaColaborador(OrdemServico ordemServico, OrdemServico ordemservicoOld)
        {
            foreach (var item in ordemServico.Agenda.CollectionAgendaColaborador)
            {
                var agendaColaboradorExistente = _repAgendaColaborador.GetAll()
                            .Where(_ => _.AgendaId == ordemservicoOld.AgendaId)
                            .Where(_ => _.ColaboradorId == item.ColaboradorId);

                if (agendaColaboradorExistente.IsNotAny())
                    _repAgendaColaborador.Add(item);
            }
        }

        private void RemoveCollectionAgendaColaborador(OrdemServico ordemServico, OrdemServico ordemservicoOld)
        {
            var agendaColaboradorExistente = _repAgendaColaborador.GetAll()
                                    .Where(_ => _.AgendaId == ordemservicoOld.AgendaId)
                                    .Where(_ => !ordemServico.Agenda.CollectionAgendaColaborador.Select(__ => __.ColaboradorId).Contains(_.ColaboradorId));

            if (agendaColaboradorExistente.IsAny())
                _repAgendaColaborador.RemoveRange(agendaColaboradorExistente);
        }
    }
}
