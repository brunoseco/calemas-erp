using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class CondominioDtoSpecializedReport : CondominioDto
	{

        public IEnumerable<ClienteDto> CollectionCliente { get; set;} 

		
	}
}