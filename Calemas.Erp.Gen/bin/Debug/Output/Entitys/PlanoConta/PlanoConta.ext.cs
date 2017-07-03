using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class PlanoConta : PlanoContaBase
    {

        public PlanoConta()
        {

        }

        public PlanoConta(int planocontaid, string nome, string descricao, int tipoplanocontaid) :
            base(planocontaid, nome, descricao, tipoplanocontaid)
        {

        }

		public class PlanoContaFactory
        {
            public PlanoConta GetDefaaultInstance(dynamic data)
            {
                var construction = new PlanoConta(data.PlanoContaId,
                                        data.Nome,
                                        data.Descricao,
                                        data.TipoPlanoContaId);



				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new PlanoContaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
