using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class CondominioAptoParaCadastroWarning : WarningSpecification<Condominio>
    {
        public CondominioAptoParaCadastroWarning(ICondominioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Condominio>(Instance of RuleClassName,"message for user"));
        }

    }
}
