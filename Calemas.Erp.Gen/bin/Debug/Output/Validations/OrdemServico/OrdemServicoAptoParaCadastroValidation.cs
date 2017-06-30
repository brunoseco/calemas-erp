using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class OrdemServicoAptoParaCadastroValidation : ValidatorSpecification<OrdemServico>
    {
        public OrdemServicoAptoParaCadastroValidation(IOrdemServicoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<OrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
