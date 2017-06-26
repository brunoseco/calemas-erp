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
    public class PessoaServiceBase : ServiceBase<Pessoa>
    {
        protected readonly IPessoaRepository _rep;
		protected readonly CurrentUser _user;

        public PessoaServiceBase(IPessoaRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Pessoa> GetOne(PessoaFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Pessoa>> GetByFilters(PessoaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Pessoa>> GetByFiltersPaging(PessoaFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Pessoa pessoa)
        {
            this._rep.Remove(pessoa);
        }

        public virtual Summary GetSummary(PaginateResult<Pessoa> paginateResult)
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

        public override async Task<Pessoa> Save(Pessoa pessoa, bool questionToContinue = false)
        {
            var pessoaOld = await this.GetOne(new PessoaFilter { PessoaId = pessoa.PessoaId });
            if (questionToContinue)
            {
                if (base.Continue(pessoa, pessoaOld) == false)
                    return pessoa;
            }

            return this.SaveWithValidation(pessoa, pessoaOld);
        }

        public override async Task<Pessoa> SavePartial(Pessoa pessoa, bool questionToContinue = false)
        {
            var pessoaOld = await this.GetOne(new PessoaFilter { PessoaId = pessoa.PessoaId });
            if (questionToContinue)
            {
                if (base.Continue(pessoa, pessoaOld) == false)
                    return pessoa;
            }

            return SaveWithOutValidation(pessoa, pessoaOld);
        }

        protected override Pessoa SaveWithOutValidation(Pessoa pessoa, Pessoa pessoaOld)
        {
            pessoa = this.SaveDefault(pessoa, pessoaOld);

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "pessoa Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return pessoa;

        }

		protected override Pessoa SaveWithValidation(Pessoa pessoa, Pessoa pessoaOld)
        {
            if (!this.DataAnnotationIsValid())
                return pessoa;

            if (!pessoa.IsValid())
            {
                base._validationResult = pessoa.GetDomainValidation();
                return pessoa;
            }

            this.Specifications(pessoa);

            if (!base._validationResult.IsValid)
            {
                return pessoa;
            }
            
            pessoa = this.SaveDefault(pessoa, pessoaOld);
            base._validationResult.Message = "Pessoa cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return pessoa;
        }

		protected virtual void Specifications(Pessoa pessoa)
        {
            base._validationResult  = new PessoaAptoParaCadastroValidation(this._rep).Validate(pessoa);
			base._validationWarning  = new PessoaAptoParaCadastroWarning(this._rep).Validate(pessoa);
        }

        public virtual Pessoa AuditDefault(Pessoa pessoa, Pessoa pessoaOld)
        {
            var isNew = pessoaOld.IsNull();
            if (isNew)
                pessoa.SetUserCreate(this._user.GetSubjectId<int>());
            else
            {
                pessoa.SetUserUpdate(this._user.GetSubjectId<int>());
                pessoa.SetUserCreate(pessoaOld.UserCreateId, pessoaOld.UserCreateDate);
            }

            return pessoa;
        }

        protected virtual Pessoa SaveDefault(Pessoa pessoa, Pessoa pessoaOld)
        {
            var isNew = pessoaOld.IsNull();
            if (isNew)
            {
				pessoa.SetUserCreate(this._user.GetSubjectId<int>());
                pessoa = this._rep.Add(pessoa);
            }
            else
            {
				pessoa.SetUserUpdate(this._user.GetSubjectId<int>());
				pessoa.SetUserCreate(pessoaOld.UserCreateId, pessoaOld.UserCreateDate);
                pessoa = this._rep.Update(pessoa);
            }

            return pessoa;
        }
    }
}
