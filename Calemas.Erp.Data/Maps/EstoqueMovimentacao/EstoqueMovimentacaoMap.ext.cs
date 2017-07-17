using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class EstoqueMovimentacaoMap : EstoqueMovimentacaoMapBase
    {
        public EstoqueMovimentacaoMap(EntityTypeBuilder<EstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<EstoqueMovimentacao> type)
        {

        }

    }
}