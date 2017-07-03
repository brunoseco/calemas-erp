using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class PlanoContaMap : PlanoContaMapBase
    {
        public PlanoContaMap(EntityTypeBuilder<PlanoConta> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<PlanoConta> type)
        {

        }

    }
}