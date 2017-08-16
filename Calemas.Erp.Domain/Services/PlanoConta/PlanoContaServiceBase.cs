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
    public class PlanoContaServiceBase : ServiceBase<PlanoConta>
    {
        protected readonly IPlanoContaRepository _rep;

        public PlanoContaServiceBase(IPlanoContaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<PlanoConta> GetOne(PlanoContaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<PlanoConta>> GetByFilters(PlanoContaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<PlanoConta>> GetByFiltersPaging(PlanoContaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(PlanoConta planoconta)
        {
            this._rep.Remove(planoconta);
        }

        public virtual Summary GetSummary(PaginateResult<PlanoConta> paginateResult)
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

        public override async Task<PlanoConta> Save(PlanoConta planoconta, bool questionToContinue = false)
        {
			var planocontaOld = await this.GetOne(new PlanoContaFilter { PlanoContaId = planoconta.PlanoContaId });
			var planocontaOrchestrated = await this.DomainOrchestration(planoconta, planocontaOld);

            if (questionToContinue)
            {
                if (base.Continue(planocontaOrchestrated, planocontaOld) == false)
                    return planocontaOrchestrated;
            }

            return this.SaveWithValidation(planocontaOrchestrated, planocontaOld);
        }

        public override async Task<PlanoConta> SavePartial(PlanoConta planoconta, bool questionToContinue = false)
        {
            var planocontaOld = await this.GetOne(new PlanoContaFilter { PlanoContaId = planoconta.PlanoContaId });
			var planocontaOrchestrated = await this.DomainOrchestration(planoconta, planocontaOld);

            if (questionToContinue)
            {
                if (base.Continue(planocontaOrchestrated, planocontaOld) == false)
                    return planocontaOrchestrated;
            }

            return SaveWithOutValidation(planocontaOrchestrated, planocontaOld);
        }

        protected override PlanoConta SaveWithOutValidation(PlanoConta planoconta, PlanoConta planocontaOld)
        {
            planoconta = this.SaveDefault(planoconta, planocontaOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return planoconta;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "planoconta Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return planoconta;

        }

		protected override PlanoConta SaveWithValidation(PlanoConta planoconta, PlanoConta planocontaOld)
        {
            if (!this.DataAnnotationIsValid())
                return planoconta;

            if (!planoconta.IsValid())
            {
                base._validationResult = planoconta.GetDomainValidation();
                return planoconta;
            }

            this.Specifications(planoconta);

            if (!base._validationResult.IsValid)
                return planoconta;
            
            planoconta = this.SaveDefault(planoconta, planocontaOld);
            base._validationResult.Message = "PlanoConta cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return planoconta;
        }

		protected virtual void Specifications(PlanoConta planoconta)
        {
            base._validationResult  = new PlanoContaAptoParaCadastroValidation(this._rep).Validate(planoconta);
			base._validationWarning  = new PlanoContaAptoParaCadastroWarning(this._rep).Validate(planoconta);
        }

        protected virtual PlanoConta SaveDefault(PlanoConta planoconta, PlanoConta planocontaOld)
        {
			

            var isNew = planocontaOld.IsNull();			
            if (isNew)
                planoconta = this.AddDefault(planoconta);
            else
				planoconta = this.UpdateDefault(planoconta);

            return planoconta;
        }
		
        protected virtual PlanoConta AddDefault(PlanoConta planoconta)
        {
            planoconta = this._rep.Add(planoconta);
            return planoconta;
        }

		protected virtual PlanoConta UpdateDefault(PlanoConta planoconta)
        {
            planoconta = this._rep.Update(planoconta);
            return planoconta;
        }
				
		public virtual async Task<PlanoConta> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new PlanoConta.PlanoContaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<PlanoConta> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new PlanoConta.PlanoContaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
