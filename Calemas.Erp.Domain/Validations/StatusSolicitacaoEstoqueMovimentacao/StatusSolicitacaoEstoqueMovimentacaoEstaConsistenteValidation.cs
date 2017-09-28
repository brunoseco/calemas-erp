using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusSolicitacaoEstoqueMovimentacaoEstaConsistenteValidation : ValidatorSpecification<StatusSolicitacaoEstoqueMovimentacao>
    {
        public StatusSolicitacaoEstoqueMovimentacaoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusSolicitacaoEstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
