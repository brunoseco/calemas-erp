using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class StatusPagamentoDtoSpecialized : StatusPagamentoDto
	{

        public IEnumerable<OrdemServicoDto> CollectionOrdemServico { get; set;} 

		
	}
}