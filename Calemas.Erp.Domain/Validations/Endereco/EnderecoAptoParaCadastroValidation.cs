using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EnderecoAptoParaCadastroValidation : ValidatorSpecification<Endereco>
    {
        public EnderecoAptoParaCadastroValidation(IEnderecoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Endereco>(Instance of RuleClassName,"message for user"));
        }

    }
}
