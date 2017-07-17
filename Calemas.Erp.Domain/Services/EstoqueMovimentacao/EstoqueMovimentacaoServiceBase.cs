using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Services
{
    public class EstoqueMovimentacaoServiceBase : ServiceBase<EstoqueMovimentacao>
    {
        protected readonly IEstoqueMovimentacaoRepository _rep;

        public EstoqueMovimentacaoServiceBase(IEstoqueMovimentacaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
            this._user = user;
        }

        public virtual async Task<EstoqueMovimentacao> GetOne(EstoqueMovimentacaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<EstoqueMovimentacao>> GetByFilters(EstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<EstoqueMovimentacao>> GetByFiltersPaging(EstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(EstoqueMovimentacao estoquemovimentacao)
        {
            this._rep.Remove(estoquemovimentacao);
        }

        public virtual Summary GetSummary(PaginateResult<EstoqueMovimentacao> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return base._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return base._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return base._validationWarning;
        }

        public override async Task<EstoqueMovimentacao> Save(EstoqueMovimentacao estoquemovimentacao, bool questionToContinue = false)
        {
            var estoquemovimentacaoOld = await this.GetOne(new EstoqueMovimentacaoFilter { EstoqueMovimentacaoId = estoquemovimentacao.EstoqueMovimentacaoId });
            var estoquemovimentacaoOrchestrated = await this.DomainOrchestration(estoquemovimentacao, estoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(estoquemovimentacaoOrchestrated, estoquemovimentacaoOld) == false)
                    return estoquemovimentacaoOrchestrated;
            }

            return this.SaveWithValidation(estoquemovimentacaoOrchestrated, estoquemovimentacaoOld);
        }

        public override async Task<EstoqueMovimentacao> SavePartial(EstoqueMovimentacao estoquemovimentacao, bool questionToContinue = false)
        {
            var estoquemovimentacaoOld = await this.GetOne(new EstoqueMovimentacaoFilter { EstoqueMovimentacaoId = estoquemovimentacao.EstoqueMovimentacaoId });
            if (questionToContinue)
            {
                if (base.Continue(estoquemovimentacao, estoquemovimentacaoOld) == false)
                    return estoquemovimentacao;
            }

            return SaveWithOutValidation(estoquemovimentacao, estoquemovimentacaoOld);
        }

        protected override EstoqueMovimentacao SaveWithOutValidation(EstoqueMovimentacao estoquemovimentacao, EstoqueMovimentacao estoquemovimentacaoOld)
        {
            estoquemovimentacao = this.SaveDefault(estoquemovimentacao, estoquemovimentacaoOld);

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "estoquemovimentacao Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return estoquemovimentacao;

        }

        protected override EstoqueMovimentacao SaveWithValidation(EstoqueMovimentacao estoquemovimentacao, EstoqueMovimentacao estoquemovimentacaoOld)
        {
            if (!this.DataAnnotationIsValid())
                return estoquemovimentacao;

            if (!estoquemovimentacao.IsValid())
            {
                base._validationResult = estoquemovimentacao.GetDomainValidation();
                return estoquemovimentacao;
            }

            this.Specifications(estoquemovimentacao);

            if (!base._validationResult.IsValid)
            {
                return estoquemovimentacao;
            }

            estoquemovimentacao = this.SaveDefault(estoquemovimentacao, estoquemovimentacaoOld);
            base._validationResult.Message = "EstoqueMovimentacao cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return estoquemovimentacao;
        }

        protected virtual void Specifications(EstoqueMovimentacao estoquemovimentacao)
        {
            base._validationResult = new EstoqueMovimentacaoAptoParaCadastroValidation(this._rep).Validate(estoquemovimentacao);
            base._validationWarning = new EstoqueMovimentacaoAptoParaCadastroWarning(this._rep).Validate(estoquemovimentacao);
        }

        protected virtual EstoqueMovimentacao SaveDefault(EstoqueMovimentacao estoquemovimentacao, EstoqueMovimentacao estoquemovimentacaoOld)
        {
            estoquemovimentacao = this.AuditDefault(estoquemovimentacao, estoquemovimentacaoOld);

            var isNew = estoquemovimentacaoOld.IsNull();
            if (isNew)
                estoquemovimentacao = AddDefault(estoquemovimentacao);
            else
                estoquemovimentacao = this._rep.Update(estoquemovimentacao);

            return estoquemovimentacao;
        }

        protected virtual EstoqueMovimentacao AddDefault(EstoqueMovimentacao estoquemovimentacao)
        {
            estoquemovimentacao = this._rep.Add(estoquemovimentacao);
            return estoquemovimentacao;
        }
    }
}
