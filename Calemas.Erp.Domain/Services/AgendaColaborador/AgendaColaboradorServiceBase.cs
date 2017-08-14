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
    public class AgendaColaboradorServiceBase : ServiceBase<AgendaColaborador>
    {
        protected readonly IAgendaColaboradorRepository _rep;

        public AgendaColaboradorServiceBase(IAgendaColaboradorRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<AgendaColaborador> GetOne(AgendaColaboradorFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<AgendaColaborador>> GetByFilters(AgendaColaboradorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<AgendaColaborador>> GetByFiltersPaging(AgendaColaboradorFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(AgendaColaborador agendacolaborador)
        {
            this._rep.Remove(agendacolaborador);
        }

        public virtual Summary GetSummary(PaginateResult<AgendaColaborador> paginateResult)
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

        public override async Task<AgendaColaborador> Save(AgendaColaborador agendacolaborador, bool questionToContinue = false)
        {
			var agendacolaboradorOld = await this.GetOne(new AgendaColaboradorFilter { AgendaId = agendacolaborador.AgendaId, ColaboradorId = agendacolaborador.ColaboradorId });
			var agendacolaboradorOrchestrated = await this.DomainOrchestration(agendacolaborador, agendacolaboradorOld);

            if (questionToContinue)
            {
                if (base.Continue(agendacolaboradorOrchestrated, agendacolaboradorOld) == false)
                    return agendacolaboradorOrchestrated;
            }

            return this.SaveWithValidation(agendacolaboradorOrchestrated, agendacolaboradorOld);
        }

        public override async Task<AgendaColaborador> SavePartial(AgendaColaborador agendacolaborador, bool questionToContinue = false)
        {
            var agendacolaboradorOld = await this.GetOne(new AgendaColaboradorFilter { AgendaId = agendacolaborador.AgendaId, ColaboradorId = agendacolaborador.ColaboradorId });
			var agendacolaboradorOrchestrated = await this.DomainOrchestration(agendacolaborador, agendacolaboradorOld);

            if (questionToContinue)
            {
                if (base.Continue(agendacolaboradorOrchestrated, agendacolaboradorOld) == false)
                    return agendacolaboradorOrchestrated;
            }

            return SaveWithOutValidation(agendacolaboradorOrchestrated, agendacolaboradorOld);
        }

        protected override AgendaColaborador SaveWithOutValidation(AgendaColaborador agendacolaborador, AgendaColaborador agendacolaboradorOld)
        {
            agendacolaborador = this.SaveDefault(agendacolaborador, agendacolaboradorOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return agendacolaborador;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "agendacolaborador Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return agendacolaborador;

        }

		protected override AgendaColaborador SaveWithValidation(AgendaColaborador agendacolaborador, AgendaColaborador agendacolaboradorOld)
        {
            if (!this.DataAnnotationIsValid())
                return agendacolaborador;

            if (!agendacolaborador.IsValid())
            {
                base._validationResult = agendacolaborador.GetDomainValidation();
                return agendacolaborador;
            }

            this.Specifications(agendacolaborador);

            if (!base._validationResult.IsValid)
                return agendacolaborador;
            
            agendacolaborador = this.SaveDefault(agendacolaborador, agendacolaboradorOld);
            base._validationResult.Message = "AgendaColaborador cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return agendacolaborador;
        }

		protected virtual void Specifications(AgendaColaborador agendacolaborador)
        {
            base._validationResult  = new AgendaColaboradorAptoParaCadastroValidation(this._rep).Validate(agendacolaborador);
			base._validationWarning  = new AgendaColaboradorAptoParaCadastroWarning(this._rep).Validate(agendacolaborador);
        }

        protected virtual AgendaColaborador SaveDefault(AgendaColaborador agendacolaborador, AgendaColaborador agendacolaboradorOld)
        {
			

            var isNew = agendacolaboradorOld.IsNull();			
            if (isNew)
                agendacolaborador = this.AddDefault(agendacolaborador);
            else
				agendacolaborador = this.UpdateDefault(agendacolaborador);

            return agendacolaborador;
        }
		
        protected virtual AgendaColaborador AddDefault(AgendaColaborador agendacolaborador)
        {
            agendacolaborador = this._rep.Add(agendacolaborador);
            return agendacolaborador;
        }

		protected virtual AgendaColaborador UpdateDefault(AgendaColaborador agendacolaborador)
        {
            agendacolaborador = this._rep.Update(agendacolaborador);
            return agendacolaborador;
        }
				
		public virtual async Task<AgendaColaborador> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new AgendaColaborador.AgendaColaboradorFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<AgendaColaborador> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new AgendaColaborador.AgendaColaboradorFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
