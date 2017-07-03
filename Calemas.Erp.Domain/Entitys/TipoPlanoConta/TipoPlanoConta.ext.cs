using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoPlanoConta : TipoPlanoContaBase
    {

        public TipoPlanoConta()
        {

        }

        public TipoPlanoConta(int tipoplanocontaid, string nome) :
            base(tipoplanocontaid, nome)
        {

        }

		public class TipoPlanoContaFactory
        {
            public TipoPlanoConta GetDefaaultInstance(dynamic data)
            {
                var construction = new TipoPlanoConta(data.TipoPlanoContaId,
                                        data.Nome);



				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new TipoPlanoContaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
