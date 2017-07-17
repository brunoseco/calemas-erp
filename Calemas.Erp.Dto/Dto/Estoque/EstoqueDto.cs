using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class EstoqueDto  : DtoBase
	{
	
        

        public virtual int EstoqueId {get; set;}

        [Required(ErrorMessage="Estoque - Campo Nome é Obrigatório")]
        [MaxLength(500, ErrorMessage = "Estoque - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        

        public virtual string Referencia {get; set;}

        

        public virtual int UnidadeMedidaId {get; set;}

        

        public virtual int CategoriaEstoqueId {get; set;}

        

        public virtual string Observacao {get; set;}

        [Required(ErrorMessage="Estoque - Campo QuantidadeMinima é Obrigatório")]
        public virtual decimal QuantidadeMinima {get; set;}

        [Required(ErrorMessage="Estoque - Campo Quantidade é Obrigatório")]
        public virtual decimal Quantidade {get; set;}

        

        public virtual decimal? ValorVenda {get; set;}

        

        public virtual decimal? ValorCompra {get; set;}

        [Required(ErrorMessage="Estoque - Campo Ativo é Obrigatório")]
        public virtual bool Ativo {get; set;}


		
	}
}