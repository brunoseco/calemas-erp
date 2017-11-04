using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System.Linq;

namespace Calemas.Erp.Domain.Services
{
    public class SolicitacaoEstoqueService : SolicitacaoEstoqueServiceBase, ISolicitacaoEstoqueService
    {
        private ISolicitacaoEstoqueMovimentacaoRepository _repMovimentacao;
        public SolicitacaoEstoqueService(ISolicitacaoEstoqueRepository rep, ISolicitacaoEstoqueMovimentacaoRepository repMovimentacao, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repMovimentacao = repMovimentacao;

        }

        public override void Remove(SolicitacaoEstoque solicitacaoestoque)
        {
            var movimentacoes = this._repMovimentacao.GetAll().Where(_ => _.SolicitacaoEstoqueId == solicitacaoestoque.SolicitacaoEstoqueId);
            this._repMovimentacao.RemoveRangeAndCommit(movimentacoes);
            this._rep.Remove(solicitacaoestoque);
        }

    }
}
