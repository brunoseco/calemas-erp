using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Dto;

namespace Calemas.Erp.Application.Config
{
    public class DominioToDtoProfileCore : AutoMapper.Profile
    {

        public DominioToDtoProfileCore()
        {
            CreateMap(typeof(OrdemServico), typeof(OrdemServicoDto)).ReverseMap();
            CreateMap(typeof(OrdemServico), typeof(OrdemServicoDtoSpecialized));
            CreateMap(typeof(OrdemServico), typeof(OrdemServicoDtoSpecializedResult));
            CreateMap(typeof(OrdemServico), typeof(OrdemServicoDtoSpecializedReport));
            CreateMap(typeof(OrdemServico), typeof(OrdemServicoDtoSpecializedDetails));

        }

    }
}
