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
    public class StatusSolicitacaoEstoqueMovimentacaoServiceBase : ServiceBase<StatusSolicitacaoEstoqueMovimentacao>
    {
        protected readonly IStatusSolicitacaoEstoqueMovimentacaoRepository _rep;

        public StatusSolicitacaoEstoqueMovimentacaoServiceBase(IStatusSolicitacaoEstoqueMovimentacaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusSolicitacaoEstoqueMovimentacao> GetOne(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusSolicitacaoEstoqueMovimentacao>> GetByFilters(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusSolicitacaoEstoqueMovimentacao>> GetByFiltersPaging(StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao)
        {
            this._rep.Remove(statussolicitacaoestoquemovimentacao);
        }

        public virtual Summary GetSummary(PaginateResult<StatusSolicitacaoEstoqueMovimentacao> paginateResult)
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

        public override async Task<StatusSolicitacaoEstoqueMovimentacao> Save(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, bool questionToContinue = false)
        {
			var statussolicitacaoestoquemovimentacaoOld = await this.GetOne(new StatusSolicitacaoEstoqueMovimentacaoFilter { StatusSolicitacaoEstoqueMovimentacaoId = statussolicitacaoestoquemovimentacao.StatusSolicitacaoEstoqueMovimentacaoId });
			var statussolicitacaoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(statussolicitacaoestoquemovimentacao, statussolicitacaoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(statussolicitacaoestoquemovimentacaoOrchestrated, statussolicitacaoestoquemovimentacaoOld) == false)
                    return statussolicitacaoestoquemovimentacaoOrchestrated;
            }

            return this.SaveWithValidation(statussolicitacaoestoquemovimentacaoOrchestrated, statussolicitacaoestoquemovimentacaoOld);
        }

        public override async Task<StatusSolicitacaoEstoqueMovimentacao> SavePartial(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, bool questionToContinue = false)
        {
            var statussolicitacaoestoquemovimentacaoOld = await this.GetOne(new StatusSolicitacaoEstoqueMovimentacaoFilter { StatusSolicitacaoEstoqueMovimentacaoId = statussolicitacaoestoquemovimentacao.StatusSolicitacaoEstoqueMovimentacaoId });
			var statussolicitacaoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(statussolicitacaoestoquemovimentacao, statussolicitacaoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(statussolicitacaoestoquemovimentacaoOrchestrated, statussolicitacaoestoquemovimentacaoOld) == false)
                    return statussolicitacaoestoquemovimentacaoOrchestrated;
            }

            return SaveWithOutValidation(statussolicitacaoestoquemovimentacaoOrchestrated, statussolicitacaoestoquemovimentacaoOld);
        }

        protected override StatusSolicitacaoEstoqueMovimentacao SaveWithOutValidation(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacaoOld)
        {
            statussolicitacaoestoquemovimentacao = this.SaveDefault(statussolicitacaoestoquemovimentacao, statussolicitacaoestoquemovimentacaoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return statussolicitacaoestoquemovimentacao;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "statussolicitacaoestoquemovimentacao Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return statussolicitacaoestoquemovimentacao;

        }

		protected override StatusSolicitacaoEstoqueMovimentacao SaveWithValidation(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacaoOld)
        {
            if (!this.DataAnnotationIsValid())
                return statussolicitacaoestoquemovimentacao;

            if (!statussolicitacaoestoquemovimentacao.IsValid())
            {
                base._validationResult = statussolicitacaoestoquemovimentacao.GetDomainValidation();
                return statussolicitacaoestoquemovimentacao;
            }

            this.Specifications(statussolicitacaoestoquemovimentacao);

            if (!base._validationResult.IsValid)
                return statussolicitacaoestoquemovimentacao;
            
            statussolicitacaoestoquemovimentacao = this.SaveDefault(statussolicitacaoestoquemovimentacao, statussolicitacaoestoquemovimentacaoOld);
            base._validationResult.Message = "StatusSolicitacaoEstoqueMovimentacao cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return statussolicitacaoestoquemovimentacao;
        }

		protected virtual void Specifications(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao)
        {
            base._validationResult  = new StatusSolicitacaoEstoqueMovimentacaoAptoParaCadastroValidation(this._rep).Validate(statussolicitacaoestoquemovimentacao);
			base._validationWarning  = new StatusSolicitacaoEstoqueMovimentacaoAptoParaCadastroWarning(this._rep).Validate(statussolicitacaoestoquemovimentacao);
        }

        protected virtual StatusSolicitacaoEstoqueMovimentacao SaveDefault(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacaoOld)
        {
			

            var isNew = statussolicitacaoestoquemovimentacaoOld.IsNull();			
            if (isNew)
                statussolicitacaoestoquemovimentacao = this.AddDefault(statussolicitacaoestoquemovimentacao);
            else
				statussolicitacaoestoquemovimentacao = this.UpdateDefault(statussolicitacaoestoquemovimentacao, statussolicitacaoestoquemovimentacaoOld);

            return statussolicitacaoestoquemovimentacao;
        }
		
        protected virtual StatusSolicitacaoEstoqueMovimentacao AddDefault(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao)
        {
            statussolicitacaoestoquemovimentacao = this._rep.Add(statussolicitacaoestoquemovimentacao);
            return statussolicitacaoestoquemovimentacao;
        }

		protected virtual StatusSolicitacaoEstoqueMovimentacao UpdateDefault(StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacao, StatusSolicitacaoEstoqueMovimentacao statussolicitacaoestoquemovimentacaoOld)
        {
            statussolicitacaoestoquemovimentacao = this._rep.Update(statussolicitacaoestoquemovimentacao);
            return statussolicitacaoestoquemovimentacao;
        }
				
		public virtual async Task<StatusSolicitacaoEstoqueMovimentacao> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusSolicitacaoEstoqueMovimentacao.StatusSolicitacaoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusSolicitacaoEstoqueMovimentacao> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusSolicitacaoEstoqueMovimentacao.StatusSolicitacaoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
