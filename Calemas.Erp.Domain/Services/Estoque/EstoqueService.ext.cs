using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Services
{
    public class EstoqueService : EstoqueServiceBase, IEstoqueService
    {

        public EstoqueService(IEstoqueRepository rep, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {


        }

        public bool Movimentar(Estoque entity, decimal quantidade, bool entrada)
        {
            entity.Movimentar(quantidade, entrada);
            this._rep.Update(entity);
            return true;
        }
    }
}
