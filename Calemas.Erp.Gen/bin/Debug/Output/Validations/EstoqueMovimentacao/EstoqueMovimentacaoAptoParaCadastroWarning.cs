using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueMovimentacaoAptoParaCadastroWarning : WarningSpecification<EstoqueMovimentacao>
    {
        public EstoqueMovimentacaoAptoParaCadastroWarning(IEstoqueMovimentacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<EstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
