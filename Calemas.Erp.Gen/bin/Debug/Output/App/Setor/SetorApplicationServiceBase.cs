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
    public class SetorApplicationServiceBase : ApplicationServiceBase<Setor, SetorDto, SetorFilter>, ISetorApplicationService
    {
        protected readonly ValidatorAnnotations<SetorDto> _validatorAnnotations;
        protected readonly ISetorService _service;
		protected readonly CurrentUser _user;

        public SetorApplicationServiceBase(ISetorService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Setor");
            this._validatorAnnotations = new ValidatorAnnotations<SetorDto>();
            this._service = service;
			this._user = user;
        }


        protected override Setor MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as SetorDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new Setor.SetorFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<Setor> AlterDomainWithDto<TDS>(TDS dto)
        {
			var setor = dto as SetorDto;
            var result = await this._serviceBase.GetOne(new SetorFilter { SetorId = setor.SetorId });
            return result;
        }

    }
}
