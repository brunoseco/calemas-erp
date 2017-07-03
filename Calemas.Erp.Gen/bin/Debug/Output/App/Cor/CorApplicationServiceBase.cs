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
    public class CorApplicationServiceBase : ApplicationServiceBase<Cor, CorDto, CorFilter>, ICorApplicationService
    {
        protected readonly ValidatorAnnotations<CorDto> _validatorAnnotations;
        protected readonly ICorService _service;

        public CorApplicationServiceBase(ICorService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Cor");
            this._validatorAnnotations = new ValidatorAnnotations<CorDto>();
            this._service = service;
        }


        protected override Cor MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as CorDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new Cor.CorFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<Cor> AlterDomainWithDto<TDS>(TDS dto)
        {
			var cor = dto as CorDto;
            var result = await this._serviceBase.GetOne(new CorFilter { CorId = cor.CorId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
