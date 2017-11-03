using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class InfraestruturaSiteMap : InfraestruturaSiteMapBase
    {
        public InfraestruturaSiteMap(EntityTypeBuilder<InfraestruturaSite> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<InfraestruturaSite> type)
        {

        }

    }
}