using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class MotivoEstoqueMovimentacaoAptoParaCadastroValidation : ValidatorSpecification<MotivoEstoqueMovimentacao>
    {
        public MotivoEstoqueMovimentacaoAptoParaCadastroValidation(IMotivoEstoqueMovimentacaoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<MotivoEstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
