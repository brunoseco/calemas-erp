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
    public class ColaboradorApplicationServiceBase : ApplicationServiceBase<Colaborador, ColaboradorDto, ColaboradorFilter>, IColaboradorApplicationService
    {
        protected readonly ValidatorAnnotations<ColaboradorDto> _validatorAnnotations;
        protected readonly IColaboradorService _service;
		protected readonly CurrentUser _user;

        public ColaboradorApplicationServiceBase(IColaboradorService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Colaborador");
            this._validatorAnnotations = new ValidatorAnnotations<ColaboradorDto>();
            this._service = service;
			this._user = user;
        }


        protected override Colaborador MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as ColaboradorDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
			var domain = new Colaborador.ColaboradorFactory().GetDefaultInstance(_dto, this._user);
            return domain;
        }


        protected override async Task<Colaborador> AlterDomainWithDto<TDS>(TDS dto)
        {
			var colaborador = dto as ColaboradorDto;
            var result = await this._serviceBase.GetOne(new ColaboradorFilter { ColaboradorId = colaborador.ColaboradorId });
            return result;
        }

    }
}
