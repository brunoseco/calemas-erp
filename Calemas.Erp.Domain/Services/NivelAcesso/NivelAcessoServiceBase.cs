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
    public class NivelAcessoServiceBase : ServiceBase<NivelAcesso>
    {
        protected readonly INivelAcessoRepository _rep;

        public NivelAcessoServiceBase(INivelAcessoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<NivelAcesso> GetOne(NivelAcessoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<NivelAcesso>> GetByFilters(NivelAcessoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<NivelAcesso>> GetByFiltersPaging(NivelAcessoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(NivelAcesso nivelacesso)
        {
            this._rep.Remove(nivelacesso);
        }

        public virtual Summary GetSummary(PaginateResult<NivelAcesso> paginateResult)
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

        public override async Task<NivelAcesso> Save(NivelAcesso nivelacesso, bool questionToContinue = false)
        {
            var nivelacessoOld = await this.GetOne(new NivelAcessoFilter { NivelAcessoId = nivelacesso.NivelAcessoId });
			var nivelacessoOrchestrated = await this.DomainOrchestration(nivelacesso, nivelacessoOld);

            if (questionToContinue)
            {
                if (base.Continue(nivelacessoOrchestrated, nivelacessoOld) == false)
                    return nivelacessoOrchestrated;
            }

            return this.SaveWithValidation(nivelacessoOrchestrated, nivelacessoOld);
        }

        public override async Task<NivelAcesso> SavePartial(NivelAcesso nivelacesso, bool questionToContinue = false)
        {
            var nivelacessoOld = await this.GetOne(new NivelAcessoFilter { NivelAcessoId = nivelacesso.NivelAcessoId });
			var nivelacessoOrchestrated = await this.DomainOrchestration(nivelacesso, nivelacessoOld);

            if (questionToContinue)
            {
                if (base.Continue(nivelacessoOrchestrated, nivelacessoOld) == false)
                    return nivelacessoOrchestrated;
            }

            return SaveWithOutValidation(nivelacessoOrchestrated, nivelacessoOld);
        }

        protected override NivelAcesso SaveWithOutValidation(NivelAcesso nivelacesso, NivelAcesso nivelacessoOld)
        {
            nivelacesso = this.SaveDefault(nivelacesso, nivelacessoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return nivelacesso;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "nivelacesso Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return nivelacesso;

        }

		protected override NivelAcesso SaveWithValidation(NivelAcesso nivelacesso, NivelAcesso nivelacessoOld)
        {
            if (!this.DataAnnotationIsValid())
                return nivelacesso;

            if (!nivelacesso.IsValid())
            {
                base._validationResult = nivelacesso.GetDomainValidation();
                return nivelacesso;
            }

            this.Specifications(nivelacesso);

            if (!base._validationResult.IsValid)
                return nivelacesso;
            
            nivelacesso = this.SaveDefault(nivelacesso, nivelacessoOld);
            base._validationResult.Message = "NivelAcesso cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return nivelacesso;
        }

		protected virtual void Specifications(NivelAcesso nivelacesso)
        {
            base._validationResult  = new NivelAcessoAptoParaCadastroValidation(this._rep).Validate(nivelacesso);
			base._validationWarning  = new NivelAcessoAptoParaCadastroWarning(this._rep).Validate(nivelacesso);
        }

        protected virtual NivelAcesso SaveDefault(NivelAcesso nivelacesso, NivelAcesso nivelacessoOld)
        {			
			

            var isNew = nivelacessoOld.IsNull();
			
            if (isNew)
                nivelacesso = this._rep.Add(nivelacesso);
            else
				nivelacesso = this.UpdateDefault(nivelacesso);

            return nivelacesso;
        }
		
        protected virtual NivelAcesso AddDefault(NivelAcesso nivelacesso)
        {
            nivelacesso = this._rep.Add(nivelacesso);
            return nivelacesso;
        }

		protected virtual NivelAcesso UpdateDefault(NivelAcesso nivelacesso)
        {
            nivelacesso = this._rep.Update(nivelacesso);
            return nivelacesso;
        }
    }
}
