using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaColaboradorEstaConsistenteValidation : ValidatorSpecification<AgendaColaborador>
    {
        public AgendaColaboradorEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<AgendaColaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
