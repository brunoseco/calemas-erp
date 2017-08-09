using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class CategoriaEstoqueAptoParaCadastroValidation : ValidatorSpecification<CategoriaEstoque>
    {
        public CategoriaEstoqueAptoParaCadastroValidation(ICategoriaEstoqueRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<CategoriaEstoque>(Instance of RuleClassName,"message for user"));
        }

    }
}
