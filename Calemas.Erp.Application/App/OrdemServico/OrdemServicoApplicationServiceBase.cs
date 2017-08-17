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
    public class OrdemServicoApplicationServiceBase : ApplicationServiceBase<OrdemServico, OrdemServicoDto, OrdemServicoFilter>, IOrdemServicoApplicationService
    {
        protected readonly ValidatorAnnotations<OrdemServicoDto> _validatorAnnotations;
        protected readonly IOrdemServicoService _service;
		protected readonly CurrentUser _user;

        public OrdemServicoApplicationServiceBase(IOrdemServicoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("OrdemServico");
            this._validatorAnnotations = new ValidatorAnnotations<OrdemServicoDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<OrdemServico> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as OrdemServicoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<OrdemServico>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<OrdemServico>();
			foreach (var dto in dtos)
			{
				var _dto = dto as OrdemServicoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<OrdemServico> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as OrdemServicoDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }

		public virtual async Task<OrdemServicoDtoSpecialized> Fechar(OrdemServicoDtoSpecialized model)
		{
			return await Task.Run(() =>
			{
				return model;
			});
		}


    }
}
