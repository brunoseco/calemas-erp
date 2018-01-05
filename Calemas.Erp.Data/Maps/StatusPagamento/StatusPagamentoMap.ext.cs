using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class StatusPagamentoMap : StatusPagamentoMapBase
    {
        public StatusPagamentoMap(EntityTypeBuilder<StatusPagamento> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusPagamento> type)
        {

        }

    }
}