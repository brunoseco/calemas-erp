using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class BancoBase : DomainBaseWithUserCreate
    {
        public BancoBase()
        {

        }
        public BancoBase(int bancoid, string nome, bool boletosemregistro, bool boletocomregistro, bool ativo)
        {
            this.BancoId = bancoid;
            this.Nome = nome;
            this.BoletoSemRegistro = boletosemregistro;
            this.BoletoComRegistro = boletocomregistro;
            this.Ativo = ativo;

        }

        public int BancoId { get; protected set; }
        public string Nome { get; protected set; }
        public string Numero { get; protected set; }
        public string Digito { get; protected set; }
        public bool BoletoSemRegistro { get; protected set; }
        public bool BoletoComRegistro { get; protected set; }
        public bool Ativo { get; protected set; }


		public virtual void SetarNumero(string numero)
		{
			this.Numero = numero;
		}
		public virtual void SetarDigito(string digito)
		{
			this.Digito = digito;
		}


    }
}
