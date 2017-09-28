using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
    public class PessoaDtoSpecializedResult : PessoaDto
    {
        public EnderecoDto Endereco { get; set; }
    }
}