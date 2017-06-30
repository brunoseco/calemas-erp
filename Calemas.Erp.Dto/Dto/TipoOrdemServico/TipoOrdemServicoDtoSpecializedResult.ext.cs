using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class TipoOrdemServicoDtoSpecializedResult : TipoOrdemServicoDto
	{

        public IEnumerable<OrdemServicoDto> CollectionOrdemServico { get; set;} 

		
	}
}