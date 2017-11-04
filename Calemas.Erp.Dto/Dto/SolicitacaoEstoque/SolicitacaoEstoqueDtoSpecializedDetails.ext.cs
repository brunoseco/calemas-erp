using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueDtoSpecializedDetails : SolicitacaoEstoqueDto
	{
        public  StatusSolicitacaoEstoqueMovimentacaoDto StatusSolicitacaoEstoqueMovimentacao { get; set;} 
	}
}