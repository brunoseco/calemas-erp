using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Colaborador : ColaboradorBase
    {

        public Colaborador()
        {

        }

        public Colaborador(int colaboradorid, string account, string password, bool ativo, int nivelacessoid) :
            base(colaboradorid, account, password, ativo, nivelacessoid)
        {

        }

		public class ColaboradorFactory
        {
            public Colaborador GetDefaaultInstance(dynamic data)
            {
                var construction = new Colaborador(<#parametersRequiredConstruction#>);

<#methodsSetersConstruction#>

				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new ColaboradorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
