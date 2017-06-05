using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public class ValidationConfirm
    {
        public string Message { get; set; }
        public IEnumerable<string> Confirms { get; set; }
        public string VerifyBehavior { get; set; }
    }
    
}
