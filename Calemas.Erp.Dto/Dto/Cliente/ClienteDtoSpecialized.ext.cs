using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class ClienteDtoSpecialized : ClienteDto
	{
        public  PessoaDtoSpecialized Pessoa { get; set;} 
	}
}