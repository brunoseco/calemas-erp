using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class UnidadeMedidaDtoSpecializedResult : UnidadeMedidaDto
	{

        public IEnumerable<EstoqueDto> CollectionEstoque { get; set;} 

		
	}
}