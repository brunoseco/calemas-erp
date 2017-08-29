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
    public class CategoriaEstoqueServiceBase : ServiceBase<CategoriaEstoque>
    {
        protected readonly ICategoriaEstoqueRepository _rep;

        public CategoriaEstoqueServiceBase(ICategoriaEstoqueRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<CategoriaEstoque> GetOne(CategoriaEstoqueFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<CategoriaEstoque>> GetByFilters(CategoriaEstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<CategoriaEstoque>> GetByFiltersPaging(CategoriaEstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(CategoriaEstoque categoriaestoque)
        {
            this._rep.Remove(categoriaestoque);
        }

        public virtual Summary GetSummary(PaginateResult<CategoriaEstoque> paginateResult)
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

        public override async Task<CategoriaEstoque> Save(CategoriaEstoque categoriaestoque, bool questionToContinue = false)
        {
			var categoriaestoqueOld = await this.GetOne(new CategoriaEstoqueFilter { CategoriaEstoqueId = categoriaestoque.CategoriaEstoqueId });
			var categoriaestoqueOrchestrated = await this.DomainOrchestration(categoriaestoque, categoriaestoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(categoriaestoqueOrchestrated, categoriaestoqueOld) == false)
                    return categoriaestoqueOrchestrated;
            }

            return this.SaveWithValidation(categoriaestoqueOrchestrated, categoriaestoqueOld);
        }

        public override async Task<CategoriaEstoque> SavePartial(CategoriaEstoque categoriaestoque, bool questionToContinue = false)
        {
            var categoriaestoqueOld = await this.GetOne(new CategoriaEstoqueFilter { CategoriaEstoqueId = categoriaestoque.CategoriaEstoqueId });
			var categoriaestoqueOrchestrated = await this.DomainOrchestration(categoriaestoque, categoriaestoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(categoriaestoqueOrchestrated, categoriaestoqueOld) == false)
                    return categoriaestoqueOrchestrated;
            }

            return SaveWithOutValidation(categoriaestoqueOrchestrated, categoriaestoqueOld);
        }

        protected override CategoriaEstoque SaveWithOutValidation(CategoriaEstoque categoriaestoque, CategoriaEstoque categoriaestoqueOld)
        {
            categoriaestoque = this.SaveDefault(categoriaestoque, categoriaestoqueOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return categoriaestoque;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "categoriaestoque Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return categoriaestoque;

        }

		protected override CategoriaEstoque SaveWithValidation(CategoriaEstoque categoriaestoque, CategoriaEstoque categoriaestoqueOld)
        {
            if (!this.DataAnnotationIsValid())
                return categoriaestoque;

            if (!categoriaestoque.IsValid())
            {
                base._validationResult = categoriaestoque.GetDomainValidation();
                return categoriaestoque;
            }

            this.Specifications(categoriaestoque);

            if (!base._validationResult.IsValid)
                return categoriaestoque;
            
            categoriaestoque = this.SaveDefault(categoriaestoque, categoriaestoqueOld);
            base._validationResult.Message = "CategoriaEstoque cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return categoriaestoque;
        }

		protected virtual void Specifications(CategoriaEstoque categoriaestoque)
        {
            base._validationResult  = new CategoriaEstoqueAptoParaCadastroValidation(this._rep).Validate(categoriaestoque);
			base._validationWarning  = new CategoriaEstoqueAptoParaCadastroWarning(this._rep).Validate(categoriaestoque);
        }

        protected virtual CategoriaEstoque SaveDefault(CategoriaEstoque categoriaestoque, CategoriaEstoque categoriaestoqueOld)
        {
			

            var isNew = categoriaestoqueOld.IsNull();			
            if (isNew)
                categoriaestoque = this.AddDefault(categoriaestoque);
            else
				categoriaestoque = this.UpdateDefault(categoriaestoque, categoriaestoqueOld);

            return categoriaestoque;
        }
		
        protected virtual CategoriaEstoque AddDefault(CategoriaEstoque categoriaestoque)
        {
            categoriaestoque = this._rep.Add(categoriaestoque);
            return categoriaestoque;
        }

		protected virtual CategoriaEstoque UpdateDefault(CategoriaEstoque categoriaestoque, CategoriaEstoque categoriaestoqueOld)
        {
            categoriaestoque = this._rep.Update(categoriaestoque);
            return categoriaestoque;
        }
				
		public virtual async Task<CategoriaEstoque> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new CategoriaEstoque.CategoriaEstoqueFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<CategoriaEstoque> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new CategoriaEstoque.CategoriaEstoqueFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
