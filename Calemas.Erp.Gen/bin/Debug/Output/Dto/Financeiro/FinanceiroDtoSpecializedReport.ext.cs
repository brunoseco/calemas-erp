using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class FinanceiroDtoSpecializedReport : FinanceiroDto
	{

        public  PessoaDto Pessoa { get; set;} 
        public  PlanoContaDto PlanoConta { get; set;} 

		
	}
}