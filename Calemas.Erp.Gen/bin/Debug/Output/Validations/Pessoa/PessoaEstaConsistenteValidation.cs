using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class PessoaEstaConsistenteValidation : ValidatorSpecification<Pessoa>
    {
        public PessoaEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Pessoa>(Instance of RuleClassName,"message for user"));
        }

    }
}
