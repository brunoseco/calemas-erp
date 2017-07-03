using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoPlanoContaAptoParaCadastroWarning : WarningSpecification<TipoPlanoConta>
    {
        public TipoPlanoContaAptoParaCadastroWarning(ITipoPlanoContaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoPlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
