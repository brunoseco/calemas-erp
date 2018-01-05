using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class OrdemServicoDto  : DtoBase
	{
	
        

        public virtual int OrdemServicoId {get; set;}

        [Required(ErrorMessage="OrdemServico - Campo Protoco é Obrigatório")]
        [MaxLength(50, ErrorMessage = "OrdemServico - Quantidade de caracteres maior que o permitido para o campo Protoco")]
        public virtual string Protoco {get; set;}

        

        public virtual int ResponsavelId {get; set;}

        

        public virtual int ClienteId {get; set;}

        

        public virtual int TipoOrdemServicoId {get; set;}

        

        public virtual int AgendaId {get; set;}

        

        public virtual int StatusOrdemServicoId {get; set;}

        

        public virtual int? StatusPagamentoId {get; set;}

        [Required(ErrorMessage="OrdemServico - Campo DataOcorrencia é Obrigatório")]
        public virtual DateTime DataOcorrencia {get; set;}

        [Required(ErrorMessage="OrdemServico - Campo DataSituacao é Obrigatório")]
        public virtual DateTime DataSituacao {get; set;}

        

        public virtual string Observacao {get; set;}

        

        public virtual string Descricao {get; set;}


		
	}
}