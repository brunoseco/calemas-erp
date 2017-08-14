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
    public class StatusClienteServiceBase : ServiceBase<StatusCliente>
    {
        protected readonly IStatusClienteRepository _rep;

        public StatusClienteServiceBase(IStatusClienteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusCliente> GetOne(StatusClienteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusCliente>> GetByFilters(StatusClienteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusCliente>> GetByFiltersPaging(StatusClienteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusCliente statuscliente)
        {
            this._rep.Remove(statuscliente);
        }

        public virtual Summary GetSummary(PaginateResult<StatusCliente> paginateResult)
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

        public override async Task<StatusCliente> Save(StatusCliente statuscliente, bool questionToContinue = false)
        {
			var statusclienteOld = await this.GetOne(new StatusClienteFilter { StatusClienteId = statuscliente.StatusClienteId });
			var statusclienteOrchestrated = await this.DomainOrchestration(statuscliente, statusclienteOld);

            if (questionToContinue)
            {
                if (base.Continue(statusclienteOrchestrated, statusclienteOld) == false)
                    return statusclienteOrchestrated;
            }

            return this.SaveWithValidation(statusclienteOrchestrated, statusclienteOld);
        }

        public override async Task<StatusCliente> SavePartial(StatusCliente statuscliente, bool questionToContinue = false)
        {
            var statusclienteOld = await this.GetOne(new StatusClienteFilter { StatusClienteId = statuscliente.StatusClienteId });
			var statusclienteOrchestrated = await this.DomainOrchestration(statuscliente, statusclienteOld);

            if (questionToContinue)
            {
                if (base.Continue(statusclienteOrchestrated, statusclienteOld) == false)
                    return statusclienteOrchestrated;
            }

            return SaveWithOutValidation(statusclienteOrchestrated, statusclienteOld);
        }

        protected override StatusCliente SaveWithOutValidation(StatusCliente statuscliente, StatusCliente statusclienteOld)
        {
            statuscliente = this.SaveDefault(statuscliente, statusclienteOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return statuscliente;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "statuscliente Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return statuscliente;

        }

		protected override StatusCliente SaveWithValidation(StatusCliente statuscliente, StatusCliente statusclienteOld)
        {
            if (!this.DataAnnotationIsValid())
                return statuscliente;

            if (!statuscliente.IsValid())
            {
                base._validationResult = statuscliente.GetDomainValidation();
                return statuscliente;
            }

            this.Specifications(statuscliente);

            if (!base._validationResult.IsValid)
                return statuscliente;
            
            statuscliente = this.SaveDefault(statuscliente, statusclienteOld);
            base._validationResult.Message = "StatusCliente cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return statuscliente;
        }

		protected virtual void Specifications(StatusCliente statuscliente)
        {
            base._validationResult  = new StatusClienteAptoParaCadastroValidation(this._rep).Validate(statuscliente);
			base._validationWarning  = new StatusClienteAptoParaCadastroWarning(this._rep).Validate(statuscliente);
        }

        protected virtual StatusCliente SaveDefault(StatusCliente statuscliente, StatusCliente statusclienteOld)
        {
			statuscliente = this.AuditDefault(statuscliente, statusclienteOld);

            var isNew = statusclienteOld.IsNull();			
            if (isNew)
                statuscliente = this.AddDefault(statuscliente);
            else
				statuscliente = this.UpdateDefault(statuscliente);

            return statuscliente;
        }
		
        protected virtual StatusCliente AddDefault(StatusCliente statuscliente)
        {
            statuscliente = this._rep.Add(statuscliente);
            return statuscliente;
        }

		protected virtual StatusCliente UpdateDefault(StatusCliente statuscliente)
        {
            statuscliente = this._rep.Update(statuscliente);
            return statuscliente;
        }
				
		public virtual async Task<StatusCliente> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusCliente.StatusClienteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusCliente> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusCliente.StatusClienteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
