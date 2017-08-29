using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class OrdemServicoDtoSpecializedResult : OrdemServicoDto
	{
        public bool HouveInteracao { get; set; }
        public AgendaDto Agenda { get; set; }
        public ClienteDtoSpecializedResult Cliente { get; set; }
        public StatusOrdemServicoDto StatusOrdemServico { get; set; }
        public TipoOrdemServicoDto TipoOrdemServico { get; set; }
        public ColaboradorDtoSpecializedResult Responsavel { get; set; }


    }
}