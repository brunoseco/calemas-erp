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
    public class StatusPagamentoApplicationServiceBase : ApplicationServiceBase<StatusPagamento, StatusPagamentoDto, StatusPagamentoFilter>, IStatusPagamentoApplicationService
    {
        protected readonly ValidatorAnnotations<StatusPagamentoDto> _validatorAnnotations;
        protected readonly IStatusPagamentoService _service;
		protected readonly CurrentUser _user;

        public StatusPagamentoApplicationServiceBase(IStatusPagamentoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusPagamento");
            this._validatorAnnotations = new ValidatorAnnotations<StatusPagamentoDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusPagamento> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusPagamentoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusPagamento>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusPagamento>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusPagamentoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusPagamento> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusPagamentoDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
