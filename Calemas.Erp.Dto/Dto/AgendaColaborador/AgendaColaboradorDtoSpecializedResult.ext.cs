using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class AgendaColaboradorDtoSpecializedResult : AgendaColaboradorDto
	{

        public  AgendaDto Agenda { get; set;} 
        public  ColaboradorDto Colaborador { get; set;} 

		
	}
}