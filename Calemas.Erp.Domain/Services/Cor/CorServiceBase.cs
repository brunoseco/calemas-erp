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
    public class CorServiceBase : ServiceBase<Cor>
    {
        protected readonly ICorRepository _rep;

        public CorServiceBase(ICorRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Cor> GetOne(CorFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Cor>> GetByFilters(CorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Cor>> GetByFiltersPaging(CorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Cor cor)
        {
            this._rep.Remove(cor);
        }

        public virtual Summary GetSummary(PaginateResult<Cor> paginateResult)
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

        public override async Task<Cor> Save(Cor cor, bool questionToContinue = false)
        {
            var corOld = await this.GetOne(new CorFilter { CorId = cor.CorId });
			var corOrchestrated = await this.DomainOrchestration(cor, corOld);

            if (questionToContinue)
            {
                if (base.Continue(corOrchestrated, corOld) == false)
                    return corOrchestrated;
            }

            return this.SaveWithValidation(corOrchestrated, corOld);
        }

        public override async Task<Cor> SavePartial(Cor cor, bool questionToContinue = false)
        {
            var corOld = await this.GetOne(new CorFilter { CorId = cor.CorId });
			var corOrchestrated = await this.DomainOrchestration(cor, corOld);

            if (questionToContinue)
            {
                if (base.Continue(corOrchestrated, corOld) == false)
                    return corOrchestrated;
            }

            return SaveWithOutValidation(corOrchestrated, corOld);
        }

        protected override Cor SaveWithOutValidation(Cor cor, Cor corOld)
        {
            cor = this.SaveDefault(cor, corOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return cor;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "cor Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return cor;

        }

		protected override Cor SaveWithValidation(Cor cor, Cor corOld)
        {
            if (!this.DataAnnotationIsValid())
                return cor;

            if (!cor.IsValid())
            {
                base._validationResult = cor.GetDomainValidation();
                return cor;
            }

            this.Specifications(cor);

            if (!base._validationResult.IsValid)
                return cor;
            
            cor = this.SaveDefault(cor, corOld);
            base._validationResult.Message = "Cor cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return cor;
        }

		protected virtual void Specifications(Cor cor)
        {
            base._validationResult  = new CorAptoParaCadastroValidation(this._rep).Validate(cor);
			base._validationWarning  = new CorAptoParaCadastroWarning(this._rep).Validate(cor);
        }

        protected virtual Cor SaveDefault(Cor cor, Cor corOld)
        {			
			

            var isNew = corOld.IsNull();
			
            if (isNew)
                cor = this._rep.Add(cor);
            else
				cor = this.UpdateDefault(cor);

            return cor;
        }
		
        protected virtual Cor AddDefault(Cor cor)
        {
            cor = this._rep.Add(cor);
            return cor;
        }

		protected virtual Cor UpdateDefault(Cor cor)
        {
            cor = this._rep.Update(cor);
            return cor;
        }
    }
}
