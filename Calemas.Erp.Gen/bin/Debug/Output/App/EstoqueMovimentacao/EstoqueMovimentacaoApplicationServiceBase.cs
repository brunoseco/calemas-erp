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
    public class EstoqueMovimentacaoApplicationServiceBase : ApplicationServiceBase<EstoqueMovimentacao, EstoqueMovimentacaoDto, EstoqueMovimentacaoFilter>, IEstoqueMovimentacaoApplicationService
    {
        protected readonly ValidatorAnnotations<EstoqueMovimentacaoDto> _validatorAnnotations;
        protected readonly IEstoqueMovimentacaoService _service;
		protected readonly CurrentUser _user;

        public EstoqueMovimentacaoApplicationServiceBase(IEstoqueMovimentacaoService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("EstoqueMovimentacao");
            this._validatorAnnotations = new ValidatorAnnotations<EstoqueMovimentacaoDto>();
            this._service = service;
			this._user = user;
        }


        protected override EstoqueMovimentacao MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as EstoqueMovimentacaoDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new EstoqueMovimentacao.EstoqueMovimentacaoFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<EstoqueMovimentacao> AlterDomainWithDto<TDS>(TDS dto)
        {
			var estoquemovimentacao = dto as EstoqueMovimentacaoDto;
            var result = await this._serviceBase.GetOne(new EstoqueMovimentacaoFilter { EstoqueMovimentacaoId = estoquemovimentacao.EstoqueMovimentacaoId });
            return result;
        }

    }
}
