using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class ColaboradorDto  : DtoBase
	{
	
        

        public virtual int ColaboradorId {get; set;}

        [Required(ErrorMessage="Colaborador - Campo Account é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Colaborador - Quantidade de caracteres maior que o permitido para o campo Account")]
        public virtual string Account {get; set;}

        [Required(ErrorMessage="Colaborador - Campo Password é Obrigatório")]
        [MaxLength(100, ErrorMessage = "Colaborador - Quantidade de caracteres maior que o permitido para o campo Password")]
        public virtual string Password {get; set;}

        [Required(ErrorMessage="Colaborador - Campo Ativo é Obrigatório")]

        public virtual bool Ativo {get; set;}

        

        public virtual int NivelAcessoId {get; set;}


		
	}
}