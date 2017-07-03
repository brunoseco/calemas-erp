using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class FinanceiroEstaConsistenteValidation : ValidatorSpecification<Financeiro>
    {
        public FinanceiroEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Financeiro>(Instance of RuleClassName,"message for user"));
        }

    }
}
