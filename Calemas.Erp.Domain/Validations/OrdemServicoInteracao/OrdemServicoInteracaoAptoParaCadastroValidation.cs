using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class OrdemServicoInteracaoAptoParaCadastroValidation : ValidatorSpecification<OrdemServicoInteracao>
    {
        public OrdemServicoInteracaoAptoParaCadastroValidation(IOrdemServicoInteracaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<OrdemServicoInteracao>(Instance of RuleClassName,"message for user"));
        }

    }
}
