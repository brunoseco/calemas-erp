using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class PessoaDtoSpecialized : PessoaDto
	{
        public EnderecoDto Endereco { get; set;} 
	}
}