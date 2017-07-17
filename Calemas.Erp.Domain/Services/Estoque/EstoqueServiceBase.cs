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
    public class EstoqueServiceBase : ServiceBase<Estoque>
    {
        protected readonly IEstoqueRepository _rep;

        public EstoqueServiceBase(IEstoqueRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Estoque> GetOne(EstoqueFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Estoque>> GetByFilters(EstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Estoque>> GetByFiltersPaging(EstoqueFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Estoque estoque)
        {
            this._rep.Remove(estoque);
        }

        public virtual Summary GetSummary(PaginateResult<Estoque> paginateResult)
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

        public override async Task<Estoque> Save(Estoque estoque, bool questionToContinue = false)
        {
            var estoqueOld = await this.GetOne(new EstoqueFilter { EstoqueId = estoque.EstoqueId });
			var estoqueOrchestrated = await this.DomainOrchestration(estoque, estoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(estoqueOrchestrated, estoqueOld) == false)
                    return estoqueOrchestrated;
            }

            return this.SaveWithValidation(estoqueOrchestrated, estoqueOld);
        }

        public override async Task<Estoque> SavePartial(Estoque estoque, bool questionToContinue = false)
        {
            var estoqueOld = await this.GetOne(new EstoqueFilter { EstoqueId = estoque.EstoqueId });
			var estoqueOrchestrated = await this.DomainOrchestration(estoque, estoqueOld);

            if (questionToContinue)
            {
                if (base.Continue(estoqueOrchestrated, estoqueOld) == false)
                    return estoqueOrchestrated;
            }

            return SaveWithOutValidation(estoqueOrchestrated, estoqueOld);
        }

        protected override Estoque SaveWithOutValidation(Estoque estoque, Estoque estoqueOld)
        {
            estoque = this.SaveDefault(estoque, estoqueOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return estoque;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "estoque Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return estoque;

        }

		protected override Estoque SaveWithValidation(Estoque estoque, Estoque estoqueOld)
        {
            if (!this.DataAnnotationIsValid())
                return estoque;

            if (!estoque.IsValid())
            {
                base._validationResult = estoque.GetDomainValidation();
                return estoque;
            }

            this.Specifications(estoque);

            if (!base._validationResult.IsValid)
                return estoque;
            
            estoque = this.SaveDefault(estoque, estoqueOld);
            base._validationResult.Message = "Estoque cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return estoque;
        }

		protected virtual void Specifications(Estoque estoque)
        {
            base._validationResult  = new EstoqueAptoParaCadastroValidation(this._rep).Validate(estoque);
			base._validationWarning  = new EstoqueAptoParaCadastroWarning(this._rep).Validate(estoque);
        }

        protected virtual Estoque SaveDefault(Estoque estoque, Estoque estoqueOld)
        {			
			estoque = this.AuditDefault(estoque, estoqueOld);

            var isNew = estoqueOld.IsNull();
			
            if (isNew)
                estoque = this._rep.Add(estoque);
            else
				estoque = this.UpdateDefault(estoque);

            return estoque;
        }
		
        protected virtual Estoque AddDefault(Estoque estoque)
        {
            estoque = this._rep.Add(estoque);
            return estoque;
        }

		protected virtual Estoque UpdateDefault(Estoque estoque)
        {
            estoque = this._rep.Update(estoque);
            return estoque;
        }
    }
}
