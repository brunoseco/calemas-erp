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
    public class EnderecoServiceBase : ServiceBase<Endereco>
    {
        protected readonly IEnderecoRepository _rep;

        public EnderecoServiceBase(IEnderecoRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Endereco> GetOne(EnderecoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Endereco>> GetByFilters(EnderecoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Endereco>> GetByFiltersPaging(EnderecoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Endereco endereco)
        {
            this._rep.Remove(endereco);
        }

        public virtual Summary GetSummary(PaginateResult<Endereco> paginateResult)
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

        public override async Task<Endereco> Save(Endereco endereco, bool questionToContinue = false)
        {
			var enderecoOld = await this.GetOne(new EnderecoFilter { EnderecoId = endereco.EnderecoId });
			var enderecoOrchestrated = await this.DomainOrchestration(endereco, enderecoOld);

            if (questionToContinue)
            {
                if (base.Continue(enderecoOrchestrated, enderecoOld) == false)
                    return enderecoOrchestrated;
            }

            return this.SaveWithValidation(enderecoOrchestrated, enderecoOld);
        }

        public override async Task<Endereco> SavePartial(Endereco endereco, bool questionToContinue = false)
        {
            var enderecoOld = await this.GetOne(new EnderecoFilter { EnderecoId = endereco.EnderecoId });
			var enderecoOrchestrated = await this.DomainOrchestration(endereco, enderecoOld);

            if (questionToContinue)
            {
                if (base.Continue(enderecoOrchestrated, enderecoOld) == false)
                    return enderecoOrchestrated;
            }

            return SaveWithOutValidation(enderecoOrchestrated, enderecoOld);
        }

        protected override Endereco SaveWithOutValidation(Endereco endereco, Endereco enderecoOld)
        {
            endereco = this.SaveDefault(endereco, enderecoOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return endereco;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "endereco Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return endereco;

        }

		protected override Endereco SaveWithValidation(Endereco endereco, Endereco enderecoOld)
        {
            if (!this.DataAnnotationIsValid())
                return endereco;

            if (!endereco.IsValid())
            {
                base._validationResult = endereco.GetDomainValidation();
                return endereco;
            }

            this.Specifications(endereco);

            if (!base._validationResult.IsValid)
                return endereco;
            
            endereco = this.SaveDefault(endereco, enderecoOld);
            base._validationResult.Message = "Endereco cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return endereco;
        }

		protected virtual void Specifications(Endereco endereco)
        {
            base._validationResult  = new EnderecoAptoParaCadastroValidation(this._rep).Validate(endereco);
			base._validationWarning  = new EnderecoAptoParaCadastroWarning(this._rep).Validate(endereco);
        }

        protected virtual Endereco SaveDefault(Endereco endereco, Endereco enderecoOld)
        {
			endereco = this.AuditDefault(endereco, enderecoOld);

            var isNew = enderecoOld.IsNull();			
            if (isNew)
                endereco = this.AddDefault(endereco);
            else
				endereco = this.UpdateDefault(endereco);

            return endereco;
        }
		
        protected virtual Endereco AddDefault(Endereco endereco)
        {
            endereco = this._rep.Add(endereco);
            return endereco;
        }

		protected virtual Endereco UpdateDefault(Endereco endereco)
        {
            endereco = this._rep.Update(endereco);
            return endereco;
        }
				
		public virtual async Task<Endereco> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Endereco.EnderecoFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Endereco> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Endereco.EnderecoFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
