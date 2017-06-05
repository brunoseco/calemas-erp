using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public class ValidationError
    {
        public ValidationError(string message, string verifyBehavior = null)
        {
            this.message = message;
            this.verifyBehavior = verifyBehavior;
        }

        public string message { get; set; }
        public string verifyBehavior { get; set; }
    }
}
