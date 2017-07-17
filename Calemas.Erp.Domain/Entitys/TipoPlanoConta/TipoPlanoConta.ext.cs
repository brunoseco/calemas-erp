using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
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
            public TipoPlanoConta GetDefaultInstance(dynamic data, CurrentUser user)
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
