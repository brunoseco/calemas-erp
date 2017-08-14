using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusOrdemServicoAptoParaCadastroWarning : WarningSpecification<StatusOrdemServico>
    {
        public StatusOrdemServicoAptoParaCadastroWarning(IStatusOrdemServicoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusOrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
