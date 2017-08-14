using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class OrdemServicoInteracaoDtoSpecializedDetails : OrdemServicoInteracaoDto
	{

        public  ColaboradorDto Colaborador { get; set;} 
        public  OrdemServicoDto OrdemServico { get; set;} 

		
	}
}