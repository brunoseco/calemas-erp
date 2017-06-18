using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class PessoaBase : DomainBaseWithUserCreate
    {
        public PessoaBase()
        {

        }
        public PessoaBase(int pessoaid, string nome, string apelido)
        {
            this.PessoaId = pessoaid;
            this.Nome = nome;
            this.Apelido = apelido;

        }

        public int PessoaId { get; protected set; }
        public string CPF_CNPJ { get; protected set; }
        public string RG_IE { get; protected set; }
        public string Nome { get; protected set; }
        public string Apelido { get; protected set; }
        public string Email { get; protected set; }
        public string Telefone { get; protected set; }
        public string Celular { get; protected set; }
        public string Comercial { get; protected set; }
        public DateTime? DataNascimento { get; protected set; }
        public int? EstadoCivilId { get; protected set; }
        public int? Sexo { get; protected set; }
        public bool? Juridica { get; protected set; }
        public int? EnderecoId { get; protected set; }


		public virtual void SetarCPF_CNPJ(string cpf_cnpj)
		{
			this.CPF_CNPJ = cpf_cnpj;
		}
		public virtual void SetarRG_IE(string rg_ie)
		{
			this.RG_IE = rg_ie;
		}
		public virtual void SetarEmail(string email)
		{
			this.Email = email;
		}
		public virtual void SetarTelefone(string telefone)
		{
			this.Telefone = telefone;
		}
		public virtual void SetarCelular(string celular)
		{
			this.Celular = celular;
		}
		public virtual void SetarComercial(string comercial)
		{
			this.Comercial = comercial;
		}
		public virtual void SetarDataNascimento(DateTime? datanascimento)
		{
			this.DataNascimento = datanascimento;
		}
		public virtual void SetarEstadoCivilId(int? estadocivilid)
		{
			this.EstadoCivilId = estadocivilid;
		}
		public virtual void SetarSexo(int? sexo)
		{
			this.Sexo = sexo;
		}
		public virtual void SetarJuridica(bool? juridica)
		{
			this.Juridica = juridica;
		}
		public virtual void SetarEnderecoId(int? enderecoid)
		{
			this.EnderecoId = enderecoid;
		}


    }
}
