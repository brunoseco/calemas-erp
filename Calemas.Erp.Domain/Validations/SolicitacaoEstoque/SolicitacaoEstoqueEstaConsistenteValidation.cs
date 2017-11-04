using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class SolicitacaoEstoqueEstaConsistenteValidation : ValidatorSpecification<SolicitacaoEstoque>
    {
        public SolicitacaoEstoqueEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SolicitacaoEstoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
