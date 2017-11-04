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
    public class SolicitacaoEstoqueMovimentacaoServiceBase : ServiceBase<SolicitacaoEstoqueMovimentacao>
    {
        protected readonly ISolicitacaoEstoqueMovimentacaoRepository _rep;

        public SolicitacaoEstoqueMovimentacaoServiceBase(ISolicitacaoEstoqueMovimentacaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<SolicitacaoEstoqueMovimentacao> GetOne(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SolicitacaoEstoqueMovimentacao>> GetByFilters(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SolicitacaoEstoqueMovimentacao>> GetByFiltersPaging(SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao)
        {
            this._rep.Remove(solicitacaoestoquemovimentacao);
        }

        public virtual Summary GetSummary(PaginateResult<SolicitacaoEstoqueMovimentacao> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
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

        public override async Task<SolicitacaoEstoqueMovimentacao> Save(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, bool questionToContinue = false)
        {
			var solicitacaoestoquemovimentacaoOld = await this.GetOne(new SolicitacaoEstoqueMovimentacaoFilter { SolicitacaoEstoqueMovimentacaoId = solicitacaoestoquemovimentacao.SolicitacaoEstoqueMovimentacaoId });
			var solicitacaoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(solicitacaoestoquemovimentacao, solicitacaoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(solicitacaoestoquemovimentacaoOrchestrated, solicitacaoestoquemovimentacaoOld) == false)
                    return solicitacaoestoquemovimentacaoOrchestrated;
            }

            return this.SaveWithValidation(solicitacaoestoquemovimentacaoOrchestrated, solicitacaoestoquemovimentacaoOld);
        }

        public override async Task<SolicitacaoEstoqueMovimentacao> SavePartial(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, bool questionToContinue = false)
        {
            var solicitacaoestoquemovimentacaoOld = await this.GetOne(new SolicitacaoEstoqueMovimentacaoFilter { SolicitacaoEstoqueMovimentacaoId = solicitacaoestoquemovimentacao.SolicitacaoEstoqueMovimentacaoId });
			var solicitacaoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(solicitacaoestoquemovimentacao, solicitacaoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(solicitacaoestoquemovimentacaoOrchestrated, solicitacaoestoquemovimentacaoOld) == false)
                    return solicitacaoestoquemovimentacaoOrchestrated;
            }

            return SaveWithOutValidation(solicitacaoestoquemovimentacaoOrchestrated, solicitacaoestoquemovimentacaoOld);
        }

        protected override SolicitacaoEstoqueMovimentacao SaveWithOutValidation(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacaoOld)
        {
            solicitacaoestoquemovimentacao = this.SaveDefault(solicitacaoestoquemovimentacao, solicitacaoestoquemovimentacaoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return solicitacaoestoquemovimentacao;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "solicitacaoestoquemovimentacao Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return solicitacaoestoquemovimentacao;

        }

		protected override SolicitacaoEstoqueMovimentacao SaveWithValidation(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacaoOld)
        {
            if (!this.DataAnnotationIsValid())
                return solicitacaoestoquemovimentacao;

            if (!solicitacaoestoquemovimentacao.IsValid())
            {
                base._validationResult = solicitacaoestoquemovimentacao.GetDomainValidation();
                return solicitacaoestoquemovimentacao;
            }

            this.Specifications(solicitacaoestoquemovimentacao);

            if (!base._validationResult.IsValid)
                return solicitacaoestoquemovimentacao;
            
            solicitacaoestoquemovimentacao = this.SaveDefault(solicitacaoestoquemovimentacao, solicitacaoestoquemovimentacaoOld);
            base._validationResult.Message = "SolicitacaoEstoqueMovimentacao cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return solicitacaoestoquemovimentacao;
        }

		protected virtual void Specifications(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao)
        {
            base._validationResult  = new SolicitacaoEstoqueMovimentacaoAptoParaCadastroValidation(this._rep).Validate(solicitacaoestoquemovimentacao);
			base._validationWarning  = new SolicitacaoEstoqueMovimentacaoAptoParaCadastroWarning(this._rep).Validate(solicitacaoestoquemovimentacao);
        }

        protected virtual SolicitacaoEstoqueMovimentacao SaveDefault(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacaoOld)
        {
			

            var isNew = solicitacaoestoquemovimentacaoOld.IsNull();			
            if (isNew)
                solicitacaoestoquemovimentacao = this.AddDefault(solicitacaoestoquemovimentacao);
            else
				solicitacaoestoquemovimentacao = this.UpdateDefault(solicitacaoestoquemovimentacao, solicitacaoestoquemovimentacaoOld);

            return solicitacaoestoquemovimentacao;
        }
		
        protected virtual SolicitacaoEstoqueMovimentacao AddDefault(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao)
        {
            solicitacaoestoquemovimentacao = this._rep.Add(solicitacaoestoquemovimentacao);
            return solicitacaoestoquemovimentacao;
        }

		protected virtual SolicitacaoEstoqueMovimentacao UpdateDefault(SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacao, SolicitacaoEstoqueMovimentacao solicitacaoestoquemovimentacaoOld)
        {
            solicitacaoestoquemovimentacao = this._rep.Update(solicitacaoestoquemovimentacao);
            return solicitacaoestoquemovimentacao;
        }
				
		public virtual async Task<SolicitacaoEstoqueMovimentacao> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SolicitacaoEstoqueMovimentacao.SolicitacaoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SolicitacaoEstoqueMovimentacao> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SolicitacaoEstoqueMovimentacao.SolicitacaoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
