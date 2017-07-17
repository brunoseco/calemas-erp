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
    public class PlanoContaApplicationServiceBase : ApplicationServiceBase<PlanoConta, PlanoContaDto, PlanoContaFilter>, IPlanoContaApplicationService
    {
        protected readonly ValidatorAnnotations<PlanoContaDto> _validatorAnnotations;
        protected readonly IPlanoContaService _service;
		protected readonly CurrentUser _user;

        public PlanoContaApplicationServiceBase(IPlanoContaService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("PlanoConta");
            this._validatorAnnotations = new ValidatorAnnotations<PlanoContaDto>();
            this._service = service;
			this._user = user;
        }


        protected override PlanoConta MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as PlanoContaDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new PlanoConta.PlanoContaFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<PlanoConta> AlterDomainWithDto<TDS>(TDS dto)
        {
			var planoconta = dto as PlanoContaDto;
            var result = await this._serviceBase.GetOne(new PlanoContaFilter { PlanoContaId = planoconta.PlanoContaId });
            return result;
        }

    }
}
