using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Dto;

namespace Calemas.Erp.Application.Config
{
    public class DominioToDtoProfileCalemas.Erp : AutoMapper.Profile
    {

        public DominioToDtoProfileCalemas.Erp()
        {
            CreateMap(typeof(Banco), typeof(BancoDto)).ReverseMap();
            CreateMap(typeof(Banco), typeof(BancoDtoSpecialized));
            CreateMap(typeof(Banco), typeof(BancoDtoSpecializedResult));
            CreateMap(typeof(Banco), typeof(BancoDtoSpecializedReport));
            CreateMap(typeof(Banco), typeof(BancoDtoSpecializedDetails));

        }

    }
}
