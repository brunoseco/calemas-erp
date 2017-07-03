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
    public class FinanceiroApplicationServiceBase : ApplicationServiceBase<Financeiro, FinanceiroDto, FinanceiroFilter>, IFinanceiroApplicationService
    {
        protected readonly ValidatorAnnotations<FinanceiroDto> _validatorAnnotations;
        protected readonly IFinanceiroService _service;

        public FinanceiroApplicationServiceBase(IFinanceiroService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Financeiro");
            this._validatorAnnotations = new ValidatorAnnotations<FinanceiroDto>();
            this._service = service;
        }


        protected override Financeiro MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as FinanceiroDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new Financeiro.FinanceiroFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<Financeiro> AlterDomainWithDto<TDS>(TDS dto)
        {
			var financeiro = dto as FinanceiroDto;
            var result = await this._serviceBase.GetOne(new FinanceiroFilter { FinanceiroId = financeiro.FinanceiroId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
