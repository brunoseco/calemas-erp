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
    public class AgendaServiceBase : ServiceBase<Agenda>
    {
        protected readonly IAgendaRepository _rep;

        public AgendaServiceBase(IAgendaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Agenda> GetOne(AgendaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Agenda>> GetByFilters(AgendaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Agenda>> GetByFiltersPaging(AgendaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Agenda agenda)
        {
            this._rep.Remove(agenda);
        }

        public virtual Summary GetSummary(PaginateResult<Agenda> paginateResult)
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

        public override async Task<Agenda> Save(Agenda agenda, bool questionToContinue = false)
        {
			var agendaOld = await this.GetOne(new AgendaFilter { AgendaId = agenda.AgendaId });
			var agendaOrchestrated = await this.DomainOrchestration(agenda, agendaOld);

            if (questionToContinue)
            {
                if (base.Continue(agendaOrchestrated, agendaOld) == false)
                    return agendaOrchestrated;
            }

            return this.SaveWithValidation(agendaOrchestrated, agendaOld);
        }

        public override async Task<Agenda> SavePartial(Agenda agenda, bool questionToContinue = false)
        {
            var agendaOld = await this.GetOne(new AgendaFilter { AgendaId = agenda.AgendaId });
			var agendaOrchestrated = await this.DomainOrchestration(agenda, agendaOld);

            if (questionToContinue)
            {
                if (base.Continue(agendaOrchestrated, agendaOld) == false)
                    return agendaOrchestrated;
            }

            return SaveWithOutValidation(agendaOrchestrated, agendaOld);
        }

        protected override Agenda SaveWithOutValidation(Agenda agenda, Agenda agendaOld)
        {
            agenda = this.SaveDefault(agenda, agendaOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return agenda;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "agenda Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return agenda;

        }

		protected override Agenda SaveWithValidation(Agenda agenda, Agenda agendaOld)
        {
            if (!this.DataAnnotationIsValid())
                return agenda;

            if (!agenda.IsValid())
            {
                base._validationResult = agenda.GetDomainValidation();
                return agenda;
            }

            this.Specifications(agenda);

            if (!base._validationResult.IsValid)
                return agenda;
            
            agenda = this.SaveDefault(agenda, agendaOld);
            base._validationResult.Message = "Agenda cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return agenda;
        }

		protected virtual void Specifications(Agenda agenda)
        {
            base._validationResult  = new AgendaAptoParaCadastroValidation(this._rep).Validate(agenda);
			base._validationWarning  = new AgendaAptoParaCadastroWarning(this._rep).Validate(agenda);
        }

        protected virtual Agenda SaveDefault(Agenda agenda, Agenda agendaOld)
        {
			agenda = this.AuditDefault(agenda, agendaOld);

            var isNew = agendaOld.IsNull();			
            if (isNew)
                agenda = this.AddDefault(agenda);
            else
				agenda = this.UpdateDefault(agenda);

            return agenda;
        }
		
        protected virtual Agenda AddDefault(Agenda agenda)
        {
            agenda = this._rep.Add(agenda);
            return agenda;
        }

		protected virtual Agenda UpdateDefault(Agenda agenda)
        {
            agenda = this._rep.Update(agenda);
            return agenda;
        }
				
		public virtual async Task<Agenda> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Agenda.AgendaFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Agenda> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Agenda.AgendaFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
