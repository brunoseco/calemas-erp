using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class CategoriaEstoqueDtoSpecialized : CategoriaEstoqueDto
	{

        public IEnumerable<EstoqueDto> CollectionEstoque { get; set;} 

		
	}
}