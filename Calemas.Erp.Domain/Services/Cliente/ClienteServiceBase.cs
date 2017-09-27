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
    public class ClienteServiceBase : ServiceBase<Cliente>
    {
        protected readonly IClienteRepository _rep;

        public ClienteServiceBase(IClienteRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Cliente> GetOne(ClienteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Cliente>> GetByFilters(ClienteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Cliente>> GetByFiltersPaging(ClienteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Cliente cliente)
        {
            this._rep.Remove(cliente);
        }

        public virtual Summary GetSummary(PaginateResult<Cliente> paginateResult)
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

        public override async Task<Cliente> Save(Cliente cliente, bool questionToContinue = false)
        {
			var clienteOld = await this.GetOne(new ClienteFilter { ClienteId = cliente.ClienteId });
			var clienteOrchestrated = await this.DomainOrchestration(cliente, clienteOld);

            if (questionToContinue)
            {
                if (base.Continue(clienteOrchestrated, clienteOld) == false)
                    return clienteOrchestrated;
            }

            return this.SaveWithValidation(clienteOrchestrated, clienteOld);
        }

        public override async Task<Cliente> SavePartial(Cliente cliente, bool questionToContinue = false)
        {
            var clienteOld = await this.GetOne(new ClienteFilter { ClienteId = cliente.ClienteId });
			var clienteOrchestrated = await this.DomainOrchestration(cliente, clienteOld);

            if (questionToContinue)
            {
                if (base.Continue(clienteOrchestrated, clienteOld) == false)
                    return clienteOrchestrated;
            }

            return SaveWithOutValidation(clienteOrchestrated, clienteOld);
        }

        protected override Cliente SaveWithOutValidation(Cliente cliente, Cliente clienteOld)
        {
            cliente = this.SaveDefault(cliente, clienteOld);

			if (base._validationResult.IsNotNull() && !base._validationResult.IsValid)
				return cliente;

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "cliente Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return cliente;

        }

		protected override Cliente SaveWithValidation(Cliente cliente, Cliente clienteOld)
        {
            if (!this.DataAnnotationIsValid())
                return cliente;

            if (!cliente.IsValid())
            {
                base._validationResult = cliente.GetDomainValidation();
                return cliente;
            }

            this.Specifications(cliente);

            if (!base._validationResult.IsValid)
                return cliente;
            
            cliente = this.SaveDefault(cliente, clienteOld);
            base._validationResult.Message = "Cliente cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return cliente;
        }

		protected virtual void Specifications(Cliente cliente)
        {
            base._validationResult  = new ClienteAptoParaCadastroValidation(this._rep).Validate(cliente);
			base._validationWarning  = new ClienteAptoParaCadastroWarning(this._rep).Validate(cliente);
        }

        protected virtual Cliente SaveDefault(Cliente cliente, Cliente clienteOld)
        {
			cliente = this.AuditDefault(cliente, clienteOld);

            var isNew = clienteOld.IsNull();			
            if (isNew)
                cliente = this.AddDefault(cliente);
            else
				cliente = this.UpdateDefault(cliente, clienteOld);

            return cliente;
        }
		
        protected virtual Cliente AddDefault(Cliente cliente)
        {
            cliente = this._rep.Add(cliente);
            return cliente;
        }

		protected virtual Cliente UpdateDefault(Cliente cliente, Cliente clienteOld)
        {
            cliente = this._rep.Update(cliente);
            return cliente;
        }
				
		public virtual async Task<Cliente> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Cliente.ClienteFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Cliente> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Cliente.ClienteFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
