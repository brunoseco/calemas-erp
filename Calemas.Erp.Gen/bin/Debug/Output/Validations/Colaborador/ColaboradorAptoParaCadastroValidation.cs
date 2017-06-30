using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class ColaboradorAptoParaCadastroValidation : ValidatorSpecification<Colaborador>
    {
        public ColaboradorAptoParaCadastroValidation(IColaboradorRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Colaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
