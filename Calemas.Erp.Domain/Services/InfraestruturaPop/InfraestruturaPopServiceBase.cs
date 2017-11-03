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
    public class InfraestruturaPopServiceBase : ServiceBase<InfraestruturaPop>
    {
        protected readonly IInfraestruturaPopRepository _rep;

        public InfraestruturaPopServiceBase(IInfraestruturaPopRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<InfraestruturaPop> GetOne(InfraestruturaPopFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<InfraestruturaPop>> GetByFilters(InfraestruturaPopFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<InfraestruturaPop>> GetByFiltersPaging(InfraestruturaPopFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(InfraestruturaPop infraestruturapop)
        {
            this._rep.Remove(infraestruturapop);
        }

        public virtual Summary GetSummary(PaginateResult<InfraestruturaPop> paginateResult)
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

        public override async Task<InfraestruturaPop> Save(InfraestruturaPop infraestruturapop, bool questionToContinue = false)
        {
			var infraestruturapopOld = await this.GetOne(new InfraestruturaPopFilter { InfraestruturaPopId = infraestruturapop.InfraestruturaPopId });
			var infraestruturapopOrchestrated = await this.DomainOrchestration(infraestruturapop, infraestruturapopOld);

            if (questionToContinue)
            {
                if (base.Continue(infraestruturapopOrchestrated, infraestruturapopOld) == false)
                    return infraestruturapopOrchestrated;
            }

            return this.SaveWithValidation(infraestruturapopOrchestrated, infraestruturapopOld);
        }

        public override async Task<InfraestruturaPop> SavePartial(InfraestruturaPop infraestruturapop, bool questionToContinue = false)
        {
            var infraestruturapopOld = await this.GetOne(new InfraestruturaPopFilter { InfraestruturaPopId = infraestruturapop.InfraestruturaPopId });
			var infraestruturapopOrchestrated = await this.DomainOrchestration(infraestruturapop, infraestruturapopOld);

            if (questionToContinue)
            {
                if (base.Continue(infraestruturapopOrchestrated, infraestruturapopOld) == false)
                    return infraestruturapopOrchestrated;
            }

            return SaveWithOutValidation(infraestruturapopOrchestrated, infraestruturapopOld);
        }

        protected override InfraestruturaPop SaveWithOutValidation(InfraestruturaPop infraestruturapop, InfraestruturaPop infraestruturapopOld)
        {
            infraestruturapop = this.SaveDefault(infraestruturapop, infraestruturapopOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return infraestruturapop;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "infraestruturapop Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return infraestruturapop;

        }

		protected override InfraestruturaPop SaveWithValidation(InfraestruturaPop infraestruturapop, InfraestruturaPop infraestruturapopOld)
        {
            if (!this.DataAnnotationIsValid())
                return infraestruturapop;

            if (!infraestruturapop.IsValid())
            {
                base._validationResult = infraestruturapop.GetDomainValidation();
                return infraestruturapop;
            }

            this.Specifications(infraestruturapop);

            if (!base._validationResult.IsValid)
                return infraestruturapop;
            
            infraestruturapop = this.SaveDefault(infraestruturapop, infraestruturapopOld);
            base._validationResult.Message = "InfraestruturaPop cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return infraestruturapop;
        }

		protected virtual void Specifications(InfraestruturaPop infraestruturapop)
        {
            base._validationResult  = new InfraestruturaPopAptoParaCadastroValidation(this._rep).Validate(infraestruturapop);
			base._validationWarning  = new InfraestruturaPopAptoParaCadastroWarning(this._rep).Validate(infraestruturapop);
        }

        protected virtual InfraestruturaPop SaveDefault(InfraestruturaPop infraestruturapop, InfraestruturaPop infraestruturapopOld)
        {
			infraestruturapop = this.AuditDefault(infraestruturapop, infraestruturapopOld);

            var isNew = infraestruturapopOld.IsNull();			
            if (isNew)
                infraestruturapop = this.AddDefault(infraestruturapop);
            else
				infraestruturapop = this.UpdateDefault(infraestruturapop, infraestruturapopOld);

            return infraestruturapop;
        }
		
        protected virtual InfraestruturaPop AddDefault(InfraestruturaPop infraestruturapop)
        {
            infraestruturapop = this._rep.Add(infraestruturapop);
            return infraestruturapop;
        }

		protected virtual InfraestruturaPop UpdateDefault(InfraestruturaPop infraestruturapop, InfraestruturaPop infraestruturapopOld)
        {
            infraestruturapop = this._rep.Update(infraestruturapop);
            return infraestruturapop;
        }
				
		public virtual async Task<InfraestruturaPop> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new InfraestruturaPop.InfraestruturaPopFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<InfraestruturaPop> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new InfraestruturaPop.InfraestruturaPopFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
