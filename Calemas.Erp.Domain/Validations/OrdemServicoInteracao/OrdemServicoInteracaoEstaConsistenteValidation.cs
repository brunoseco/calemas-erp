using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class OrdemServicoInteracaoEstaConsistenteValidation : ValidatorSpecification<OrdemServicoInteracao>
    {
        public OrdemServicoInteracaoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<OrdemServicoInteracao>(Instance of RuleClassName,"message for user"));
        }

    }
}
