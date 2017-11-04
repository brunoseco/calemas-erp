using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class SolicitacaoEstoqueAptoParaCadastroValidation : ValidatorSpecification<SolicitacaoEstoque>
    {
        public SolicitacaoEstoqueAptoParaCadastroValidation(ISolicitacaoEstoqueRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SolicitacaoEstoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
