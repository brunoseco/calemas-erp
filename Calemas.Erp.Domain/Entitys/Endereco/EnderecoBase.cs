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

        public int EnderecoId { get; protected set; }
        public string CEP { get; protected set; }
        public string Rua { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string PontoReferencia { get; protected set; }
        public string Cidade { get; protected set; }
        public int? EstadoId { get; protected set; }


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
		public virtual void SetarPontoReferencia(string pontoreferencia)
		{
			this.PontoReferencia = pontoreferencia;
		}
		public virtual void SetarCidade(string cidade)
		{
			this.Cidade = cidade;
		}
		public virtual void SetarEstadoId(int? estadoid)
		{
			this.EstadoId = estadoid;
		}


    }
}
