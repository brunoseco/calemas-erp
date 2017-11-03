using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class InfraestruturaSiteDtoSpecializedDetails : InfraestruturaSiteDto
	{

        public IEnumerable<InfraestruturaPopDto> CollectionInfraestruturaPop { get; set;} 

		
	}
}