using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class ClienteDtoSpecializedResult : ClienteDto
	{
        public  CondominioDto Condominio { get; set;} 
        public  PessoaDtoSpecializedResult Pessoa { get; set;} 
        public  StatusClienteDto StatusCliente { get; set;} 

		
	}
}