using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public class ConfigSettingsBase
    {

        public bool DisabledCache { get; set; }

        public string AuthorityEndPoint { get; set; }

        public string ClientAuthorityEndPoint { get; set; }

        public string RedirectUris { get; set; }

        public string PostLogoutRedirectUris { get; set; }


    }
}
