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
    public class FinanceiroServiceBase : ServiceBase<Financeiro>
    {
        protected readonly IFinanceiroRepository _rep;

        public FinanceiroServiceBase(IFinanceiroRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Financeiro> GetOne(FinanceiroFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Financeiro>> GetByFilters(FinanceiroFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Financeiro>> GetByFiltersPaging(FinanceiroFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Financeiro financeiro)
        {
            this._rep.Remove(financeiro);
        }

        public virtual Summary GetSummary(PaginateResult<Financeiro> paginateResult)
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

        public override async Task<Financeiro> Save(Financeiro financeiro, bool questionToContinue = false)
        {
            var financeiroOld = await this.GetOne(new FinanceiroFilter { FinanceiroId = financeiro.FinanceiroId });
			var financeiroOrchestrated = await this.DomainOrchestration(financeiro, financeiroOld);

            if (questionToContinue)
            {
                if (base.Continue(financeiroOrchestrated, financeiroOld) == false)
                    return financeiroOrchestrated;
            }

            return this.SaveWithValidation(financeiroOrchestrated, financeiroOld);
        }

        public override async Task<Financeiro> SavePartial(Financeiro financeiro, bool questionToContinue = false)
        {
            var financeiroOld = await this.GetOne(new FinanceiroFilter { FinanceiroId = financeiro.FinanceiroId });
			var financeiroOrchestrated = await this.DomainOrchestration(financeiro, financeiroOld);

            if (questionToContinue)
            {
                if (base.Continue(financeiroOrchestrated, financeiroOld) == false)
                    return financeiroOrchestrated;
            }

            return SaveWithOutValidation(financeiroOrchestrated, financeiroOld);
        }

        protected override Financeiro SaveWithOutValidation(Financeiro financeiro, Financeiro financeiroOld)
        {
            financeiro = this.SaveDefault(financeiro, financeiroOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return financeiro;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "financeiro Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return financeiro;

        }

		protected override Financeiro SaveWithValidation(Financeiro financeiro, Financeiro financeiroOld)
        {
            if (!this.DataAnnotationIsValid())
                return financeiro;

            if (!financeiro.IsValid())
            {
                base._validationResult = financeiro.GetDomainValidation();
                return financeiro;
            }

            this.Specifications(financeiro);

            if (!base._validationResult.IsValid)
                return financeiro;
            
            financeiro = this.SaveDefault(financeiro, financeiroOld);
            base._validationResult.Message = "Financeiro cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return financeiro;
        }

		protected virtual void Specifications(Financeiro financeiro)
        {
            base._validationResult  = new FinanceiroAptoParaCadastroValidation(this._rep).Validate(financeiro);
			base._validationWarning  = new FinanceiroAptoParaCadastroWarning(this._rep).Validate(financeiro);
        }

        protected virtual Financeiro SaveDefault(Financeiro financeiro, Financeiro financeiroOld)
        {			
			financeiro = this.AuditDefault(financeiro, financeiroOld);

            var isNew = financeiroOld.IsNull();
			
            if (isNew)
                financeiro = this.AddDefault(financeiro);
            else
				financeiro = this.UpdateDefault(financeiro);

            return financeiro;
        }
		
        protected virtual Financeiro AddDefault(Financeiro financeiro)
        {
            financeiro = this._rep.Add(financeiro);
            return financeiro;
        }

		protected virtual Financeiro UpdateDefault(Financeiro financeiro)
        {
            financeiro = this._rep.Update(financeiro);
            return financeiro;
        }
    }
}
