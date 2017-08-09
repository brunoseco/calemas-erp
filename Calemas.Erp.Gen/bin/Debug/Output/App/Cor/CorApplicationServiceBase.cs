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
    public class CorApplicationServiceBase : ApplicationServiceBase<Cor, CorDto, CorFilter>, ICorApplicationService
    {
        protected readonly ValidatorAnnotations<CorDto> _validatorAnnotations;
        protected readonly ICorService _service;
		protected readonly CurrentUser _user;

        public CorApplicationServiceBase(ICorService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Cor");
            this._validatorAnnotations = new ValidatorAnnotations<CorDto>();
            this._service = service;
			this._user = user;
        }


        protected override Cor MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as CorDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new Cor.CorFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<Cor> AlterDomainWithDto<TDS>(TDS dto)
        {
			var cor = dto as CorDto;
            var result = await this._serviceBase.GetOne(new CorFilter { CorId = cor.CorId });
            return result;
        }

    }
}
