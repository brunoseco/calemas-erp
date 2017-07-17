using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public class DomainBase
    {
        protected ValidationSpecificationResult _validationResult;

        protected ConfirmEspecificationResult _validationConfirm;

        protected WarningSpecificationResult _validationWarning;

        [NotMapped]
        public string AttributeBehavior { get; protected set; }

        public void SetAttributeBehavior(string value) {

            this.AttributeBehavior = value;
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }
        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }
        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

    }
}
