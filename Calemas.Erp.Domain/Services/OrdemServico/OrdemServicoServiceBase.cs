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
    public class OrdemServicoServiceBase : ServiceBase<OrdemServico>
    {
        protected readonly IOrdemServicoRepository _rep;
        public OrdemServicoServiceBase(IOrdemServicoRepository rep, ICache cache)
            : base(cache)
        {
            this._rep = rep;
        }

        public virtual async Task<OrdemServico> GetOne(OrdemServicoFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<OrdemServico>> GetByFilters(OrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<OrdemServico>> GetByFiltersPaging(OrdemServicoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(OrdemServico ordemservico)
        {
            this._rep.Remove(ordemservico);
        }

        public virtual Summary GetSummary(PaginateResult<OrdemServico> paginateResult)
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

        public override async Task<OrdemServico> Save(OrdemServico ordemservico, bool questionToContinue = false)
        {
            var ordemservicoOld = await this.GetOne(new OrdemServicoFilter { OrdemServicoId = ordemservico.OrdemServicoId });
            if (questionToContinue)
            {
                if (base.Continue(ordemservico, ordemservicoOld) == false)
                    return ordemservico;
            }

            return this.SaveWithValidation(ordemservico, ordemservicoOld);
        }

        public override async Task<OrdemServico> SavePartial(OrdemServico ordemservico, bool questionToContinue = false)
        {
            var ordemservicoOld = await this.GetOne(new OrdemServicoFilter { OrdemServicoId = ordemservico.OrdemServicoId });
            if (questionToContinue)
            {
                if (base.Continue(ordemservico, ordemservicoOld) == false)
                    return ordemservico;
            }

            return SaveWithOutValidation(ordemservico, ordemservicoOld);
        }

        protected override OrdemServico SaveWithOutValidation(OrdemServico ordemservico, OrdemServico ordemservicoOld)
        {
            ordemservico = this.SaveDefault(ordemservico, ordemservicoOld);

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "ordemservico Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return ordemservico;

        }

        protected override OrdemServico SaveWithValidation(OrdemServico ordemservico, OrdemServico ordemservicoOld)
        {
            if (!this.DataAnnotationIsValid())
                return ordemservico;

            if (!ordemservico.IsValid())
            {
                base._validationResult = ordemservico.GetDomainValidation();
                return ordemservico;
            }

            base._validationResult  = new OrdemServicoAptoParaCadastroValidation(this._rep).Validate(ordemservico);
			base._validationWarning  = new OrdemServicoAptoParaCadastroWarning(this._rep).Validate(ordemservico);

            if (!base._validationResult.IsValid)
            {
                return ordemservico;
            }
            
            ordemservico = this.SaveDefault(ordemservico, ordemservicoOld);
            base._validationResult.Message = "OrdemServico cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return ordemservico;
        }

        protected virtual OrdemServico SaveDefault(OrdemServico ordemservico, OrdemServico ordemservicoOld)
        {
            var isNew = ordemservicoOld.IsNull();
            if (isNew)
            {
				ordemservico.SetUserCreate(1);
                ordemservico = this._rep.Add(ordemservico);
            }
            else
            {
				ordemservico.SetUserCreate(ordemservicoOld.UserCreateId, ordemservicoOld.UserCreateDate);
				ordemservico.SetUserUpdate(1);
                ordemservico = this._rep.Update(ordemservico);
            }

            return ordemservico;
        }
    }
}
