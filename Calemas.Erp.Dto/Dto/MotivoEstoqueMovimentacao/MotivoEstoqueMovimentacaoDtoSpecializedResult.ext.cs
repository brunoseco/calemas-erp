using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class MotivoEstoqueMovimentacaoDtoSpecializedResult : MotivoEstoqueMovimentacaoDto
	{

        public IEnumerable<EstoqueMovimentacaoDto> CollectionEstoqueMovimentacao { get; set;} 

		
	}
}