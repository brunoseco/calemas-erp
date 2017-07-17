using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class CategoriaEstoqueEstaConsistenteValidation : ValidatorSpecification<CategoriaEstoque>
    {
        public CategoriaEstoqueEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<CategoriaEstoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
