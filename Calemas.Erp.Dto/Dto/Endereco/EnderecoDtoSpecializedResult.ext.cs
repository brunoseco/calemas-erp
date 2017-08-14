using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class EnderecoDtoSpecializedResult : EnderecoDto
	{

        public IEnumerable<PessoaDto> CollectionPessoa { get; set;} 

		
	}
}