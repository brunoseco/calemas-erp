using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class StatusSolicitacaoEstoqueMovimentacaoDtoSpecialized : StatusSolicitacaoEstoqueMovimentacaoDto
	{

        public IEnumerable<SolicitacaoEstoqueMovimentacaoDto> CollectionSolicitacaoEstoqueMovimentacao { get; set;} 

		
	}
}