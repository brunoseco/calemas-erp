using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class EnderecoEstaConsistenteValidation : ValidatorSpecification<Endereco>
    {
        public EnderecoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Endereco>(Instance of RuleClassName,"message for user"));
        }

    }
}
