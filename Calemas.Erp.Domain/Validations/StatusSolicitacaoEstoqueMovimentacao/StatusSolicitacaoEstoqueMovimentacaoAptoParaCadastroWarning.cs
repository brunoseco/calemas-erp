using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusSolicitacaoEstoqueMovimentacaoAptoParaCadastroWarning : WarningSpecification<StatusSolicitacaoEstoqueMovimentacao>
    {
        public StatusSolicitacaoEstoqueMovimentacaoAptoParaCadastroWarning(IStatusSolicitacaoEstoqueMovimentacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusSolicitacaoEstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
