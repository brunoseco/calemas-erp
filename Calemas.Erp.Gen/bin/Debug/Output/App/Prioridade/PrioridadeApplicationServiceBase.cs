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


        protected override Prioridade MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as PrioridadeDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new Prioridade.PrioridadeFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<Prioridade> AlterDomainWithDto<TDS>(TDS dto)
        {
			var prioridade = dto as PrioridadeDto;
            var result = await this._serviceBase.GetOne(new PrioridadeFilter { PrioridadeId = prioridade.PrioridadeId });
            return result;
        }

    }
}
