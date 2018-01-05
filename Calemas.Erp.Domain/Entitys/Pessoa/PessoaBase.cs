using Common.Domain.Base;
using Common.Domain.Model;
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

        public virtual int PessoaId { get; protected set; }
        public virtual string CPF_CNPJ { get; protected set; }
        public virtual string RG_IE { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Apelido { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual string Celular { get; protected set; }
        public virtual string Comercial { get; protected set; }
        public virtual DateTime? DataNascimento { get; protected set; }
        public virtual int? EstadoCivilId { get; protected set; }
        public virtual int? Sexo { get; protected set; }
        public virtual bool? Juridica { get; protected set; }
        public virtual int? EnderecoId { get; protected set; }


public class PessoaFactoryBase
        {
            public virtual Pessoa GetDefaultInstanceBase(dynamic data, CurrentUser user)
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


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

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
