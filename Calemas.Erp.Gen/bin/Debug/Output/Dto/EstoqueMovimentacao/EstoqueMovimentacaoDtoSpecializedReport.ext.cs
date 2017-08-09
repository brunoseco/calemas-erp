using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class EstoqueMovimentacaoDtoSpecializedReport : EstoqueMovimentacaoDto
	{

        public  ColaboradorDto Colaborador { get; set;} 
        public  EstoqueDto Estoque { get; set;} 

		
	}
}