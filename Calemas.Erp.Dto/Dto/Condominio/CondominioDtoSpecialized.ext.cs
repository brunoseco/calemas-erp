using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class CondominioDtoSpecialized : CondominioDto
	{

        public IEnumerable<ClienteDto> CollectionCliente { get; set;} 

		
	}
}