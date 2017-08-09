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

        public int EstoqueId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public string Modelo { get; protected set; }
        public string Fabricante { get; protected set; }
        public string Referencia { get; protected set; }
        public int UnidadeMedidaId { get; protected set; }
        public int CategoriaEstoqueId { get; protected set; }
        public string Observacao { get; protected set; }
        public decimal QuantidadeMinima { get; protected set; }
        public decimal Quantidade { get; protected set; }
        public decimal? ValorVenda { get; protected set; }
        public decimal? ValorCompra { get; protected set; }
        public bool Ativo { get; protected set; }


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


    }
}
