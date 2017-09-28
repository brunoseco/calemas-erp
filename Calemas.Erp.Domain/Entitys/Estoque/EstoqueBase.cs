using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueBase : DomainBaseWithUserCreate
    {
        public EstoqueBase()
        {

        }
        public EstoqueBase(int estoqueid, string nome, int unidademedidaid, int categoriaestoqueid, decimal quantidademinima, decimal quantidade, bool ativo)
        {
            this.EstoqueId = estoqueid;
            this.Nome = nome;
            this.UnidadeMedidaId = unidademedidaid;
            this.CategoriaEstoqueId = categoriaestoqueid;
            this.QuantidadeMinima = quantidademinima;
            this.Quantidade = quantidade;
            this.Ativo = ativo;

        }

        public virtual int EstoqueId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Modelo { get; protected set; }
        public virtual string Fabricante { get; protected set; }
        public virtual string Referencia { get; protected set; }
        public virtual int UnidadeMedidaId { get; protected set; }
        public virtual int CategoriaEstoqueId { get; protected set; }
        public virtual string Observacao { get; protected set; }
        public virtual decimal QuantidadeMinima { get; protected set; }
        public virtual decimal Quantidade { get; protected set; }
        public virtual decimal? ValorVenda { get; protected set; }
        public virtual decimal? ValorCompra { get; protected set; }
        public virtual bool Ativo { get; protected set; }
        public virtual string Localizacao { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}
		public virtual void SetarModelo(string modelo)
		{
			this.Modelo = modelo;
		}
		public virtual void SetarFabricante(string fabricante)
		{
			this.Fabricante = fabricante;
		}
		public virtual void SetarReferencia(string referencia)
		{
			this.Referencia = referencia;
		}
		public virtual void SetarObservacao(string observacao)
		{
			this.Observacao = observacao;
		}
		public virtual void SetarValorVenda(decimal? valorvenda)
		{
			this.ValorVenda = valorvenda;
		}
		public virtual void SetarValorCompra(decimal? valorcompra)
		{
			this.ValorCompra = valorcompra;
		}
		public virtual void SetarLocalizacao(string localizacao)
		{
			this.Localizacao = localizacao;
		}


    }
}
