using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class Endereco : EnderecoBase
    {

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
                construction.SetarPontoReferencia(data.PontoReferencia);
                construction.SetarCidade(data.Cidade);
                construction.SetarEstadoId(data.EstadoId);


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
