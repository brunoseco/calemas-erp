using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class MotivoEstoqueMovimentacaoDtoSpecializedDetails : MotivoEstoqueMovimentacaoDto
	{

        public IEnumerable<EstoqueMovimentacaoDto> CollectionEstoqueMovimentacao { get; set;} 

		
	}
}