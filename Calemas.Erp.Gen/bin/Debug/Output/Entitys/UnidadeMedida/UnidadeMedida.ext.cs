using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class UnidadeMedida : UnidadeMedidaBase
    {

        public UnidadeMedida()
        {

        }

        public UnidadeMedida(int unidademedidaid, string nome) :
            base(unidademedidaid, nome)
        {

        }

		public class UnidadeMedidaFactory
        {
            public UnidadeMedida GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new UnidadeMedida(data.UnidadeMedidaId,
                                        data.Nome);



				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new UnidadeMedidaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
