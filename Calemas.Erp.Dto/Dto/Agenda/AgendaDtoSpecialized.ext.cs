using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class AgendaDtoSpecialized : AgendaDto
	{

        public IEnumerable<AgendaColaboradorDto> CollectionAgendaColaborador { get; set;} 
        public IEnumerable<OrdemServicoDto> CollectionOrdemServico { get; set;} 
        public  CorDto Cor { get; set;} 

		
	}
}