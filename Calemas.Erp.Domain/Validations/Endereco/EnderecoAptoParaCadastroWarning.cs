using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class EnderecoAptoParaCadastroWarning : WarningSpecification<Endereco>
    {
        public EnderecoAptoParaCadastroWarning(IEnderecoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Endereco>(Instance of RuleClassName,"message for user"));
        }

    }
}
