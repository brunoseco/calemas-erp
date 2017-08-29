using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;

namespace Calemas.Erp.Domain.Services
{
    public class OrdemServicoInteracaoService : OrdemServicoInteracaoServiceBase, IOrdemServicoInteracaoService
    {
        private IOrdemServicoRepository _repOrdemServico;
        public OrdemServicoInteracaoService(IOrdemServicoInteracaoRepository rep, IOrdemServicoRepository repOrdemServico, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repOrdemServico = repOrdemServico;
        }

        protected override OrdemServicoInteracao AddDefault(OrdemServicoInteracao ordemservicointeracao)
        {
            if (ordemservicointeracao.OrdemServico.IsNotNull())
                this._repOrdemServico.Update(ordemservicointeracao.OrdemServico);

            return base.AddDefault(ordemservicointeracao);
        }

    }
}
