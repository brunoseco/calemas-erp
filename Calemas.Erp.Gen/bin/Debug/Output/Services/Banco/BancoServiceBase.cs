using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Validations;
using System.Collections.Generic;
using System.Linq;

namespace Calemas.Erp.Domain.Services
{
    public class BancoServiceBase : ServiceBase<Banco>
    {
        protected readonly IBancoRepository _rep;
        public BancoServiceBase(IBancoRepository rep, ICache cache)
            : base(cache)
        {
            this._rep = rep;
        }

        public virtual Banco GetOne(BancoFilter filters)
        {
            return this._rep.GetById(filters);
        }

        public virtual IEnumerable<Banco> GetByFilters(BancoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return queryBase.ToList();
        }

        public virtual PaginateResult<Banco> GetByFiltersPaging(BancoFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Banco banco)
        {
            this._rep.Remove(banco);
        }

        public virtual Summary GetSummary(PaginateResult<Banco> paginateResult)
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

        public virtual ValidationConfirm GetDomainConfirm(FilterBase filters = null)
        {
            return base._validationConfirm;
        }

        public virtual ValidationWarning GetDomainWarning(FilterBase filters = null)
        {
            return base._validationWarning;
        }

        public override Banco Save(Banco banco, bool questionToContinue = false)
        {
            var bancoOld = this.GetOne(new BancoFilter { BancoId = banco.BancoId });
            if (questionToContinue)
            {
                if (base.Continue(banco, bancoOld) == false)
                    return banco;
            }

            return this.SaveWithValidation(banco, bancoOld);
        }

        public override Banco SavePartial(Banco banco, bool questionToContinue = false)
        {
            var bancoOld = this.GetOne(new BancoFilter { BancoId = banco.BancoId });
            if (questionToContinue)
            {
                if (base.Continue(banco, bancoOld) == false)
                    return banco;
            }

            return SaveWithOutValidation(banco, bancoOld);
        }

        protected override Banco SaveWithOutValidation(Banco banco, Banco bancoOld)
        {
            banco = this.SaveDefault(banco, bancoOld);

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "banco Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return banco;

        }

        protected override Banco SaveWithValidation(Banco banco, Banco bancoOld)
        {
            if (!this.DataAnnotationIsValid())
                return banco;

            if (!banco.IsValid())
            {
                base._validationResult = banco.GetDomainValidation();
                return banco;
            }

            var validationResult = new BancoAptoParaCadastroValidation(this._rep).Validate(banco);
            base._validationResult = validationResult;

            if (!validationResult.IsValid)
            {
                return banco;
            }
            
            banco = this.SaveDefault(banco, bancoOld);
            validationResult.Message = "Banco cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return banco;
        }

        protected virtual Banco SaveDefault(Banco banco, Banco bancoOld)
        {
            var isNew = bancoOld.IsNull();
            if (isNew)
            {
				banco.SetUserCreate(1);
                banco = this._rep.Add(banco);
            }
            else
            {
				banco.SetUserCreate(bancoOld.UserCreateId, bancoOld.UserCreateDate);
				banco.SetUserUpdate(1);
                banco = this._rep.Update(banco);
            }

            return banco;
        }
    }
}
