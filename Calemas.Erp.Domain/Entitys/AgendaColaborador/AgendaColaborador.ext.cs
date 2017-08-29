using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class AgendaColaborador : AgendaColaboradorBase
    {

        public AgendaColaborador()
        {

        }

        public AgendaColaborador(int agendaid, int colaboradorid) :
            base(agendaid, colaboradorid)
        {

        }

        public class AgendaColaboradorFactory
        {
            public AgendaColaborador GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new AgendaColaborador(data.AgendaId,
                                        data.ColaboradorId);



                construction.SetAttributeBehavior(data.AttributeBehavior);
                return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new AgendaColaboradorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
