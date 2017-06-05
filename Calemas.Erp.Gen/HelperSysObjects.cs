using Common.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calemas.Erp.Gen
{
    public class HelperSysObjects : HelperSysObjectsDDD
    {

        public HelperSysObjects(IEnumerable<Context> contexts)
            : base(contexts)
        {

        }

        protected override string MakePropertyName(string column, string className, int key)
        {
            if (key == 1)
            {
                if (column.ToLower() == "id")
                    return string.Format("{0}Id", className);

                if (column == "IdiomaId")
                    return column;

                if (column.ToString().ToLower().StartsWith("id"))
                {
                    var keyname = column.ToString().Replace("Id", "");
                    return string.Format("{0}Id", keyname);
                }
            }

            return column;
        }

    }
}
