using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Validation
{
    public class ValidatorSpecification<T> : Dictionary<string, Rule<T>>
    {

        public ValidationSpecificationResult Validate(T entity)
        {
            var isValid = true;
            var erros = new List<string>();
            foreach (var item in this)
            {
                if (!item.Value.GetSpecification().IsSatisfiedBy(entity))
                {
                    isValid = false;
                    erros.Add(item.Value.GetMessage());
                }
            }

            return new ValidationSpecificationResult {

                Errors = erros,
                IsValid = isValid,
            };
        }

    }
}
