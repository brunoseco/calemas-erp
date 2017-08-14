using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class StatusClienteMap : StatusClienteMapBase
    {
        public StatusClienteMap(EntityTypeBuilder<StatusCliente> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusCliente> type)
        {

        }

    }
}