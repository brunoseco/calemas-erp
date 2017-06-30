using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Prioridade : PrioridadeBase
    {

        public Prioridade()
        {

        }

        public Prioridade(int prioridadeid, string nome, int corid, bool ativo) :
            base(prioridadeid, nome, corid, ativo)
        {

        }

		public class PrioridadeFactory
        {
            public Prioridade GetDefaaultInstance(dynamic data)
            {
                var construction = new Prioridade(data.PrioridadeId,
                                        data.Nome,
                                        data.CorId,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new PrioridadeEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
