using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class UnidadeMedidaEstaConsistenteValidation : ValidatorSpecification<UnidadeMedida>
    {
        public UnidadeMedidaEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<UnidadeMedida>(Instance of RuleClassName,"message for user"));
        }

    }
}
