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
    public class StatusSolicitacaoEstoqueMovimentacaoApplicationServiceBase : ApplicationServiceBase<StatusSolicitacaoEstoqueMovimentacao, StatusSolicitacaoEstoqueMovimentacaoDto, StatusSolicitacaoEstoqueMovimentacaoFilter>, IStatusSolicitacaoEstoqueMovimentacaoApplicationService
    {
        protected readonly ValidatorAnnotations<StatusSolicitacaoEstoqueMovimentacaoDto> _validatorAnnotations;
        protected readonly IStatusSolicitacaoEstoqueMovimentacaoService _service;
		protected readonly CurrentUser _user;

        public StatusSolicitacaoEstoqueMovimentacaoApplicationServiceBase(IStatusSolicitacaoEstoqueMovimentacaoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("StatusSolicitacaoEstoqueMovimentacao");
            this._validatorAnnotations = new ValidatorAnnotations<StatusSolicitacaoEstoqueMovimentacaoDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<StatusSolicitacaoEstoqueMovimentacao> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusSolicitacaoEstoqueMovimentacaoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<StatusSolicitacaoEstoqueMovimentacao>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<StatusSolicitacaoEstoqueMovimentacao>();
			foreach (var dto in dtos)
			{
				var _dto = dto as StatusSolicitacaoEstoqueMovimentacaoDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<StatusSolicitacaoEstoqueMovimentacao> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as StatusSolicitacaoEstoqueMovimentacaoDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
