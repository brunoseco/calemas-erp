using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class NivelAcessoEstaConsistenteValidation : ValidatorSpecification<NivelAcesso>
    {
        public NivelAcessoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<NivelAcesso>(Instance of RuleClassName,"message for user"));
        }

    }
}
