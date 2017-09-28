using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
    public class SolicitacaoEstoqueMovimentacaoDtoSpecializedResult : SolicitacaoEstoqueMovimentacaoDto
    {

        public EstoqueDto Estoque { get; set; }
        public StatusSolicitacaoEstoqueMovimentacaoDto StatusSolicitacaoEstoqueMovimentacao { get; set; }
        public ColaboradorDtoSpecializedResult Solicitante { get; set; }


    }
}