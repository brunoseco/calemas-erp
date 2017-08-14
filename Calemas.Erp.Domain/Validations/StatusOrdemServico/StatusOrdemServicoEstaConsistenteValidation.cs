using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusOrdemServicoEstaConsistenteValidation : ValidatorSpecification<StatusOrdemServico>
    {
        public StatusOrdemServicoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusOrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
