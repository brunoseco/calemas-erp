using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Threading.Tasks;

namespace Calemas.Erp.Application
{
    public class TipoPlanoContaApplicationServiceBase : ApplicationServiceBase<TipoPlanoConta, TipoPlanoContaDto, TipoPlanoContaFilter>, ITipoPlanoContaApplicationService
    {
        protected readonly ValidatorAnnotations<TipoPlanoContaDto> _validatorAnnotations;
        protected readonly ITipoPlanoContaService _service;

        public TipoPlanoContaApplicationServiceBase(ITipoPlanoContaService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("TipoPlanoConta");
            this._validatorAnnotations = new ValidatorAnnotations<TipoPlanoContaDto>();
            this._service = service;
        }


        protected override TipoPlanoConta MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as TipoPlanoContaDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new TipoPlanoConta.TipoPlanoContaFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<TipoPlanoConta> AlterDomainWithDto<TDS>(TDS dto)
        {
			var tipoplanoconta = dto as TipoPlanoContaDto;
            var result = await this._serviceBase.GetOne(new TipoPlanoContaFilter { TipoPlanoContaId = tipoplanoconta.TipoPlanoContaId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
