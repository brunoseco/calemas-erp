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
    public class TipoOrdemServicoServiceBase : ServiceBase<TipoOrdemServico>
    {
        protected readonly ITipoOrdemServicoRepository _rep;

        public TipoOrdemServicoServiceBase(ITipoOrdemServicoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<TipoOrdemServico> GetOne(TipoOrdemServicoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<TipoOrdemServico>> GetByFilters(TipoOrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<TipoOrdemServico>> GetByFiltersPaging(TipoOrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(TipoOrdemServico tipoordemservico)
        {
            this._rep.Remove(tipoordemservico);
        }

        public virtual Summary GetSummary(PaginateResult<TipoOrdemServico> paginateResult)
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

        public override async Task<TipoOrdemServico> Save(TipoOrdemServico tipoordemservico, bool questionToContinue = false)
        {
            var tipoordemservicoOld = await this.GetOne(new TipoOrdemServicoFilter { TipoOrdemServicoId = tipoordemservico.TipoOrdemServicoId });
			var tipoordemservicoOrchestrated = await this.DomainOrchestration(tipoordemservico, tipoordemservicoOld);

            if (questionToContinue)
            {
                if (base.Continue(tipoordemservicoOrchestrated, tipoordemservicoOld) == false)
                    return tipoordemservicoOrchestrated;
            }

            return this.SaveWithValidation(tipoordemservicoOrchestrated, tipoordemservicoOld);
        }

        public override async Task<TipoOrdemServico> SavePartial(TipoOrdemServico tipoordemservico, bool questionToContinue = false)
        {
            var tipoordemservicoOld = await this.GetOne(new TipoOrdemServicoFilter { TipoOrdemServicoId = tipoordemservico.TipoOrdemServicoId });
			var tipoordemservicoOrchestrated = await this.DomainOrchestration(tipoordemservico, tipoordemservicoOld);

            if (questionToContinue)
            {
                if (base.Continue(tipoordemservicoOrchestrated, tipoordemservicoOld) == false)
                    return tipoordemservicoOrchestrated;
            }

            return SaveWithOutValidation(tipoordemservicoOrchestrated, tipoordemservicoOld);
        }

        protected override TipoOrdemServico SaveWithOutValidation(TipoOrdemServico tipoordemservico, TipoOrdemServico tipoordemservicoOld)
        {
            tipoordemservico = this.SaveDefault(tipoordemservico, tipoordemservicoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
                return tipoordemservico;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "tipoordemservico Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return tipoordemservico;

        }

		protected override TipoOrdemServico SaveWithValidation(TipoOrdemServico tipoordemservico, TipoOrdemServico tipoordemservicoOld)
        {
            if (!this.DataAnnotationIsValid())
                return tipoordemservico;

            if (!tipoordemservico.IsValid())
            {
                base._validationResult = tipoordemservico.GetDomainValidation();
                return tipoordemservico;
            }

            this.Specifications(tipoordemservico);

            if (!base._validationResult.IsValid)
                return tipoordemservico;
            
            tipoordemservico = this.SaveDefault(tipoordemservico, tipoordemservicoOld);
            base._validationResult.Message = "TipoOrdemServico cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return tipoordemservico;
        }

		protected virtual void Specifications(TipoOrdemServico tipoordemservico)
        {
            base._validationResult  = new TipoOrdemServicoAptoParaCadastroValidation(this._rep).Validate(tipoordemservico);
			base._validationWarning  = new TipoOrdemServicoAptoParaCadastroWarning(this._rep).Validate(tipoordemservico);
        }

        protected virtual TipoOrdemServico SaveDefault(TipoOrdemServico tipoordemservico, TipoOrdemServico tipoordemservicoOld)
        {			
			tipoordemservico = this.AuditDefault(tipoordemservico, tipoordemservicoOld);

            var isNew = tipoordemservicoOld.IsNull();
			
            if (isNew)
                tipoordemservico = this.AddDefault(tipoordemservico);
            else
				tipoordemservico = this.UpdateDefault(tipoordemservico);

            return tipoordemservico;
        }
		
        protected virtual TipoOrdemServico AddDefault(TipoOrdemServico tipoordemservico)
        {
            tipoordemservico = this._rep.Add(tipoordemservico);
            return tipoordemservico;
        }

		protected virtual TipoOrdemServico UpdateDefault(TipoOrdemServico tipoordemservico)
        {
            tipoordemservico = this._rep.Update(tipoordemservico);
            return tipoordemservico;
        }
    }
}
