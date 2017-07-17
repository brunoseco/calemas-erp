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
    public class EstoqueApplicationServiceBase : ApplicationServiceBase<Estoque, EstoqueDto, EstoqueFilter>, IEstoqueApplicationService
    {
        protected readonly ValidatorAnnotations<EstoqueDto> _validatorAnnotations;
        protected readonly IEstoqueService _service;
		protected readonly CurrentUser _user;

        public EstoqueApplicationServiceBase(IEstoqueService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Estoque");
            this._validatorAnnotations = new ValidatorAnnotations<EstoqueDto>();
            this._service = service;
			this._user = user;
        }


        protected override Estoque MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as EstoqueDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new Estoque.EstoqueFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<Estoque> AlterDomainWithDto<TDS>(TDS dto)
        {
			var estoque = dto as EstoqueDto;
            var result = await this._serviceBase.GetOne(new EstoqueFilter { EstoqueId = estoque.EstoqueId });
            return result;
        }

    }
}
