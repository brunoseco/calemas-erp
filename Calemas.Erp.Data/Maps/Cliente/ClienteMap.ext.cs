using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class ClienteMap : ClienteMapBase
    {
        public ClienteMap(EntityTypeBuilder<Cliente> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Cliente> type)
        {
            type.HasOne(_ => _.Pessoa).WithOne(_ => _.Cliente).HasPrincipalKey<Pessoa>(_ => _.PessoaId).IsRequired();
        }

    }
}