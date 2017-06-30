using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
    public class ColaboradorDtoSpecializedResult : ColaboradorDto
    {
        public NivelAcessoDto NivelAcesso { get; set; }
        public PessoaDto Pessoa { get; set; }
    }
}