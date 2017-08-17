using Common.Domain.Interfaces;
using Calemas.Erp.Dto;
using System.Threading.Tasks;

namespace Calemas.Erp.Application.Interfaces
{
    public interface IOrdemServicoApplicationServiceBase : IApplicationServiceBase<OrdemServicoDto>
    {
		Task<OrdemServicoDtoSpecialized> Fechar(OrdemServicoDtoSpecialized model);
    }
}
