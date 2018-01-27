using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class MotivoEstoqueMovimentacaoEstaConsistenteValidation : ValidatorSpecification<MotivoEstoqueMovimentacao>
    {
        public MotivoEstoqueMovimentacaoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<MotivoEstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
