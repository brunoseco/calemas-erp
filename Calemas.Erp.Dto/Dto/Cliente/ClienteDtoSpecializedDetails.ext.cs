using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calemas.Erp.Dto
{
	public class ClienteDtoSpecializedDetails : ClienteDto
	{

        public IEnumerable<OrdemServicoDto> CollectionOrdemServico { get; set;} 
        public  ColaboradorDto Colaborador { get; set;} 
        public  CondominioDto Condominio { get; set;} 
        public  PessoaDto Pessoa { get; set;} 
        public  StatusClienteDto StatusCliente { get; set;} 

		
	}
}