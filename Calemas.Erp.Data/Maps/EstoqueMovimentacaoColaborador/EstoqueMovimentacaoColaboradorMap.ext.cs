using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class EstoqueMovimentacaoColaboradorMap : EstoqueMovimentacaoColaboradorMapBase
    {
        public EstoqueMovimentacaoColaboradorMap(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type)
        {

        }

    }
}