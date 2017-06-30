using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class CorAptoParaCadastroWarning : WarningSpecification<Cor>
    {
        public CorAptoParaCadastroWarning(ICorRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Cor>(Instance of RuleClassName,"message for user"));
        }

    }
}
