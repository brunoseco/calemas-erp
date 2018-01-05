using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class EnderecoBase : DomainBaseWithUserCreate
    {
        public EnderecoBase()
        {

        }
        public EnderecoBase(int enderecoid)
        {
            this.EnderecoId = enderecoid;

        }

        public virtual int EnderecoId { get; protected set; }
        public virtual string CEP { get; protected set; }
        public virtual string Rua { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual string Complemento { get; protected set; }
        public virtual string Bairro { get; protected set; }
        public virtual string Cidade { get; protected set; }
        public virtual string UF { get; protected set; }


public class EnderecoFactoryBase
        {
            public virtual Endereco GetDefaultInstanceBase(dynamic data, CurrentUser user)
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

		public virtual void SetarCEP(string cep)
		{
			this.CEP = cep;
		}
		public virtual void SetarRua(string rua)
		{
			this.Rua = rua;
		}
		public virtual void SetarNumero(string numero)
		{
			this.Numero = numero;
		}
		public virtual void SetarComplemento(string complemento)
		{
			this.Complemento = complemento;
		}
		public virtual void SetarBairro(string bairro)
		{
			this.Bairro = bairro;
		}
		public virtual void SetarCidade(string cidade)
		{
			this.Cidade = cidade;
		}
		public virtual void SetarUF(string uf)
		{
			this.UF = uf;
		}


    }
}
