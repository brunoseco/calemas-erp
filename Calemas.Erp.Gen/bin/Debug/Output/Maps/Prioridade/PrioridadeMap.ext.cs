using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class PrioridadeMap : PrioridadeMapBase
    {
        public PrioridadeMap(EntityTypeBuilder<Prioridade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Prioridade> type)
        {

        }

    }
}