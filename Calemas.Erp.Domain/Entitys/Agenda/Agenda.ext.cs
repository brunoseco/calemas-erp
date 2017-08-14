using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class Agenda : AgendaBase
    {

        public Agenda()
        {

        }

        public Agenda(int agendaid, string nome, DateTime datainicio, DateTime datafim, int corid) :
            base(agendaid, nome, datainicio, datafim, corid)
        {

        }

		    public class AgendaFactory
        {
            public Agenda GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Agenda(data.AgendaId,
                                        data.Nome,
                                        data.DataInicio,
                                        data.DataFim,
                                        data.CorId);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new AgendaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
