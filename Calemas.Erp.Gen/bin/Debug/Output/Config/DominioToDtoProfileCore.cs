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
            CreateMap(typeof(Colaborador), typeof(ColaboradorDto)).ReverseMap();
            CreateMap(typeof(Colaborador), typeof(ColaboradorDtoSpecialized));
            CreateMap(typeof(Colaborador), typeof(ColaboradorDtoSpecializedResult));
            CreateMap(typeof(Colaborador), typeof(ColaboradorDtoSpecializedReport));
            CreateMap(typeof(Colaborador), typeof(ColaboradorDtoSpecializedDetails));
            CreateMap(typeof(NivelAcesso), typeof(NivelAcessoDto)).ReverseMap();
            CreateMap(typeof(NivelAcesso), typeof(NivelAcessoDtoSpecialized));
            CreateMap(typeof(NivelAcesso), typeof(NivelAcessoDtoSpecializedResult));
            CreateMap(typeof(NivelAcesso), typeof(NivelAcessoDtoSpecializedReport));
            CreateMap(typeof(NivelAcesso), typeof(NivelAcessoDtoSpecializedDetails));
            CreateMap(typeof(Pessoa), typeof(PessoaDto)).ReverseMap();
            CreateMap(typeof(Pessoa), typeof(PessoaDtoSpecialized));
            CreateMap(typeof(Pessoa), typeof(PessoaDtoSpecializedResult));
            CreateMap(typeof(Pessoa), typeof(PessoaDtoSpecializedReport));
            CreateMap(typeof(Pessoa), typeof(PessoaDtoSpecializedDetails));

        }

    }
}
