using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class FinanceiroAptoParaCadastroWarning : WarningSpecification<Financeiro>
    {
        public FinanceiroAptoParaCadastroWarning(IFinanceiroRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Financeiro>(Instance of RuleClassName,"message for user"));
        }

    }
}
