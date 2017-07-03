using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class CorDtoSpecializedDetails : CorDto
	{

        public IEnumerable<PrioridadeDto> CollectionPrioridade { get; set;} 
        public IEnumerable<SetorDto> CollectionSetor { get; set;} 

		
	}
}