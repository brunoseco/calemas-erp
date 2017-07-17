using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueAptoParaCadastroWarning : WarningSpecification<Estoque>
    {
        public EstoqueAptoParaCadastroWarning(IEstoqueRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Estoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
