using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class EstoqueMap : EstoqueMapBase
    {
        public EstoqueMap(EntityTypeBuilder<Estoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Estoque> type)
        {

        }

    }
}