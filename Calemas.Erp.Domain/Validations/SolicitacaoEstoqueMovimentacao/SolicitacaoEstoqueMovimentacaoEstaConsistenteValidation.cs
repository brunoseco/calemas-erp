using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class SolicitacaoEstoqueMovimentacaoEstaConsistenteValidation : ValidatorSpecification<SolicitacaoEstoqueMovimentacao>
    {
        public SolicitacaoEstoqueMovimentacaoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SolicitacaoEstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
