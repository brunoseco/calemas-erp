using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class BancoEstaConsistenteValidation : ValidatorSpecification<Banco>
    {
        public BancoEstaConsistenteValidation()
        {

            //base.Add("Key", new Rule<Banco>(Instance of RuleClassName,"message"));
        }

    }
}
