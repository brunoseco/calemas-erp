using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public class ConfirmEspecificationResult
    {
        public ConfirmEspecificationResult()
        {
            this.IsValid = true;
        }

        public IEnumerable<string> Confirms { get; set; }

        public bool IsValid { get; set; }

        public string Message { get; set; }
    }

}
