using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class EnderecoDto  : DtoBase
	{
	
        

        public virtual int EnderecoId {get; set;}

        

        public virtual string CEP {get; set;}

        

        public virtual string Rua {get; set;}

        

        public virtual string Numero {get; set;}

        

        public virtual string Complemento {get; set;}

        

        public virtual string Bairro {get; set;}

        

        public virtual string Cidade {get; set;}

        

        public virtual string UF {get; set;}


		
	}
}