using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class EstoqueMovimentacaoColaboradorEstaConsistenteValidation : ValidatorSpecification<EstoqueMovimentacaoColaborador>
    {
        public EstoqueMovimentacaoColaboradorEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<EstoqueMovimentacaoColaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
