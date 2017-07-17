using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Colaborador : ColaboradorBase
    {
        public virtual Pessoa Pessoa { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(int colaboradorid, string account, string password, bool ativo, int nivelacessoid) :
            base(colaboradorid, account, password, ativo, nivelacessoid)
        {

        }

		public class ColaboradorFactory
        {
            public Colaborador GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Colaborador(data.ColaboradorId,
                                        data.Account,
                                        data.Password,
                                        data.Ativo,
                                        data.NivelAcessoId);



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
