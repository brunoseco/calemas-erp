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
    public class EstoqueApplicationServiceBase : ApplicationServiceBase<Estoque, EstoqueDto, EstoqueFilter>, IEstoqueApplicationService
    {
        protected readonly ValidatorAnnotations<EstoqueDto> _validatorAnnotations;
        protected readonly IEstoqueService _service;

        public EstoqueApplicationServiceBase(IEstoqueService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Estoque");
            this._validatorAnnotations = new ValidatorAnnotations<EstoqueDto>();
            this._service = service;
        }


        protected override Estoque MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as EstoqueDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new Estoque.EstoqueFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<Estoque> AlterDomainWithDto<TDS>(TDS dto)
        {
			var estoque = dto as EstoqueDto;
            var result = await this._serviceBase.GetOne(new EstoqueFilter { EstoqueId = estoque.EstoqueId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
