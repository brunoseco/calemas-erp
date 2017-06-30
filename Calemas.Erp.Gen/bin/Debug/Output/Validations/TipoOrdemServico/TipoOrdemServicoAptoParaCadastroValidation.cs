using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoOrdemServicoAptoParaCadastroValidation : ValidatorSpecification<TipoOrdemServico>
    {
        public TipoOrdemServicoAptoParaCadastroValidation(ITipoOrdemServicoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoOrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
