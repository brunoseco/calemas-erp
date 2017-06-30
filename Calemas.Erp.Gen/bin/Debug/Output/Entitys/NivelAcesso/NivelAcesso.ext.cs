using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class NivelAcesso : NivelAcessoBase
    {

        public NivelAcesso()
        {

        }

        public NivelAcesso(int nivelacessoid, string nome) :
            base(nivelacessoid, nome)
        {

        }

		public class NivelAcessoFactory
        {
            public NivelAcesso GetDefaaultInstance(dynamic data)
            {
                var construction = new NivelAcesso(<#parametersRequiredConstruction#>);

<#methodsSetersConstruction#>

				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new NivelAcessoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
