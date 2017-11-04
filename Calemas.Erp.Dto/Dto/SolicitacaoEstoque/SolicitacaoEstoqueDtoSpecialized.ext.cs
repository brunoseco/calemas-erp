using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueDtoSpecialized : SolicitacaoEstoqueDto
	{
        public IEnumerable<SolicitacaoEstoqueMovimentacaoDto> CollectionSolicitacaoEstoqueMovimentacao { get; set;} 
	}
}