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
    public class StatusOrdemServicoServiceBase : ServiceBase<StatusOrdemServico>
    {
        protected readonly IStatusOrdemServicoRepository _rep;

        public StatusOrdemServicoServiceBase(IStatusOrdemServicoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusOrdemServico> GetOne(StatusOrdemServicoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusOrdemServico>> GetByFilters(StatusOrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusOrdemServico>> GetByFiltersPaging(StatusOrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusOrdemServico statusordemservico)
        {
            this._rep.Remove(statusordemservico);
        }

        public virtual Summary GetSummary(PaginateResult<StatusOrdemServico> paginateResult)
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

        public override async Task<StatusOrdemServico> Save(StatusOrdemServico statusordemservico, bool questionToContinue = false)
        {
			var statusordemservicoOld = await this.GetOne(new StatusOrdemServicoFilter { StatusOrdemServicoId = statusordemservico.StatusOrdemServicoId });
			var statusordemservicoOrchestrated = await this.DomainOrchestration(statusordemservico, statusordemservicoOld);

            if (questionToContinue)
            {
                if (base.Continue(statusordemservicoOrchestrated, statusordemservicoOld) == false)
                    return statusordemservicoOrchestrated;
            }

            return this.SaveWithValidation(statusordemservicoOrchestrated, statusordemservicoOld);
        }

        public override async Task<StatusOrdemServico> SavePartial(StatusOrdemServico statusordemservico, bool questionToContinue = false)
        {
            var statusordemservicoOld = await this.GetOne(new StatusOrdemServicoFilter { StatusOrdemServicoId = statusordemservico.StatusOrdemServicoId });
			var statusordemservicoOrchestrated = await this.DomainOrchestration(statusordemservico, statusordemservicoOld);

            if (questionToContinue)
            {
                if (base.Continue(statusordemservicoOrchestrated, statusordemservicoOld) == false)
                    return statusordemservicoOrchestrated;
            }

            return SaveWithOutValidation(statusordemservicoOrchestrated, statusordemservicoOld);
        }

        protected override StatusOrdemServico SaveWithOutValidation(StatusOrdemServico statusordemservico, StatusOrdemServico statusordemservicoOld)
        {
            statusordemservico = this.SaveDefault(statusordemservico, statusordemservicoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return statusordemservico;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "statusordemservico Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return statusordemservico;

        }

		protected override StatusOrdemServico SaveWithValidation(StatusOrdemServico statusordemservico, StatusOrdemServico statusordemservicoOld)
        {
            if (!this.DataAnnotationIsValid())
                return statusordemservico;

            if (!statusordemservico.IsValid())
            {
                base._validationResult = statusordemservico.GetDomainValidation();
                return statusordemservico;
            }

            this.Specifications(statusordemservico);

            if (!base._validationResult.IsValid)
                return statusordemservico;
            
            statusordemservico = this.SaveDefault(statusordemservico, statusordemservicoOld);
            base._validationResult.Message = "StatusOrdemServico cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return statusordemservico;
        }

		protected virtual void Specifications(StatusOrdemServico statusordemservico)
        {
            base._validationResult  = new StatusOrdemServicoAptoParaCadastroValidation(this._rep).Validate(statusordemservico);
			base._validationWarning  = new StatusOrdemServicoAptoParaCadastroWarning(this._rep).Validate(statusordemservico);
        }

        protected virtual StatusOrdemServico SaveDefault(StatusOrdemServico statusordemservico, StatusOrdemServico statusordemservicoOld)
        {
			statusordemservico = this.AuditDefault(statusordemservico, statusordemservicoOld);

            var isNew = statusordemservicoOld.IsNull();			
            if (isNew)
                statusordemservico = this.AddDefault(statusordemservico);
            else
				statusordemservico = this.UpdateDefault(statusordemservico);

            return statusordemservico;
        }
		
        protected virtual StatusOrdemServico AddDefault(StatusOrdemServico statusordemservico)
        {
            statusordemservico = this._rep.Add(statusordemservico);
            return statusordemservico;
        }

		protected virtual StatusOrdemServico UpdateDefault(StatusOrdemServico statusordemservico)
        {
            statusordemservico = this._rep.Update(statusordemservico);
            return statusordemservico;
        }
				
		public virtual async Task<StatusOrdemServico> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusOrdemServico.StatusOrdemServicoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusOrdemServico> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusOrdemServico.StatusOrdemServicoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
