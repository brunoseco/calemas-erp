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
    public class AuthorizeController : Controller
    {
        private ILogger _logger;
        private IOptions<ConfigSettingsBase> _configSettingsBase;
        public AuthorizeController(ILoggerFactory logger, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            this._logger = logger.CreateLogger<AccountController>();
            this._configSettingsBase = configSettingsBase;
            this._logger.LogInformation("AuthorizeController init success");
        }        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountCredencial accountCredencial)
        {
            var result = new HttpResult<TokenResponse>(this._logger);

            var identityEndPoint = this._configSettingsBase.Value.AuthorityEndPoint;
            if (identityEndPoint.IsNull())
                throw new InvalidOperationException("Endpoint invalid");

            var disco = await DiscoveryClient.GetAsync(identityEndPoint);
            var tokenClient = new TokenClient(disco.TokenEndpoint, accountCredencial.ClientId, accountCredencial.ClientSecret);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(accountCredencial.User, accountCredencial.Password, accountCredencial.Scope);

            if (tokenResponse.IsError)
                return result.ReturnCustomException(new Exception(tokenResponse.Error), "Cna.Portal.Franqueador.Sso.Api - Account");

            return result.ReturnCustomResponse(tokenResponse);
        }
        

    }
}
