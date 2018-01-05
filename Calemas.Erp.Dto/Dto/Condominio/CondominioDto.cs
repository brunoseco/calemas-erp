using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class CondominioDto  : DtoBase
	{
	
        

        public virtual int CondominioId {get; set;}

        [Required(ErrorMessage="Condominio - Campo Nome é Obrigatório")]
        [MaxLength(500, ErrorMessage = "Condominio - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="Condominio - Campo Sigla é Obrigatório")]
        [MaxLength(10, ErrorMessage = "Condominio - Quantidade de caracteres maior que o permitido para o campo Sigla")]
        public virtual string Sigla {get; set;}

        [Required(ErrorMessage="Condominio - Campo Ativo é Obrigatório")]
        public virtual bool Ativo {get; set;}

        

        public virtual int EnderecoId {get; set;}

        

        public virtual int? InfraestruturaPopId {get; set;}


		
	}
}