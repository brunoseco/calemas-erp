using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class NivelAcessoDtoSpecializedResult : NivelAcessoDto
	{

        public IEnumerable<ColaboradorDto> CollectionColaborador { get; set;} 

		
	}
}