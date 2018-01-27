using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class MotivoEstoqueMovimentacaoDtoSpecializedReport : MotivoEstoqueMovimentacaoDto
	{

        public IEnumerable<EstoqueMovimentacaoDto> CollectionEstoqueMovimentacao { get; set;} 

		
	}
}