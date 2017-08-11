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
    public class PrioridadeApplicationServiceBase : ApplicationServiceBase<Prioridade, PrioridadeDto, PrioridadeFilter>, IPrioridadeApplicationService
    {
        protected readonly ValidatorAnnotations<PrioridadeDto> _validatorAnnotations;
        protected readonly IPrioridadeService _service;
		protected readonly CurrentUser _user;

        public PrioridadeApplicationServiceBase(IPrioridadeService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Prioridade");
            this._validatorAnnotations = new ValidatorAnnotations<PrioridadeDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<Prioridade> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as PrioridadeDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<Prioridade>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<Prioridade>();
			foreach (var dto in dtos)
			{
				var _dto = dto as PrioridadeDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<Prioridade> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as PrioridadeDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }

    }
}
