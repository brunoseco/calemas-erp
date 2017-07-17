using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Services
{
    public interface IEstoqueService : IServiceBase<Estoque, EstoqueFilter>
    {
        bool Movimentar(Estoque estoque, decimal quantidade, bool entrada);
    }
}
