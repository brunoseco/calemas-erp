using Common.Domain.Base;
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
