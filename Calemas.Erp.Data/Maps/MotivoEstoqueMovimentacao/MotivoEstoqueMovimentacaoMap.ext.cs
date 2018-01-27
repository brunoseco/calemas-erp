using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class MotivoEstoqueMovimentacaoMap : MotivoEstoqueMovimentacaoMapBase
    {
        public MotivoEstoqueMovimentacaoMap(EntityTypeBuilder<MotivoEstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<MotivoEstoqueMovimentacao> type)
        {

        }

    }
}