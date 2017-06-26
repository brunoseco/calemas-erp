using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class PessoaMap : PessoaMapBase
    {
        public PessoaMap(EntityTypeBuilder<Pessoa> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Pessoa> type)
        {
        }

    }
}