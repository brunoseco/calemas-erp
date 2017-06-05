using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class OrdemServicoEstaConsistenteValidation : ValidatorSpecification<OrdemServico>
    {
        public OrdemServicoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<OrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
