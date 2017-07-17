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
    public class CategoriaEstoqueApplicationServiceBase : ApplicationServiceBase<CategoriaEstoque, CategoriaEstoqueDto, CategoriaEstoqueFilter>, ICategoriaEstoqueApplicationService
    {
        protected readonly ValidatorAnnotations<CategoriaEstoqueDto> _validatorAnnotations;
        protected readonly ICategoriaEstoqueService _service;

        public CategoriaEstoqueApplicationServiceBase(ICategoriaEstoqueService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("CategoriaEstoque");
            this._validatorAnnotations = new ValidatorAnnotations<CategoriaEstoqueDto>();
            this._service = service;
        }


        protected override CategoriaEstoque MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as CategoriaEstoqueDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

			var domain = new CategoriaEstoque.CategoriaEstoqueFactory().GetDefaaultInstance(_dto);
            return domain;
        }


        protected override async Task<CategoriaEstoque> AlterDomainWithDto<TDS>(TDS dto)
        {
			var categoriaestoque = dto as CategoriaEstoqueDto;
            var result = await this._serviceBase.GetOne(new CategoriaEstoqueFilter { CategoriaEstoqueId = categoriaestoque.CategoriaEstoqueId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
