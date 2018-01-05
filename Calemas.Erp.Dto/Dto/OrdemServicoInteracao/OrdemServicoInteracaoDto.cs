using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class OrdemServicoInteracaoDto  : DtoBase
	{
	
        

        public virtual int OrdemServicoInteracaoId {get; set;}

        

        public virtual int OrdemServicoId {get; set;}

        [Required(ErrorMessage="OrdemServicoInteracao - Campo DataConclusao é Obrigatório")]
        public virtual DateTime DataConclusao {get; set;}

        [Required(ErrorMessage="OrdemServicoInteracao - Campo Descricao é Obrigatório")]
        public virtual string Descricao {get; set;}

        

        public virtual string Observacao {get; set;}

        [Required(ErrorMessage="OrdemServicoInteracao - Campo FoiProprioCliente é Obrigatório")]
        public virtual bool FoiProprioCliente {get; set;}

        

        public virtual string NomeClienteResponsavel {get; set;}

        

        public virtual int TecnicoId {get; set;}

        

        public virtual int StatusOrdemServicoId {get; set;}

        

        public virtual int StatusPagamentoId {get; set;}


		
	}
}