using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Threading.Tasks;

namespace Calemas.Erp.Application
{
    public class UnidadeMedidaApplicationServiceBase : ApplicationServiceBase<UnidadeMedida, UnidadeMedidaDto, UnidadeMedidaFilter>, IUnidadeMedidaApplicationService
    {
        protected readonly ValidatorAnnotations<UnidadeMedidaDto> _validatorAnnotations;
        protected readonly IUnidadeMedidaService _service;

        public UnidadeMedidaApplicationServiceBase(IUnidadeMedidaService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("UnidadeMedida");
            this._validatorAnnotations = new ValidatorAnnotations<UnidadeMedidaDto>();
            this._service = service;
        }


        protected override UnidadeMedida MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as UnidadeMedidaDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new UnidadeMedida.UnidadeMedidaFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<UnidadeMedida> AlterDomainWithDto<TDS>(TDS dto)
        {
			var unidademedida = dto as UnidadeMedidaDto;
            var result = await this._serviceBase.GetOne(new UnidadeMedidaFilter { UnidadeMedidaId = unidademedida.UnidadeMedidaId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
