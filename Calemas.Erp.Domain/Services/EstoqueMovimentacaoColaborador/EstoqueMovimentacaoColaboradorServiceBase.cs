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
    public class EstoqueMovimentacaoColaboradorServiceBase : ServiceBase<EstoqueMovimentacaoColaborador>
    {
        protected readonly IEstoqueMovimentacaoColaboradorRepository _rep;

        public EstoqueMovimentacaoColaboradorServiceBase(IEstoqueMovimentacaoColaboradorRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<EstoqueMovimentacaoColaborador> GetOne(EstoqueMovimentacaoColaboradorFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<EstoqueMovimentacaoColaborador>> GetByFilters(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<EstoqueMovimentacaoColaborador>> GetByFiltersPaging(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador)
        {
            this._rep.Remove(estoquemovimentacaocolaborador);
        }

        public virtual Summary GetSummary(PaginateResult<EstoqueMovimentacaoColaborador> paginateResult)
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

        public override async Task<EstoqueMovimentacaoColaborador> Save(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, bool questionToContinue = false)
        {
			var estoquemovimentacaocolaboradorOld = await this.GetOne(new EstoqueMovimentacaoColaboradorFilter { EstoqueMovimentacaoColaboradorId = estoquemovimentacaocolaborador.EstoqueMovimentacaoColaboradorId });
			var estoquemovimentacaocolaboradorOrchestrated = await this.DomainOrchestration(estoquemovimentacaocolaborador, estoquemovimentacaocolaboradorOld);

            if (questionToContinue)
            {
                if (base.Continue(estoquemovimentacaocolaboradorOrchestrated, estoquemovimentacaocolaboradorOld) == false)
                    return estoquemovimentacaocolaboradorOrchestrated;
            }

            return this.SaveWithValidation(estoquemovimentacaocolaboradorOrchestrated, estoquemovimentacaocolaboradorOld);
        }

        public override async Task<EstoqueMovimentacaoColaborador> SavePartial(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, bool questionToContinue = false)
        {
            var estoquemovimentacaocolaboradorOld = await this.GetOne(new EstoqueMovimentacaoColaboradorFilter { EstoqueMovimentacaoColaboradorId = estoquemovimentacaocolaborador.EstoqueMovimentacaoColaboradorId });
			var estoquemovimentacaocolaboradorOrchestrated = await this.DomainOrchestration(estoquemovimentacaocolaborador, estoquemovimentacaocolaboradorOld);

            if (questionToContinue)
            {
                if (base.Continue(estoquemovimentacaocolaboradorOrchestrated, estoquemovimentacaocolaboradorOld) == false)
                    return estoquemovimentacaocolaboradorOrchestrated;
            }

            return SaveWithOutValidation(estoquemovimentacaocolaboradorOrchestrated, estoquemovimentacaocolaboradorOld);
        }

        protected override EstoqueMovimentacaoColaborador SaveWithOutValidation(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, EstoqueMovimentacaoColaborador estoquemovimentacaocolaboradorOld)
        {
            estoquemovimentacaocolaborador = this.SaveDefault(estoquemovimentacaocolaborador, estoquemovimentacaocolaboradorOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return estoquemovimentacaocolaborador;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "estoquemovimentacaocolaborador Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return estoquemovimentacaocolaborador;

        }

		protected override EstoqueMovimentacaoColaborador SaveWithValidation(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, EstoqueMovimentacaoColaborador estoquemovimentacaocolaboradorOld)
        {
            if (!this.DataAnnotationIsValid())
                return estoquemovimentacaocolaborador;

            if (!estoquemovimentacaocolaborador.IsValid())
            {
                base._validationResult = estoquemovimentacaocolaborador.GetDomainValidation();
                return estoquemovimentacaocolaborador;
            }

            this.Specifications(estoquemovimentacaocolaborador);

            if (!base._validationResult.IsValid)
                return estoquemovimentacaocolaborador;
            
            estoquemovimentacaocolaborador = this.SaveDefault(estoquemovimentacaocolaborador, estoquemovimentacaocolaboradorOld);
            base._validationResult.Message = "EstoqueMovimentacaoColaborador cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return estoquemovimentacaocolaborador;
        }

		protected virtual void Specifications(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador)
        {
            base._validationResult  = new EstoqueMovimentacaoColaboradorAptoParaCadastroValidation(this._rep).Validate(estoquemovimentacaocolaborador);
			base._validationWarning  = new EstoqueMovimentacaoColaboradorAptoParaCadastroWarning(this._rep).Validate(estoquemovimentacaocolaborador);
        }

        protected virtual EstoqueMovimentacaoColaborador SaveDefault(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, EstoqueMovimentacaoColaborador estoquemovimentacaocolaboradorOld)
        {
			

            var isNew = estoquemovimentacaocolaboradorOld.IsNull();			
            if (isNew)
                estoquemovimentacaocolaborador = this.AddDefault(estoquemovimentacaocolaborador);
            else
				estoquemovimentacaocolaborador = this.UpdateDefault(estoquemovimentacaocolaborador, estoquemovimentacaocolaboradorOld);

            return estoquemovimentacaocolaborador;
        }
		
        protected virtual EstoqueMovimentacaoColaborador AddDefault(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador)
        {
            estoquemovimentacaocolaborador = this._rep.Add(estoquemovimentacaocolaborador);
            return estoquemovimentacaocolaborador;
        }

		protected virtual EstoqueMovimentacaoColaborador UpdateDefault(EstoqueMovimentacaoColaborador estoquemovimentacaocolaborador, EstoqueMovimentacaoColaborador estoquemovimentacaocolaboradorOld)
        {
            estoquemovimentacaocolaborador = this._rep.Update(estoquemovimentacaocolaborador);
            return estoquemovimentacaocolaborador;
        }
				
		public virtual async Task<EstoqueMovimentacaoColaborador> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new EstoqueMovimentacaoColaborador.EstoqueMovimentacaoColaboradorFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<EstoqueMovimentacaoColaborador> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new EstoqueMovimentacaoColaborador.EstoqueMovimentacaoColaboradorFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
