using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoOrdemServicoEstaConsistenteValidation : ValidatorSpecification<TipoOrdemServico>
    {
        public TipoOrdemServicoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoOrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
