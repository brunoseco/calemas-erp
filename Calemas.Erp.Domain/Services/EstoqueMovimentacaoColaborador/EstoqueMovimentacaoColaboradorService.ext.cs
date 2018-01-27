using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;

namespace Calemas.Erp.Domain.Services
{
    public class EstoqueMovimentacaoColaboradorService : EstoqueMovimentacaoColaboradorServiceBase, IEstoqueMovimentacaoColaboradorService
    {

        public EstoqueMovimentacaoColaboradorService(IEstoqueMovimentacaoColaboradorRepository rep, ICache cache, CurrentUser user) 
            : base(rep, cache, user)
        {


        }
        
    }
}
