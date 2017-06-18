using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class ColaboradorEstaConsistenteValidation : ValidatorSpecification<Colaborador>
    {
        public ColaboradorEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Colaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
