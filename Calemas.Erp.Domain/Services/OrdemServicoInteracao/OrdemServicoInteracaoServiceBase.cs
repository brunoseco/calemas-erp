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
    public class OrdemServicoInteracaoServiceBase : ServiceBase<OrdemServicoInteracao>
    {
        protected readonly IOrdemServicoInteracaoRepository _rep;

        public OrdemServicoInteracaoServiceBase(IOrdemServicoInteracaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<OrdemServicoInteracao> GetOne(OrdemServicoInteracaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<OrdemServicoInteracao>> GetByFilters(OrdemServicoInteracaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<OrdemServicoInteracao>> GetByFiltersPaging(OrdemServicoInteracaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(OrdemServicoInteracao ordemservicointeracao)
        {
            this._rep.Remove(ordemservicointeracao);
        }

        public virtual Summary GetSummary(PaginateResult<OrdemServicoInteracao> paginateResult)
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

        public override async Task<OrdemServicoInteracao> Save(OrdemServicoInteracao ordemservicointeracao, bool questionToContinue = false)
        {
			var ordemservicointeracaoOld = await this.GetOne(new OrdemServicoInteracaoFilter { OrdemServicoInteracaoId = ordemservicointeracao.OrdemServicoInteracaoId });
			var ordemservicointeracaoOrchestrated = await this.DomainOrchestration(ordemservicointeracao, ordemservicointeracaoOld);

            if (questionToContinue)
            {
                if (base.Continue(ordemservicointeracaoOrchestrated, ordemservicointeracaoOld) == false)
                    return ordemservicointeracaoOrchestrated;
            }

            return this.SaveWithValidation(ordemservicointeracaoOrchestrated, ordemservicointeracaoOld);
        }

        public override async Task<OrdemServicoInteracao> SavePartial(OrdemServicoInteracao ordemservicointeracao, bool questionToContinue = false)
        {
            var ordemservicointeracaoOld = await this.GetOne(new OrdemServicoInteracaoFilter { OrdemServicoInteracaoId = ordemservicointeracao.OrdemServicoInteracaoId });
			var ordemservicointeracaoOrchestrated = await this.DomainOrchestration(ordemservicointeracao, ordemservicointeracaoOld);

            if (questionToContinue)
            {
                if (base.Continue(ordemservicointeracaoOrchestrated, ordemservicointeracaoOld) == false)
                    return ordemservicointeracaoOrchestrated;
            }

            return SaveWithOutValidation(ordemservicointeracaoOrchestrated, ordemservicointeracaoOld);
        }

        protected override OrdemServicoInteracao SaveWithOutValidation(OrdemServicoInteracao ordemservicointeracao, OrdemServicoInteracao ordemservicointeracaoOld)
        {
            ordemservicointeracao = this.SaveDefault(ordemservicointeracao, ordemservicointeracaoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return ordemservicointeracao;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "ordemservicointeracao Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return ordemservicointeracao;

        }

		protected override OrdemServicoInteracao SaveWithValidation(OrdemServicoInteracao ordemservicointeracao, OrdemServicoInteracao ordemservicointeracaoOld)
        {
            if (!this.DataAnnotationIsValid())
                return ordemservicointeracao;

            if (!ordemservicointeracao.IsValid())
            {
                base._validationResult = ordemservicointeracao.GetDomainValidation();
                return ordemservicointeracao;
            }

            this.Specifications(ordemservicointeracao);

            if (!base._validationResult.IsValid)
                return ordemservicointeracao;
            
            ordemservicointeracao = this.SaveDefault(ordemservicointeracao, ordemservicointeracaoOld);
            base._validationResult.Message = "OrdemServicoInteracao cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return ordemservicointeracao;
        }

		protected virtual void Specifications(OrdemServicoInteracao ordemservicointeracao)
        {
            base._validationResult  = new OrdemServicoInteracaoAptoParaCadastroValidation(this._rep).Validate(ordemservicointeracao);
			base._validationWarning  = new OrdemServicoInteracaoAptoParaCadastroWarning(this._rep).Validate(ordemservicointeracao);
        }

        protected virtual OrdemServicoInteracao SaveDefault(OrdemServicoInteracao ordemservicointeracao, OrdemServicoInteracao ordemservicointeracaoOld)
        {
			

            var isNew = ordemservicointeracaoOld.IsNull();			
            if (isNew)
                ordemservicointeracao = this.AddDefault(ordemservicointeracao);
            else
				ordemservicointeracao = this.UpdateDefault(ordemservicointeracao, ordemservicointeracaoOld);

            return ordemservicointeracao;
        }
		
        protected virtual OrdemServicoInteracao AddDefault(OrdemServicoInteracao ordemservicointeracao)
        {
            ordemservicointeracao = this._rep.Add(ordemservicointeracao);
            return ordemservicointeracao;
        }

		protected virtual OrdemServicoInteracao UpdateDefault(OrdemServicoInteracao ordemservicointeracao, OrdemServicoInteracao ordemservicointeracaoOld)
        {
            ordemservicointeracao = this._rep.Update(ordemservicointeracao);
            return ordemservicointeracao;
        }
				
		public virtual async Task<OrdemServicoInteracao> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new OrdemServicoInteracao.OrdemServicoInteracaoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<OrdemServicoInteracao> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new OrdemServicoInteracao.OrdemServicoInteracaoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
