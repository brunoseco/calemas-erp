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
using System.Collections.Generic;

namespace Calemas.Erp.Application
{
    public class TipoPlanoContaApplicationServiceBase : ApplicationServiceBase<TipoPlanoConta, TipoPlanoContaDto, TipoPlanoContaFilter>, ITipoPlanoContaApplicationService
    {
        protected readonly ValidatorAnnotations<TipoPlanoContaDto> _validatorAnnotations;
        protected readonly ITipoPlanoContaService _service;
		protected readonly CurrentUser _user;

        public TipoPlanoContaApplicationServiceBase(ITipoPlanoContaService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TipoPlanoConta");
            this._validatorAnnotations = new ValidatorAnnotations<TipoPlanoContaDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<TipoPlanoConta> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoPlanoContaDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<TipoPlanoConta>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<TipoPlanoConta>();
			foreach (var dto in dtos)
			{
				var _dto = dto as TipoPlanoContaDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<TipoPlanoConta> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as TipoPlanoContaDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
