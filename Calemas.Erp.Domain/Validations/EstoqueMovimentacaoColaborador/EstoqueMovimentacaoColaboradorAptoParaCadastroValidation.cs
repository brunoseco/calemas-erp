using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueMovimentacaoColaboradorAptoParaCadastroValidation : ValidatorSpecification<EstoqueMovimentacaoColaborador>
    {
        public EstoqueMovimentacaoColaboradorAptoParaCadastroValidation(IEstoqueMovimentacaoColaboradorRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<EstoqueMovimentacaoColaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
