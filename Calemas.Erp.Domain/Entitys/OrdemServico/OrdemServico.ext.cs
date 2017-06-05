using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServico : OrdemServicoBase
    {

        public OrdemServico()
        {

        }

        public OrdemServico(int ordemservicoid, string protoco, int clienteid, int prioridadeid, int setorid, int tipoordemservicoid, int agendaid, int statusordemservicoid, DateTime datasituacao) :
            base(ordemservicoid, protoco, clienteid, prioridadeid, setorid, tipoordemservicoid, agendaid, statusordemservicoid, datasituacao)
        {

        }

        public bool IsValid()
        {
            base._validationResult = new OrdemServicoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
