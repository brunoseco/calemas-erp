using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class BancoAptoParaCadastroValidation : ValidatorSpecification<Banco>
    {
        public BancoAptoParaCadastroValidation(IBancoRepository rep)
        {

            //base.Add("Key", new Rule<Banco>(Instance of RuleClassName,"message"));
        }

    }
}
