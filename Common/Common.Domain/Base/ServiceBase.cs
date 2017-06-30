using Common.Domain.Interfaces;
using Common.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public abstract class ServiceBase<T> where T : class
    {

        protected readonly CacheHelper _cacheHelper;

        protected ValidationSpecificationResult _validationResult;

        protected ConfirmEspecificationResult _validationConfirm;

        protected WarningSpecificationResult _validationWarning;

        protected CurrentUser _user;


        public ServiceBase(ICache cache)
        {
            this._cacheHelper = new CacheHelper(cache);
        }

        protected virtual T AuditDefault(DomainBaseWithUserCreate entity, DomainBaseWithUserCreate entityOld)
        {
            var isNew = entityOld.IsNull();
            if (isNew)
                entity.SetUserCreate(this._user.GetSubjectId<int>());
            else
            {
                entity.SetUserCreate(entityOld.UserCreateId, entityOld.UserCreateDate);
                entity.SetUserUpdate(this._user.GetSubjectId<int>());
            }

            return entity as T;
        }

        public virtual async Task<IEnumerable<T>> Save(IEnumerable<T> entitys)
        {
            var savedAll = new List<T>();
            foreach (var item in entitys)
            {
                var saved = await this.Save(item);
                savedAll.Add(saved);
            }
            return savedAll;

        }

        public abstract Task<T> Save(T entity, bool questionToContinue = true);

        public abstract Task<T> SavePartial(T entity, bool questionToContinue = true);

        protected abstract T SaveWithValidation(T entity, T oldEntity);

        protected abstract T SaveWithOutValidation(T entity, T oldEntity);

        protected virtual bool Continue(T entity, T oldEntity)
        {
            return true;
        }

        protected virtual bool DataAnnotationIsValid()
        {
            return this._validationResult.IsNotNull() && this._validationResult.IsValid;
        }

        public virtual void SetTagNameCache(string tagNameCache)
        {
            this._cacheHelper.SetTagNameCache(tagNameCache);
        }

        public virtual string GetTagNameCache()
        {
            return this._cacheHelper.GetTagNameCache();
        }

        public virtual void AddDomainValidation(string newError)
        {
            var newErrors = new List<string> {
                newError
            };
            this.AddDomainValidation(newErrors);
        }
        public virtual void AddDomainValidation(IEnumerable<string> newErrors)
        {
            var _erros = new List<string>();
            if (this._validationResult.IsNull())
                this._validationResult = new ValidationSpecificationResult();


            if (this._validationResult.Errors.IsAny())
                _erros.AddRange(this._validationResult.Errors);

            if (newErrors.IsAny())
            {
                _erros.AddRange(newErrors);
                this._validationResult.IsValid = false;
            }

            this._validationResult.Errors = _erros;
        }


    }
}
