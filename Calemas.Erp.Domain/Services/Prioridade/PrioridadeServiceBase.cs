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
    public class PrioridadeServiceBase : ServiceBase<Prioridade>
    {
        protected readonly IPrioridadeRepository _rep;

        public PrioridadeServiceBase(IPrioridadeRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Prioridade> GetOne(PrioridadeFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Prioridade>> GetByFilters(PrioridadeFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Prioridade>> GetByFiltersPaging(PrioridadeFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Prioridade prioridade)
        {
            this._rep.Remove(prioridade);
        }

        public virtual Summary GetSummary(PaginateResult<Prioridade> paginateResult)
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

        public override async Task<Prioridade> Save(Prioridade prioridade, bool questionToContinue = false)
        {
            var prioridadeOld = await this.GetOne(new PrioridadeFilter { PrioridadeId = prioridade.PrioridadeId });
			var prioridadeOrchestrated = await this.DomainOrchestration(prioridade, prioridadeOld);

            if (questionToContinue)
            {
                if (base.Continue(prioridadeOrchestrated, prioridadeOld) == false)
                    return prioridadeOrchestrated;
            }

            return this.SaveWithValidation(prioridadeOrchestrated, prioridadeOld);
        }

        public override async Task<Prioridade> SavePartial(Prioridade prioridade, bool questionToContinue = false)
        {
            var prioridadeOld = await this.GetOne(new PrioridadeFilter { PrioridadeId = prioridade.PrioridadeId });
			var prioridadeOrchestrated = await this.DomainOrchestration(prioridade, prioridadeOld);

            if (questionToContinue)
            {
                if (base.Continue(prioridadeOrchestrated, prioridadeOld) == false)
                    return prioridadeOrchestrated;
            }

            return SaveWithOutValidation(prioridadeOrchestrated, prioridadeOld);
        }

        protected override Prioridade SaveWithOutValidation(Prioridade prioridade, Prioridade prioridadeOld)
        {
            prioridade = this.SaveDefault(prioridade, prioridadeOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return prioridade;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "prioridade Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return prioridade;

        }

		protected override Prioridade SaveWithValidation(Prioridade prioridade, Prioridade prioridadeOld)
        {
            if (!this.DataAnnotationIsValid())
                return prioridade;

            if (!prioridade.IsValid())
            {
                base._validationResult = prioridade.GetDomainValidation();
                return prioridade;
            }

            this.Specifications(prioridade);

            if (!base._validationResult.IsValid)
                return prioridade;
            
            prioridade = this.SaveDefault(prioridade, prioridadeOld);
            base._validationResult.Message = "Prioridade cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return prioridade;
        }

		protected virtual void Specifications(Prioridade prioridade)
        {
            base._validationResult  = new PrioridadeAptoParaCadastroValidation(this._rep).Validate(prioridade);
			base._validationWarning  = new PrioridadeAptoParaCadastroWarning(this._rep).Validate(prioridade);
        }

        protected virtual Prioridade SaveDefault(Prioridade prioridade, Prioridade prioridadeOld)
        {			
			prioridade = this.AuditDefault(prioridade, prioridadeOld);

            var isNew = prioridadeOld.IsNull();
			
            if (isNew)
                prioridade = this.AddDefault(prioridade);
            else
				prioridade = this.UpdateDefault(prioridade);

            return prioridade;
        }
		
        protected virtual Prioridade AddDefault(Prioridade prioridade)
        {
            prioridade = this._rep.Add(prioridade);
            return prioridade;
        }

		protected virtual Prioridade UpdateDefault(Prioridade prioridade)
        {
            prioridade = this._rep.Update(prioridade);
            return prioridade;
        }
    }
}
