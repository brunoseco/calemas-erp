using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class EnderecoMap : EnderecoMapBase
    {
        public EnderecoMap(EntityTypeBuilder<Endereco> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Endereco> type)
        {

        }

    }
}