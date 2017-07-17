using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;
using Calemas.Erp.Domain.Filter;

namespace Calemas.Erp.Domain.Services
{
    public class EstoqueMovimentacaoService : EstoqueMovimentacaoServiceBase, IEstoqueMovimentacaoService
    {
        private IEstoqueRepository _repEstoque;

        public EstoqueMovimentacaoService(IEstoqueMovimentacaoRepository rep, IEstoqueRepository repEstoque, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {
            this._repEstoque = repEstoque;
        }

        public override async Task<EstoqueMovimentacao> DomainOrchestration(EstoqueMovimentacao entity, EstoqueMovimentacao entityOld)
        {
            var estoque = await _repEstoque.GetById(new EstoqueFilter() { EstoqueId = entity.EstoqueId });
            estoque.Movimentar(entity.Quantidade, entity.Entrada);
            entity.Estoque = estoque;
            return entity;
        }

        protected override EstoqueMovimentacao AddDefault(EstoqueMovimentacao estoquemovimentacao)
        {
            if (estoquemovimentacao.Estoque.IsNotNull())
                _repEstoque.Update(estoquemovimentacao.Estoque);

            return base.AddDefault(estoquemovimentacao);
        }

    }
}
