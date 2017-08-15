using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;
using Common.Domain.Base;

namespace Calemas.Erp.Domain.Services
{
    public class OrdemServicoService : OrdemServicoServiceBase, IOrdemServicoService
    {
        protected IAgendaRepository _repAgenda;
        public OrdemServicoService(IOrdemServicoRepository rep, IAgendaRepository repAgenda, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repAgenda = repAgenda;
        }

        public override Task<OrdemServico> DomainOrchestration(OrdemServico entity, OrdemServico entityOld)
        {
            if (entityOld.IsNull())
                entity.SetarDataSituacao(DateTime.Now);

            if (entity.Agenda.IsNotNull())
                entity.Agenda.SetarNome("Ordem de serviço");

            return base.DomainOrchestration(entity, entityOld);
        }

        public override OrdemServico AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var ordemServico = base.AuditDefault(entity, entityOld);
            if (ordemServico.Agenda.IsNotNull())
                base.AuditDefault(ordemServico.Agenda, entityOld);

            return ordemServico;
        }


        protected override OrdemServico UpdateDefault(OrdemServico ordemServico)
        {
            if (ordemServico.Agenda.IsNotNull())
                _repAgenda.Update(ordemServico.Agenda);

            return base.UpdateDefault(ordemServico);
        }

    }
}
