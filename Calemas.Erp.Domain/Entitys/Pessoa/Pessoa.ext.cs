using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Pessoa : PessoaBase
    {

        public Pessoa()
        {

        }

        public virtual Colaborador Colaborador { get; set; }

        public Pessoa(int pessoaid, string nome, string apelido) :
            base(pessoaid, nome, apelido)
        {

        }

        public bool IsValid()
        {
            base._validationResult = new PessoaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
