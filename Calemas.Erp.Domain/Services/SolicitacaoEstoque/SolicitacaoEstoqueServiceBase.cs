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
    public class SolicitacaoEstoqueServiceBase : ServiceBase<SolicitacaoEstoque>
    {
        protected readonly ISolicitacaoEstoqueRepository _rep;

        public SolicitacaoEstoqueServiceBase(ISolicitacaoEstoqueRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<SolicitacaoEstoque> GetOne(SolicitacaoEstoqueFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SolicitacaoEstoque>> GetByFilters(SolicitacaoEstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SolicitacaoEstoque>> GetByFiltersPaging(SolicitacaoEstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SolicitacaoEstoque solicitacaoestoque)
        {
            this._rep.Remove(solicitacaoestoque);
        }

        public virtual Summary GetSummary(PaginateResult<SolicitacaoEstoque> paginateResult)
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

        public override async Task<SolicitacaoEstoque> Save(SolicitacaoEstoque solicitacaoestoque, bool questionToContinue = false)
        {
			var solicitacaoestoqueOld = await this.GetOne(new SolicitacaoEstoqueFilter { SolicitacaoEstoqueId = solicitacaoestoque.SolicitacaoEstoqueId });
			var solicitacaoestoqueOrchestrated = await this.DomainOrchestration(solicitacaoestoque, solicitacaoestoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(solicitacaoestoqueOrchestrated, solicitacaoestoqueOld) == false)
                    return solicitacaoestoqueOrchestrated;
            }

            return this.SaveWithValidation(solicitacaoestoqueOrchestrated, solicitacaoestoqueOld);
        }

        public override async Task<SolicitacaoEstoque> SavePartial(SolicitacaoEstoque solicitacaoestoque, bool questionToContinue = false)
        {
            var solicitacaoestoqueOld = await this.GetOne(new SolicitacaoEstoqueFilter { SolicitacaoEstoqueId = solicitacaoestoque.SolicitacaoEstoqueId });
			var solicitacaoestoqueOrchestrated = await this.DomainOrchestration(solicitacaoestoque, solicitacaoestoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(solicitacaoestoqueOrchestrated, solicitacaoestoqueOld) == false)
                    return solicitacaoestoqueOrchestrated;
            }

            return SaveWithOutValidation(solicitacaoestoqueOrchestrated, solicitacaoestoqueOld);
        }

        protected override SolicitacaoEstoque SaveWithOutValidation(SolicitacaoEstoque solicitacaoestoque, SolicitacaoEstoque solicitacaoestoqueOld)
        {
            solicitacaoestoque = this.SaveDefault(solicitacaoestoque, solicitacaoestoqueOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return solicitacaoestoque;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "solicitacaoestoque Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return solicitacaoestoque;

        }

		protected override SolicitacaoEstoque SaveWithValidation(SolicitacaoEstoque solicitacaoestoque, SolicitacaoEstoque solicitacaoestoqueOld)
        {
            if (!this.DataAnnotationIsValid())
                return solicitacaoestoque;

            if (!solicitacaoestoque.IsValid())
            {
                base._validationResult = solicitacaoestoque.GetDomainValidation();
                return solicitacaoestoque;
            }

            this.Specifications(solicitacaoestoque);

            if (!base._validationResult.IsValid)
                return solicitacaoestoque;
            
            solicitacaoestoque = this.SaveDefault(solicitacaoestoque, solicitacaoestoqueOld);
            base._validationResult.Message = "SolicitacaoEstoque cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return solicitacaoestoque;
        }

		protected virtual void Specifications(SolicitacaoEstoque solicitacaoestoque)
        {
            base._validationResult  = new SolicitacaoEstoqueAptoParaCadastroValidation(this._rep).Validate(solicitacaoestoque);
			base._validationWarning  = new SolicitacaoEstoqueAptoParaCadastroWarning(this._rep).Validate(solicitacaoestoque);
        }

        protected virtual SolicitacaoEstoque SaveDefault(SolicitacaoEstoque solicitacaoestoque, SolicitacaoEstoque solicitacaoestoqueOld)
        {
			solicitacaoestoque = this.AuditDefault(solicitacaoestoque, solicitacaoestoqueOld);

            var isNew = solicitacaoestoqueOld.IsNull();			
            if (isNew)
                solicitacaoestoque = this.AddDefault(solicitacaoestoque);
            else
				solicitacaoestoque = this.UpdateDefault(solicitacaoestoque, solicitacaoestoqueOld);

            return solicitacaoestoque;
        }
		
        protected virtual SolicitacaoEstoque AddDefault(SolicitacaoEstoque solicitacaoestoque)
        {
            solicitacaoestoque = this._rep.Add(solicitacaoestoque);
            return solicitacaoestoque;
        }

		protected virtual SolicitacaoEstoque UpdateDefault(SolicitacaoEstoque solicitacaoestoque, SolicitacaoEstoque solicitacaoestoqueOld)
        {
            solicitacaoestoque = this._rep.Update(solicitacaoestoque);
            return solicitacaoestoque;
        }
				
		public virtual async Task<SolicitacaoEstoque> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SolicitacaoEstoque.SolicitacaoEstoqueFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SolicitacaoEstoque> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SolicitacaoEstoque.SolicitacaoEstoqueFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
