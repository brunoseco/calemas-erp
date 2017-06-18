using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class PessoaAptoParaCadastroWarning : WarningSpecification<Pessoa>
    {
        public PessoaAptoParaCadastroWarning(IPessoaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Pessoa>(Instance of RuleClassName,"message for user"));
        }

    }
}
