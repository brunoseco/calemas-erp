using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.API;
using IdentityModel.Client;
using Cna.Portal.Franqueador.Sso.Api.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Common.Domain.Base;
using Common.Domain;

namespace Cna.Portal.Franqueador.Sso.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private ILogger _logger;
        public AccountController(ILoggerFactory logger, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            this._logger = logger.CreateLogger<AccountController>();
            this._logger.LogInformation("AccountController init success");
        }
        
        [HttpPost]
        public async void Post([FromBody]AccountCredencial accountCredencial)
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
        }
    }
}
