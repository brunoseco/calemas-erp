using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class CategoriaEstoqueDto  : DtoBase
	{
	
        

        public virtual int CategoriaEstoqueId {get; set;}

        [Required(ErrorMessage="CategoriaEstoque - Campo Nome é Obrigatório")]
        [MaxLength(100, ErrorMessage = "CategoriaEstoque - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}