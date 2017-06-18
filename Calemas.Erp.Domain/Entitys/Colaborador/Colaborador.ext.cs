using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Colaborador : ColaboradorBase
    {

        public Colaborador()
        {

        }

        public virtual Pessoa Pessoa { get; set; }
        
        public Colaborador(int colaboradorid, string account, string password) :
            base(colaboradorid, account, password)
        {

        }

        public bool IsValid()
        {
            base._validationResult = new ColaboradorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
