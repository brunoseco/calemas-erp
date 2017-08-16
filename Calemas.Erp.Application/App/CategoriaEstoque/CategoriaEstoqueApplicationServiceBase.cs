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
    public class CategoriaEstoqueApplicationServiceBase : ApplicationServiceBase<CategoriaEstoque, CategoriaEstoqueDto, CategoriaEstoqueFilter>, ICategoriaEstoqueApplicationService
    {
        protected readonly ValidatorAnnotations<CategoriaEstoqueDto> _validatorAnnotations;
        protected readonly ICategoriaEstoqueService _service;
		protected readonly CurrentUser _user;

        public CategoriaEstoqueApplicationServiceBase(ICategoriaEstoqueService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("CategoriaEstoque");
            this._validatorAnnotations = new ValidatorAnnotations<CategoriaEstoqueDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<CategoriaEstoque> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as CategoriaEstoqueDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<CategoriaEstoque>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<CategoriaEstoque>();
			foreach (var dto in dtos)
			{
				var _dto = dto as CategoriaEstoqueDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<CategoriaEstoque> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as CategoriaEstoqueDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
