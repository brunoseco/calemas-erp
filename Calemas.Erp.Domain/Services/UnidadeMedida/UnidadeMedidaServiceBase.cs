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
    public class UnidadeMedidaServiceBase : ServiceBase<UnidadeMedida>
    {
        protected readonly IUnidadeMedidaRepository _rep;

        public UnidadeMedidaServiceBase(IUnidadeMedidaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<UnidadeMedida> GetOne(UnidadeMedidaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<UnidadeMedida>> GetByFilters(UnidadeMedidaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<UnidadeMedida>> GetByFiltersPaging(UnidadeMedidaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(UnidadeMedida unidademedida)
        {
            this._rep.Remove(unidademedida);
        }

        public virtual Summary GetSummary(PaginateResult<UnidadeMedida> paginateResult)
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

        public override async Task<UnidadeMedida> Save(UnidadeMedida unidademedida, bool questionToContinue = false)
        {
			var unidademedidaOld = await this.GetOne(new UnidadeMedidaFilter { UnidadeMedidaId = unidademedida.UnidadeMedidaId });
			var unidademedidaOrchestrated = await this.DomainOrchestration(unidademedida, unidademedidaOld);

            if (questionToContinue)
            {
                if (base.Continue(unidademedidaOrchestrated, unidademedidaOld) == false)
                    return unidademedidaOrchestrated;
            }

            return this.SaveWithValidation(unidademedidaOrchestrated, unidademedidaOld);
        }

        public override async Task<UnidadeMedida> SavePartial(UnidadeMedida unidademedida, bool questionToContinue = false)
        {
            var unidademedidaOld = await this.GetOne(new UnidadeMedidaFilter { UnidadeMedidaId = unidademedida.UnidadeMedidaId });
			var unidademedidaOrchestrated = await this.DomainOrchestration(unidademedida, unidademedidaOld);

            if (questionToContinue)
            {
                if (base.Continue(unidademedidaOrchestrated, unidademedidaOld) == false)
                    return unidademedidaOrchestrated;
            }

            return SaveWithOutValidation(unidademedidaOrchestrated, unidademedidaOld);
        }

        protected override UnidadeMedida SaveWithOutValidation(UnidadeMedida unidademedida, UnidadeMedida unidademedidaOld)
        {
            unidademedida = this.SaveDefault(unidademedida, unidademedidaOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return unidademedida;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "unidademedida Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return unidademedida;

        }

		protected override UnidadeMedida SaveWithValidation(UnidadeMedida unidademedida, UnidadeMedida unidademedidaOld)
        {
            if (!this.DataAnnotationIsValid())
                return unidademedida;

            if (!unidademedida.IsValid())
            {
                base._validationResult = unidademedida.GetDomainValidation();
                return unidademedida;
            }

            this.Specifications(unidademedida);

            if (!base._validationResult.IsValid)
                return unidademedida;
            
            unidademedida = this.SaveDefault(unidademedida, unidademedidaOld);
            base._validationResult.Message = "UnidadeMedida cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return unidademedida;
        }

		protected virtual void Specifications(UnidadeMedida unidademedida)
        {
            base._validationResult  = new UnidadeMedidaAptoParaCadastroValidation(this._rep).Validate(unidademedida);
			base._validationWarning  = new UnidadeMedidaAptoParaCadastroWarning(this._rep).Validate(unidademedida);
        }

        protected virtual UnidadeMedida SaveDefault(UnidadeMedida unidademedida, UnidadeMedida unidademedidaOld)
        {
			

            var isNew = unidademedidaOld.IsNull();			
            if (isNew)
                unidademedida = this.AddDefault(unidademedida);
            else
				unidademedida = this.UpdateDefault(unidademedida, unidademedidaOld);

            return unidademedida;
        }
		
        protected virtual UnidadeMedida AddDefault(UnidadeMedida unidademedida)
        {
            unidademedida = this._rep.Add(unidademedida);
            return unidademedida;
        }

		protected virtual UnidadeMedida UpdateDefault(UnidadeMedida unidademedida, UnidadeMedida unidademedidaOld)
        {
            unidademedida = this._rep.Update(unidademedida);
            return unidademedida;
        }
				
		public virtual async Task<UnidadeMedida> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new UnidadeMedida.UnidadeMedidaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<UnidadeMedida> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new UnidadeMedida.UnidadeMedidaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
