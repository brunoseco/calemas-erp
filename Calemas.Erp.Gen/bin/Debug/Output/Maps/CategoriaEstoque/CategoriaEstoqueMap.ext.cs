using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class CategoriaEstoqueMap : CategoriaEstoqueMapBase
    {
        public CategoriaEstoqueMap(EntityTypeBuilder<CategoriaEstoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<CategoriaEstoque> type)
        {

        }

    }
}