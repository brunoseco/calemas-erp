using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class StatusSolicitacaoEstoqueMovimentacaoMap : StatusSolicitacaoEstoqueMovimentacaoMapBase
    {
        public StatusSolicitacaoEstoqueMovimentacaoMap(EntityTypeBuilder<StatusSolicitacaoEstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusSolicitacaoEstoqueMovimentacao> type)
        {

        }

    }
}