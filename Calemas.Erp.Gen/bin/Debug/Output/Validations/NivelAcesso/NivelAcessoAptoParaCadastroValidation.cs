using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class NivelAcessoAptoParaCadastroValidation : ValidatorSpecification<NivelAcesso>
    {
        public NivelAcessoAptoParaCadastroValidation(INivelAcessoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<NivelAcesso>(Instance of RuleClassName,"message for user"));
        }

    }
}
