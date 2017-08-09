using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class EstoqueDtoSpecializedReport : EstoqueDto
	{

        public IEnumerable<EstoqueMovimentacaoDto> CollectionEstoqueMovimentacao { get; set;} 
        public  CategoriaEstoqueDto CategoriaEstoque { get; set;} 
        public  UnidadeMedidaDto UnidadeMedida { get; set;} 

		
	}
}