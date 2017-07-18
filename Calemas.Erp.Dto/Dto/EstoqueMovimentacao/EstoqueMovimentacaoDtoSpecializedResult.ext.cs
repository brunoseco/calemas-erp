using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class EstoqueMovimentacaoDtoSpecializedResult : EstoqueMovimentacaoDto
	{

        public  ColaboradorDtoSpecializedResult Colaborador { get; set;} 
        public  EstoqueDto Estoque { get; set;}

        public DateTime UserCreateDate { get; set; }

    }
}