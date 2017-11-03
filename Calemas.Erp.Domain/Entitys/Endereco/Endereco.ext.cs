using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;
using System.Collections.Generic;

namespace Calemas.Erp.Domain.Entitys
{
    public class Endereco : EnderecoBase
    {
        public virtual ICollection<Condominio> CollectionCondominio { get; set; }
        public Endereco()
        {

        }

        public Endereco(int enderecoid) :
            base(enderecoid)
        {

        }

        public class EnderecoFactory
        {
            public Endereco GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Endereco(data.EnderecoId);

                construction.SetarCEP(data.CEP);
                construction.SetarRua(data.Rua);
                construction.SetarNumero(data.Numero);
                construction.SetarComplemento(data.Complemento);
                construction.SetarBairro(data.Bairro);
                construction.SetarCidade(data.Cidade);
                construction.SetarUF(data.UF);

                construction.SetAttributeBehavior(data.AttributeBehavior);
                return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new EnderecoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }

    }
}
