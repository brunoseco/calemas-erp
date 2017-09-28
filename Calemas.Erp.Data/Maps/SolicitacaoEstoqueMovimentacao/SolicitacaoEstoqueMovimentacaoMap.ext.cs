using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class SolicitacaoEstoqueMovimentacaoMap : SolicitacaoEstoqueMovimentacaoMapBase
    {
        public SolicitacaoEstoqueMovimentacaoMap(EntityTypeBuilder<SolicitacaoEstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SolicitacaoEstoqueMovimentacao> type)
        {
            type.HasOne(_ => _.Solicitante).WithMany().HasForeignKey(_ => _.SolicitanteId).IsRequired();

        }

    }
}