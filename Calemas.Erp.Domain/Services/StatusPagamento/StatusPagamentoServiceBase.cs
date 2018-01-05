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
    public class StatusPagamentoServiceBase : ServiceBase<StatusPagamento>
    {
        protected readonly IStatusPagamentoRepository _rep;

        public StatusPagamentoServiceBase(IStatusPagamentoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<StatusPagamento> GetOne(StatusPagamentoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<StatusPagamento>> GetByFilters(StatusPagamentoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<StatusPagamento>> GetByFiltersPaging(StatusPagamentoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(StatusPagamento statuspagamento)
        {
            this._rep.Remove(statuspagamento);
        }

        public virtual Summary GetSummary(PaginateResult<StatusPagamento> paginateResult)
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

        public override async Task<StatusPagamento> Save(StatusPagamento statuspagamento, bool questionToContinue = false)
        {
			var statuspagamentoOld = await this.GetOne(new StatusPagamentoFilter { StatusPagamentoId = statuspagamento.StatusPagamentoId });
			var statuspagamentoOrchestrated = await this.DomainOrchestration(statuspagamento, statuspagamentoOld);

            if (questionToContinue)
            {
                if (base.Continue(statuspagamentoOrchestrated, statuspagamentoOld) == false)
                    return statuspagamentoOrchestrated;
            }

            return this.SaveWithValidation(statuspagamentoOrchestrated, statuspagamentoOld);
        }

        public override async Task<StatusPagamento> SavePartial(StatusPagamento statuspagamento, bool questionToContinue = false)
        {
            var statuspagamentoOld = await this.GetOne(new StatusPagamentoFilter { StatusPagamentoId = statuspagamento.StatusPagamentoId });
			var statuspagamentoOrchestrated = await this.DomainOrchestration(statuspagamento, statuspagamentoOld);

            if (questionToContinue)
            {
                if (base.Continue(statuspagamentoOrchestrated, statuspagamentoOld) == false)
                    return statuspagamentoOrchestrated;
            }

            return SaveWithOutValidation(statuspagamentoOrchestrated, statuspagamentoOld);
        }

        protected override StatusPagamento SaveWithOutValidation(StatusPagamento statuspagamento, StatusPagamento statuspagamentoOld)
        {
            statuspagamento = this.SaveDefault(statuspagamento, statuspagamentoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return statuspagamento;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "statuspagamento Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return statuspagamento;

        }

		protected override StatusPagamento SaveWithValidation(StatusPagamento statuspagamento, StatusPagamento statuspagamentoOld)
        {
            if (!this.DataAnnotationIsValid())
                return statuspagamento;

            if (!statuspagamento.IsValid())
            {
                base._validationResult = statuspagamento.GetDomainValidation();
                return statuspagamento;
            }

            this.Specifications(statuspagamento);

            if (!base._validationResult.IsValid)
                return statuspagamento;
            
            statuspagamento = this.SaveDefault(statuspagamento, statuspagamentoOld);
            base._validationResult.Message = "StatusPagamento cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return statuspagamento;
        }

		protected virtual void Specifications(StatusPagamento statuspagamento)
        {
            base._validationResult  = new StatusPagamentoAptoParaCadastroValidation(this._rep).Validate(statuspagamento);
			base._validationWarning  = new StatusPagamentoAptoParaCadastroWarning(this._rep).Validate(statuspagamento);
        }

        protected virtual StatusPagamento SaveDefault(StatusPagamento statuspagamento, StatusPagamento statuspagamentoOld)
        {
			

            var isNew = statuspagamentoOld.IsNull();			
            if (isNew)
                statuspagamento = this.AddDefault(statuspagamento);
            else
				statuspagamento = this.UpdateDefault(statuspagamento, statuspagamentoOld);

            return statuspagamento;
        }
		
        protected virtual StatusPagamento AddDefault(StatusPagamento statuspagamento)
        {
            statuspagamento = this._rep.Add(statuspagamento);
            return statuspagamento;
        }

		protected virtual StatusPagamento UpdateDefault(StatusPagamento statuspagamento, StatusPagamento statuspagamentoOld)
        {
            statuspagamento = this._rep.Update(statuspagamento);
            return statuspagamento;
        }
				
		public virtual async Task<StatusPagamento> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusPagamento.StatusPagamentoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<StatusPagamento> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new StatusPagamento.StatusPagamentoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
