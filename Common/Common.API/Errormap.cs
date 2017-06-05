using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.API
{
    public class ErrorMap
    {

        private Dictionary<string, string> _errorTraductions;

        public ErrorMap()
        {

            this._errorTraductions = new Dictionary<string, string>();
            this._errorTraductions.Add("delete statement conflicted", "Erro ao exluir item, este item contem dados relacionados à ele, antes de excluí-lo, será necessário excluir os dados relacionados.");

        }

        public Dictionary<string, string> GetAll() {
            return this._errorTraductions;
        }

    }
}
