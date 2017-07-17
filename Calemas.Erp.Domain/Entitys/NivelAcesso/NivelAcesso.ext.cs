using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
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
            public NivelAcesso GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new NivelAcesso(data.NivelAcessoId,
                                        data.Nome);



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
