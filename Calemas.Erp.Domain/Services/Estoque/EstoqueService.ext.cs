using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Calemas.Erp.Domain.Services
{
    public class EstoqueService : EstoqueServiceBase, IEstoqueService
    {

        public EstoqueService(IEstoqueRepository rep, ICache cache, CurrentUser user)
            : base(rep, cache, user)
        {


        }

        public override void Remove(Estoque estoque)
        {
            var itens = this._rep.GetAllAsTracking(_ => _.CollectionEstoqueMovimentacao).Where(_ => _.EstoqueId == estoque.EstoqueId).SingleOrDefault();
            base.Remove(itens);
        }

        public bool Movimentar(Estoque entity, decimal quantidade, bool entrada)
        {
            entity.Movimentar(quantidade, entrada);
            this._rep.Update(entity);
            return true;
        }
    }
}
