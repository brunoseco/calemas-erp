using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Pessoa : PessoaBase
    {
        public virtual Colaborador Colaborador { get; set; }
        public Pessoa()
        {

        }

        public Pessoa(int pessoaid, string nome, string apelido) :
            base(pessoaid, nome, apelido)
        {

        }

		public class PessoaFactory
        {
            public Pessoa GetDefaaultInstance(dynamic data)
            {
                var construction = new Pessoa(data.PessoaId,
                                        data.Nome,
                                        data.Apelido);

                construction.SetarCPF_CNPJ(data.CPF_CNPJ);
                construction.SetarRG_IE(data.RG_IE);
                construction.SetarEmail(data.Email);
                construction.SetarTelefone(data.Telefone);
                construction.SetarCelular(data.Celular);
                construction.SetarComercial(data.Comercial);
                construction.SetarDataNascimento(data.DataNascimento);
                construction.SetarEstadoCivilId(data.EstadoCivilId);
                construction.SetarSexo(data.Sexo);
                construction.SetarJuridica(data.Juridica);
                construction.SetarEnderecoId(data.EnderecoId);


				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new PessoaEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
