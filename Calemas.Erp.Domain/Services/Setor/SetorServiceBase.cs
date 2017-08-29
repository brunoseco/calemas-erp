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
    public class SetorServiceBase : ServiceBase<Setor>
    {
        protected readonly ISetorRepository _rep;

        public SetorServiceBase(ISetorRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Setor> GetOne(SetorFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Setor>> GetByFilters(SetorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Setor>> GetByFiltersPaging(SetorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Setor setor)
        {
            this._rep.Remove(setor);
        }

        public virtual Summary GetSummary(PaginateResult<Setor> paginateResult)
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

        public override async Task<Setor> Save(Setor setor, bool questionToContinue = false)
        {
			var setorOld = await this.GetOne(new SetorFilter { SetorId = setor.SetorId });
			var setorOrchestrated = await this.DomainOrchestration(setor, setorOld);

            if (questionToContinue)
            {
                if (base.Continue(setorOrchestrated, setorOld) == false)
                    return setorOrchestrated;
            }

            return this.SaveWithValidation(setorOrchestrated, setorOld);
        }

        public override async Task<Setor> SavePartial(Setor setor, bool questionToContinue = false)
        {
            var setorOld = await this.GetOne(new SetorFilter { SetorId = setor.SetorId });
			var setorOrchestrated = await this.DomainOrchestration(setor, setorOld);

            if (questionToContinue)
            {
                if (base.Continue(setorOrchestrated, setorOld) == false)
                    return setorOrchestrated;
            }

            return SaveWithOutValidation(setorOrchestrated, setorOld);
        }

        protected override Setor SaveWithOutValidation(Setor setor, Setor setorOld)
        {
            setor = this.SaveDefault(setor, setorOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return setor;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "setor Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return setor;

        }

		protected override Setor SaveWithValidation(Setor setor, Setor setorOld)
        {
            if (!this.DataAnnotationIsValid())
                return setor;

            if (!setor.IsValid())
            {
                base._validationResult = setor.GetDomainValidation();
                return setor;
            }

            this.Specifications(setor);

            if (!base._validationResult.IsValid)
                return setor;
            
            setor = this.SaveDefault(setor, setorOld);
            base._validationResult.Message = "Setor cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return setor;
        }

		protected virtual void Specifications(Setor setor)
        {
            base._validationResult  = new SetorAptoParaCadastroValidation(this._rep).Validate(setor);
			base._validationWarning  = new SetorAptoParaCadastroWarning(this._rep).Validate(setor);
        }

        protected virtual Setor SaveDefault(Setor setor, Setor setorOld)
        {
			setor = this.AuditDefault(setor, setorOld);

            var isNew = setorOld.IsNull();			
            if (isNew)
                setor = this.AddDefault(setor);
            else
				setor = this.UpdateDefault(setor, setorOld);

            return setor;
        }
		
        protected virtual Setor AddDefault(Setor setor)
        {
            setor = this._rep.Add(setor);
            return setor;
        }

		protected virtual Setor UpdateDefault(Setor setor, Setor setorOld)
        {
            setor = this._rep.Update(setor);
            return setor;
        }
				
		public virtual async Task<Setor> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Setor.SetorFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Setor> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Setor.SetorFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
