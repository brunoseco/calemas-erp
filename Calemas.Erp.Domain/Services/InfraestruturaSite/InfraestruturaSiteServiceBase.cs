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
    public class InfraestruturaSiteServiceBase : ServiceBase<InfraestruturaSite>
    {
        protected readonly IInfraestruturaSiteRepository _rep;

        public InfraestruturaSiteServiceBase(IInfraestruturaSiteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<InfraestruturaSite> GetOne(InfraestruturaSiteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<InfraestruturaSite>> GetByFilters(InfraestruturaSiteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<InfraestruturaSite>> GetByFiltersPaging(InfraestruturaSiteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(InfraestruturaSite infraestruturasite)
        {
            this._rep.Remove(infraestruturasite);
        }

        public virtual Summary GetSummary(PaginateResult<InfraestruturaSite> paginateResult)
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

        public override async Task<InfraestruturaSite> Save(InfraestruturaSite infraestruturasite, bool questionToContinue = false)
        {
			var infraestruturasiteOld = await this.GetOne(new InfraestruturaSiteFilter { InfraestruturaSiteId = infraestruturasite.InfraestruturaSiteId });
			var infraestruturasiteOrchestrated = await this.DomainOrchestration(infraestruturasite, infraestruturasiteOld);

            if (questionToContinue)
            {
                if (base.Continue(infraestruturasiteOrchestrated, infraestruturasiteOld) == false)
                    return infraestruturasiteOrchestrated;
            }

            return this.SaveWithValidation(infraestruturasiteOrchestrated, infraestruturasiteOld);
        }

        public override async Task<InfraestruturaSite> SavePartial(InfraestruturaSite infraestruturasite, bool questionToContinue = false)
        {
            var infraestruturasiteOld = await this.GetOne(new InfraestruturaSiteFilter { InfraestruturaSiteId = infraestruturasite.InfraestruturaSiteId });
			var infraestruturasiteOrchestrated = await this.DomainOrchestration(infraestruturasite, infraestruturasiteOld);

            if (questionToContinue)
            {
                if (base.Continue(infraestruturasiteOrchestrated, infraestruturasiteOld) == false)
                    return infraestruturasiteOrchestrated;
            }

            return SaveWithOutValidation(infraestruturasiteOrchestrated, infraestruturasiteOld);
        }

        protected override InfraestruturaSite SaveWithOutValidation(InfraestruturaSite infraestruturasite, InfraestruturaSite infraestruturasiteOld)
        {
            infraestruturasite = this.SaveDefault(infraestruturasite, infraestruturasiteOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return infraestruturasite;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "infraestruturasite Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return infraestruturasite;

        }

		protected override InfraestruturaSite SaveWithValidation(InfraestruturaSite infraestruturasite, InfraestruturaSite infraestruturasiteOld)
        {
            if (!this.DataAnnotationIsValid())
                return infraestruturasite;

            if (!infraestruturasite.IsValid())
            {
                base._validationResult = infraestruturasite.GetDomainValidation();
                return infraestruturasite;
            }

            this.Specifications(infraestruturasite);

            if (!base._validationResult.IsValid)
                return infraestruturasite;
            
            infraestruturasite = this.SaveDefault(infraestruturasite, infraestruturasiteOld);
            base._validationResult.Message = "InfraestruturaSite cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return infraestruturasite;
        }

		protected virtual void Specifications(InfraestruturaSite infraestruturasite)
        {
            base._validationResult  = new InfraestruturaSiteAptoParaCadastroValidation(this._rep).Validate(infraestruturasite);
			base._validationWarning  = new InfraestruturaSiteAptoParaCadastroWarning(this._rep).Validate(infraestruturasite);
        }

        protected virtual InfraestruturaSite SaveDefault(InfraestruturaSite infraestruturasite, InfraestruturaSite infraestruturasiteOld)
        {
			infraestruturasite = this.AuditDefault(infraestruturasite, infraestruturasiteOld);

            var isNew = infraestruturasiteOld.IsNull();			
            if (isNew)
                infraestruturasite = this.AddDefault(infraestruturasite);
            else
				infraestruturasite = this.UpdateDefault(infraestruturasite, infraestruturasiteOld);

            return infraestruturasite;
        }
		
        protected virtual InfraestruturaSite AddDefault(InfraestruturaSite infraestruturasite)
        {
            infraestruturasite = this._rep.Add(infraestruturasite);
            return infraestruturasite;
        }

		protected virtual InfraestruturaSite UpdateDefault(InfraestruturaSite infraestruturasite, InfraestruturaSite infraestruturasiteOld)
        {
            infraestruturasite = this._rep.Update(infraestruturasite);
            return infraestruturasite;
        }
				
		public virtual async Task<InfraestruturaSite> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new InfraestruturaSite.InfraestruturaSiteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<InfraestruturaSite> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new InfraestruturaSite.InfraestruturaSiteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
