using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class AgendaColaboradorDto  : DtoBase
	{
	
        

        public virtual int AgendaId {get; set;}

        

        public virtual int ColaboradorId {get; set;}


		
	}
}