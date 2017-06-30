using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class NivelAcessoMap : NivelAcessoMapBase
    {
        public NivelAcessoMap(EntityTypeBuilder<NivelAcesso> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<NivelAcesso> type)
        {

        }

    }
}