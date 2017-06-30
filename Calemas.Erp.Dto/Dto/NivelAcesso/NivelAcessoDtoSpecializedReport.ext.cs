using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class NivelAcessoDtoSpecializedReport : NivelAcessoDto
	{

        public IEnumerable<ColaboradorDto> CollectionColaborador { get; set;} 

		
	}
}