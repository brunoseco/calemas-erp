using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class InfraestruturaPopDtoSpecializedDetails : InfraestruturaPopDto
	{

        public IEnumerable<CondominioDto> CollectionCondominio { get; set;} 
        public  InfraestruturaSiteDto InfraestruturaSite { get; set;} 

		
	}
}