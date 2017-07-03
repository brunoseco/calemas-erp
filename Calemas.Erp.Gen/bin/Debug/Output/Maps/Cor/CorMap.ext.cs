using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class CorMap : CorMapBase
    {
        public CorMap(EntityTypeBuilder<Cor> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Cor> type)
        {

        }

    }
}