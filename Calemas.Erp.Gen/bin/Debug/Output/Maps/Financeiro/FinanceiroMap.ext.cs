using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class FinanceiroMap : FinanceiroMapBase
    {
        public FinanceiroMap(EntityTypeBuilder<Financeiro> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Financeiro> type)
        {

        }

    }
}