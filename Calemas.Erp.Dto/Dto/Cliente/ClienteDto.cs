using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class ClienteDto  : DtoBase
	{
	
        

        public virtual int ClienteId {get; set;}

        

        public virtual int StatusClienteId {get; set;}

        

        public virtual int? CondominioId {get; set;}

        

        public virtual int ResponsavelId {get; set;}


		
	}
}