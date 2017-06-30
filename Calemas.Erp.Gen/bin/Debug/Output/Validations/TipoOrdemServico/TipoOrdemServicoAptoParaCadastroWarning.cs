using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoOrdemServicoAptoParaCadastroWarning : WarningSpecification<TipoOrdemServico>
    {
        public TipoOrdemServicoAptoParaCadastroWarning(ITipoOrdemServicoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoOrdemServico>(Instance of RuleClassName,"message for user"));
        }

    }
}
