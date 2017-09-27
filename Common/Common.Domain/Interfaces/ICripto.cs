using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface ICripto
    {

        string Encrypt(string value, TypeCripto type);

        string Salt { get; }

    }
}
