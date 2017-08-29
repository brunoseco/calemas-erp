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
    public class TipoPlanoContaServiceBase : ServiceBase<TipoPlanoConta>
    {
        protected readonly ITipoPlanoContaRepository _rep;

        public TipoPlanoContaServiceBase(ITipoPlanoContaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TipoPlanoConta> GetOne(TipoPlanoContaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TipoPlanoConta>> GetByFilters(TipoPlanoContaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TipoPlanoConta>> GetByFiltersPaging(TipoPlanoContaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(TipoPlanoConta tipoplanoconta)
        {
            this._rep.Remove(tipoplanoconta);
        }

        public virtual Summary GetSummary(PaginateResult<TipoPlanoConta> paginateResult)
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

        public override async Task<TipoPlanoConta> Save(TipoPlanoConta tipoplanoconta, bool questionToContinue = false)
        {
			var tipoplanocontaOld = await this.GetOne(new TipoPlanoContaFilter { TipoPlanoContaId = tipoplanoconta.TipoPlanoContaId });
			var tipoplanocontaOrchestrated = await this.DomainOrchestration(tipoplanoconta, tipoplanocontaOld);

            if (questionToContinue)
            {
                if (base.Continue(tipoplanocontaOrchestrated, tipoplanocontaOld) == false)
                    return tipoplanocontaOrchestrated;
            }

            return this.SaveWithValidation(tipoplanocontaOrchestrated, tipoplanocontaOld);
        }

        public override async Task<TipoPlanoConta> SavePartial(TipoPlanoConta tipoplanoconta, bool questionToContinue = false)
        {
            var tipoplanocontaOld = await this.GetOne(new TipoPlanoContaFilter { TipoPlanoContaId = tipoplanoconta.TipoPlanoContaId });
			var tipoplanocontaOrchestrated = await this.DomainOrchestration(tipoplanoconta, tipoplanocontaOld);

            if (questionToContinue)
            {
                if (base.Continue(tipoplanocontaOrchestrated, tipoplanocontaOld) == false)
                    return tipoplanocontaOrchestrated;
            }

            return SaveWithOutValidation(tipoplanocontaOrchestrated, tipoplanocontaOld);
        }

        protected override TipoPlanoConta SaveWithOutValidation(TipoPlanoConta tipoplanoconta, TipoPlanoConta tipoplanocontaOld)
        {
            tipoplanoconta = this.SaveDefault(tipoplanoconta, tipoplanocontaOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return tipoplanoconta;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "tipoplanoconta Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return tipoplanoconta;

        }

		protected override TipoPlanoConta SaveWithValidation(TipoPlanoConta tipoplanoconta, TipoPlanoConta tipoplanocontaOld)
        {
            if (!this.DataAnnotationIsValid())
                return tipoplanoconta;

            if (!tipoplanoconta.IsValid())
            {
                base._validationResult = tipoplanoconta.GetDomainValidation();
                return tipoplanoconta;
            }

            this.Specifications(tipoplanoconta);

            if (!base._validationResult.IsValid)
                return tipoplanoconta;
            
            tipoplanoconta = this.SaveDefault(tipoplanoconta, tipoplanocontaOld);
            base._validationResult.Message = "TipoPlanoConta cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return tipoplanoconta;
        }

		protected virtual void Specifications(TipoPlanoConta tipoplanoconta)
        {
            base._validationResult  = new TipoPlanoContaAptoParaCadastroValidation(this._rep).Validate(tipoplanoconta);
			base._validationWarning  = new TipoPlanoContaAptoParaCadastroWarning(this._rep).Validate(tipoplanoconta);
        }

        protected virtual TipoPlanoConta SaveDefault(TipoPlanoConta tipoplanoconta, TipoPlanoConta tipoplanocontaOld)
        {
			

            var isNew = tipoplanocontaOld.IsNull();			
            if (isNew)
                tipoplanoconta = this.AddDefault(tipoplanoconta);
            else
				tipoplanoconta = this.UpdateDefault(tipoplanoconta, tipoplanocontaOld);

            return tipoplanoconta;
        }
		
        protected virtual TipoPlanoConta AddDefault(TipoPlanoConta tipoplanoconta)
        {
            tipoplanoconta = this._rep.Add(tipoplanoconta);
            return tipoplanoconta;
        }

		protected virtual TipoPlanoConta UpdateDefault(TipoPlanoConta tipoplanoconta, TipoPlanoConta tipoplanocontaOld)
        {
            tipoplanoconta = this._rep.Update(tipoplanoconta);
            return tipoplanoconta;
        }
				
		public virtual async Task<TipoPlanoConta> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoPlanoConta.TipoPlanoContaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<TipoPlanoConta> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new TipoPlanoConta.TipoPlanoContaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
