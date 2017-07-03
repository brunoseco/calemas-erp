using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class TipoPlanoContaDtoSpecializedReport : TipoPlanoContaDto
	{

        public IEnumerable<PlanoContaDto> CollectionPlanoConta { get; set;} 

		
	}
}