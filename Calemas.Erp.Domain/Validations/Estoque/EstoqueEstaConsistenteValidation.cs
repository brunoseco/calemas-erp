using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueEstaConsistenteValidation : ValidatorSpecification<Estoque>
    {
        public EstoqueEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Estoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
