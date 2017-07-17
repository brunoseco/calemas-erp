using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueMovimentacaoAptoParaCadastroValidation : ValidatorSpecification<EstoqueMovimentacao>
    {
        public EstoqueMovimentacaoAptoParaCadastroValidation(IEstoqueMovimentacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<EstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
