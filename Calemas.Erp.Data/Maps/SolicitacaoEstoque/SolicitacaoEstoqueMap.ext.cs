using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class SolicitacaoEstoqueMap : SolicitacaoEstoqueMapBase
    {
        public SolicitacaoEstoqueMap(EntityTypeBuilder<SolicitacaoEstoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SolicitacaoEstoque> type)
        {
            type.HasOne(_ => _.Solicitante).WithMany().HasForeignKey(_ => _.SolicitanteId).IsRequired();
        }

    }
}