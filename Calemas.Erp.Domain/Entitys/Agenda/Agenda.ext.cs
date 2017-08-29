using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;
using System.Collections;
using System.Collections.Generic;

namespace Calemas.Erp.Domain.Entitys
{
    public class Agenda : AgendaBase
    {
        public virtual ICollection<AgendaColaborador> CollectionAgendaColaborador { get; set; }
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

        public virtual void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        public bool IsValid()
        {
            base._validationResult = new AgendaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
