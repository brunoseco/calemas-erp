using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Banco : BancoBase
    {

        public Banco()
        {

        }

        public Banco(int bancoid, string nome, bool boletosemregistro, bool boletocomregistro, bool ativo) :
            base(bancoid, nome, boletosemregistro, boletocomregistro, ativo)
        {

        }

        public bool IsValid()
        {
            base._validationResult = new BancoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
