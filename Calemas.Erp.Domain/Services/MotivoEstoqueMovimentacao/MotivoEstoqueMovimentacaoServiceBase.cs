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
    public class MotivoEstoqueMovimentacaoServiceBase : ServiceBase<MotivoEstoqueMovimentacao>
    {
        protected readonly IMotivoEstoqueMovimentacaoRepository _rep;

        public MotivoEstoqueMovimentacaoServiceBase(IMotivoEstoqueMovimentacaoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<MotivoEstoqueMovimentacao> GetOne(MotivoEstoqueMovimentacaoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<MotivoEstoqueMovimentacao>> GetByFilters(MotivoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<MotivoEstoqueMovimentacao>> GetByFiltersPaging(MotivoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(MotivoEstoqueMovimentacao motivoestoquemovimentacao)
        {
            this._rep.Remove(motivoestoquemovimentacao);
        }

        public virtual Summary GetSummary(PaginateResult<MotivoEstoqueMovimentacao> paginateResult)
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

        public override async Task<MotivoEstoqueMovimentacao> Save(MotivoEstoqueMovimentacao motivoestoquemovimentacao, bool questionToContinue = false)
        {
			var motivoestoquemovimentacaoOld = await this.GetOne(new MotivoEstoqueMovimentacaoFilter { MotivoEstoqueMovimentacaoId = motivoestoquemovimentacao.MotivoEstoqueMovimentacaoId });
			var motivoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(motivoestoquemovimentacao, motivoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(motivoestoquemovimentacaoOrchestrated, motivoestoquemovimentacaoOld) == false)
                    return motivoestoquemovimentacaoOrchestrated;
            }

            return this.SaveWithValidation(motivoestoquemovimentacaoOrchestrated, motivoestoquemovimentacaoOld);
        }

        public override async Task<MotivoEstoqueMovimentacao> SavePartial(MotivoEstoqueMovimentacao motivoestoquemovimentacao, bool questionToContinue = false)
        {
            var motivoestoquemovimentacaoOld = await this.GetOne(new MotivoEstoqueMovimentacaoFilter { MotivoEstoqueMovimentacaoId = motivoestoquemovimentacao.MotivoEstoqueMovimentacaoId });
			var motivoestoquemovimentacaoOrchestrated = await this.DomainOrchestration(motivoestoquemovimentacao, motivoestoquemovimentacaoOld);

            if (questionToContinue)
            {
                if (base.Continue(motivoestoquemovimentacaoOrchestrated, motivoestoquemovimentacaoOld) == false)
                    return motivoestoquemovimentacaoOrchestrated;
            }

            return SaveWithOutValidation(motivoestoquemovimentacaoOrchestrated, motivoestoquemovimentacaoOld);
        }

        protected override MotivoEstoqueMovimentacao SaveWithOutValidation(MotivoEstoqueMovimentacao motivoestoquemovimentacao, MotivoEstoqueMovimentacao motivoestoquemovimentacaoOld)
        {
            motivoestoquemovimentacao = this.SaveDefault(motivoestoquemovimentacao, motivoestoquemovimentacaoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return motivoestoquemovimentacao;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "motivoestoquemovimentacao Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return motivoestoquemovimentacao;

        }

		protected override MotivoEstoqueMovimentacao SaveWithValidation(MotivoEstoqueMovimentacao motivoestoquemovimentacao, MotivoEstoqueMovimentacao motivoestoquemovimentacaoOld)
        {
            if (!this.DataAnnotationIsValid())
                return motivoestoquemovimentacao;

            if (!motivoestoquemovimentacao.IsValid())
            {
                base._validationResult = motivoestoquemovimentacao.GetDomainValidation();
                return motivoestoquemovimentacao;
            }

            this.Specifications(motivoestoquemovimentacao);

            if (!base._validationResult.IsValid)
                return motivoestoquemovimentacao;
            
            motivoestoquemovimentacao = this.SaveDefault(motivoestoquemovimentacao, motivoestoquemovimentacaoOld);
            base._validationResult.Message = "MotivoEstoqueMovimentacao cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return motivoestoquemovimentacao;
        }

		protected virtual void Specifications(MotivoEstoqueMovimentacao motivoestoquemovimentacao)
        {
            base._validationResult  = new MotivoEstoqueMovimentacaoAptoParaCadastroValidation(this._rep).Validate(motivoestoquemovimentacao);
			base._validationWarning  = new MotivoEstoqueMovimentacaoAptoParaCadastroWarning(this._rep).Validate(motivoestoquemovimentacao);
        }

        protected virtual MotivoEstoqueMovimentacao SaveDefault(MotivoEstoqueMovimentacao motivoestoquemovimentacao, MotivoEstoqueMovimentacao motivoestoquemovimentacaoOld)
        {
			

            var isNew = motivoestoquemovimentacaoOld.IsNull();			
            if (isNew)
                motivoestoquemovimentacao = this.AddDefault(motivoestoquemovimentacao);
            else
				motivoestoquemovimentacao = this.UpdateDefault(motivoestoquemovimentacao, motivoestoquemovimentacaoOld);

            return motivoestoquemovimentacao;
        }
		
        protected virtual MotivoEstoqueMovimentacao AddDefault(MotivoEstoqueMovimentacao motivoestoquemovimentacao)
        {
            motivoestoquemovimentacao = this._rep.Add(motivoestoquemovimentacao);
            return motivoestoquemovimentacao;
        }

		protected virtual MotivoEstoqueMovimentacao UpdateDefault(MotivoEstoqueMovimentacao motivoestoquemovimentacao, MotivoEstoqueMovimentacao motivoestoquemovimentacaoOld)
        {
            motivoestoquemovimentacao = this._rep.Update(motivoestoquemovimentacao);
            return motivoestoquemovimentacao;
        }
				
		public virtual async Task<MotivoEstoqueMovimentacao> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new MotivoEstoqueMovimentacao.MotivoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<MotivoEstoqueMovimentacao> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new MotivoEstoqueMovimentacao.MotivoEstoqueMovimentacaoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
