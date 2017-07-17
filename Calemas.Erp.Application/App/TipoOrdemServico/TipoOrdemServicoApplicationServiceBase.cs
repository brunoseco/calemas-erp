using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace Calemas.Erp.Application
{
    public class TipoOrdemServicoApplicationServiceBase : ApplicationServiceBase<TipoOrdemServico, TipoOrdemServicoDto, TipoOrdemServicoFilter>, ITipoOrdemServicoApplicationService
    {
        protected readonly ValidatorAnnotations<TipoOrdemServicoDto> _validatorAnnotations;
        protected readonly ITipoOrdemServicoService _service;
		protected readonly CurrentUser _user;

        public TipoOrdemServicoApplicationServiceBase(ITipoOrdemServicoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TipoOrdemServico");
            this._validatorAnnotations = new ValidatorAnnotations<TipoOrdemServicoDto>();
            this._service = service;
			this._user = user;
        }


        protected override TipoOrdemServico MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as TipoOrdemServicoDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new TipoOrdemServico.TipoOrdemServicoFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<TipoOrdemServico> AlterDomainWithDto<TDS>(TDS dto)
        {
			var tipoordemservico = dto as TipoOrdemServicoDto;
            var result = await this._serviceBase.GetOne(new TipoOrdemServicoFilter { TipoOrdemServicoId = tipoordemservico.TipoOrdemServicoId });
            return result;
        }

    }
}
