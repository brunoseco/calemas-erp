using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class OrdemServicoInteracaoMap : OrdemServicoInteracaoMapBase
    {
        public OrdemServicoInteracaoMap(EntityTypeBuilder<OrdemServicoInteracao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<OrdemServicoInteracao> type)
        {

        }

    }
}