using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class PlanoContaDtoSpecializedDetails : PlanoContaDto
	{

        public IEnumerable<FinanceiroDto> CollectionFinanceiro { get; set;} 
        public  TipoPlanoContaDto TipoPlanoConta { get; set;} 

		
	}
}