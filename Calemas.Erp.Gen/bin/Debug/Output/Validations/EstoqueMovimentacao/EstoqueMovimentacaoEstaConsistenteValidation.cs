using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueMovimentacaoEstaConsistenteValidation : ValidatorSpecification<EstoqueMovimentacao>
    {
        public EstoqueMovimentacaoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<EstoqueMovimentacao>(Instance of RuleClassName,"message for user"));
        }

    }
}
