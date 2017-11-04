using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueDtoSpecializedResult : SolicitacaoEstoqueDto
	{
        public  ColaboradorDtoSpecializedResult Solicitante { get; set;} 
        public  StatusSolicitacaoEstoqueMovimentacaoDto StatusSolicitacaoEstoqueMovimentacao { get; set;} 
	}
}