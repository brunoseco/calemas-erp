using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class UnidadeMedidaAptoParaCadastroValidation : ValidatorSpecification<UnidadeMedida>
    {
        public UnidadeMedidaAptoParaCadastroValidation(IUnidadeMedidaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<UnidadeMedida>(Instance of RuleClassName,"message for user"));
        }

    }
}
