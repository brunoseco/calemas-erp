using Common.Domain.Interfaces;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;

namespace Calemas.Erp.Application
{
    public class EstoqueMovimentacaoApplicationService : EstoqueMovimentacaoApplicationServiceBase
    {
        private readonly IEstoqueService _serviceEstoque;

        public EstoqueMovimentacaoApplicationService(IEstoqueMovimentacaoService service, IEstoqueService serviceEstoque, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            this._serviceEstoque = serviceEstoque;
        }

        protected override EstoqueMovimentacao MapperDtoToDomain<TDS>(TDS dto)
        {
            var _dto = dto as EstoqueMovimentacaoDtoSpecialized;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
            var domain = new EstoqueMovimentacao.EstoqueMovimentacaoFactory().GetDefaaultInstance(_dto);
            return domain;
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<EstoqueMovimentacao> dataList)
        {
            return base.MapperDomainToResult<EstoqueMovimentacaoDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
