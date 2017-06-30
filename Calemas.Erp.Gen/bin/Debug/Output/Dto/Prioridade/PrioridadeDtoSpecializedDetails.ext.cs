using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class PrioridadeDtoSpecializedDetails : PrioridadeDto
	{

        public IEnumerable<OrdemServicoDto> CollectionOrdemServico { get; set;} 

		
	}
}