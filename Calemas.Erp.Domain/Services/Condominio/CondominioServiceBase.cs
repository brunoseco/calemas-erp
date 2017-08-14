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
    public class CondominioServiceBase : ServiceBase<Condominio>
    {
        protected readonly ICondominioRepository _rep;

        public CondominioServiceBase(ICondominioRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Condominio> GetOne(CondominioFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Condominio>> GetByFilters(CondominioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Condominio>> GetByFiltersPaging(CondominioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Condominio condominio)
        {
            this._rep.Remove(condominio);
        }

        public virtual Summary GetSummary(PaginateResult<Condominio> paginateResult)
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

        public override async Task<Condominio> Save(Condominio condominio, bool questionToContinue = false)
        {
			var condominioOld = await this.GetOne(new CondominioFilter { CondominioId = condominio.CondominioId });
			var condominioOrchestrated = await this.DomainOrchestration(condominio, condominioOld);

            if (questionToContinue)
            {
                if (base.Continue(condominioOrchestrated, condominioOld) == false)
                    return condominioOrchestrated;
            }

            return this.SaveWithValidation(condominioOrchestrated, condominioOld);
        }

        public override async Task<Condominio> SavePartial(Condominio condominio, bool questionToContinue = false)
        {
            var condominioOld = await this.GetOne(new CondominioFilter { CondominioId = condominio.CondominioId });
			var condominioOrchestrated = await this.DomainOrchestration(condominio, condominioOld);

            if (questionToContinue)
            {
                if (base.Continue(condominioOrchestrated, condominioOld) == false)
                    return condominioOrchestrated;
            }

            return SaveWithOutValidation(condominioOrchestrated, condominioOld);
        }

        protected override Condominio SaveWithOutValidation(Condominio condominio, Condominio condominioOld)
        {
            condominio = this.SaveDefault(condominio, condominioOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return condominio;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "condominio Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return condominio;

        }

		protected override Condominio SaveWithValidation(Condominio condominio, Condominio condominioOld)
        {
            if (!this.DataAnnotationIsValid())
                return condominio;

            if (!condominio.IsValid())
            {
                base._validationResult = condominio.GetDomainValidation();
                return condominio;
            }

            this.Specifications(condominio);

            if (!base._validationResult.IsValid)
                return condominio;
            
            condominio = this.SaveDefault(condominio, condominioOld);
            base._validationResult.Message = "Condominio cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return condominio;
        }

		protected virtual void Specifications(Condominio condominio)
        {
            base._validationResult  = new CondominioAptoParaCadastroValidation(this._rep).Validate(condominio);
			base._validationWarning  = new CondominioAptoParaCadastroWarning(this._rep).Validate(condominio);
        }

        protected virtual Condominio SaveDefault(Condominio condominio, Condominio condominioOld)
        {
			condominio = this.AuditDefault(condominio, condominioOld);

            var isNew = condominioOld.IsNull();			
            if (isNew)
                condominio = this.AddDefault(condominio);
            else
				condominio = this.UpdateDefault(condominio);

            return condominio;
        }
		
        protected virtual Condominio AddDefault(Condominio condominio)
        {
            condominio = this._rep.Add(condominio);
            return condominio;
        }

		protected virtual Condominio UpdateDefault(Condominio condominio)
        {
            condominio = this._rep.Update(condominio);
            return condominio;
        }
				
		public virtual async Task<Condominio> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Condominio.CondominioFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Condominio> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Condominio.CondominioFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
