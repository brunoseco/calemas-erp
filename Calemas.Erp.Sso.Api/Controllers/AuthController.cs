using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.API;
using IdentityModel.Client;
using Calemas.Erp.Sso.Api.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Common.Domain.Base;
using Common.Domain;

namespace Calemas.Erp.Sso.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ILogger _logger;
        private IOptions<ConfigSettingsBase> _configSettingsBase;
        public AuthController(ILoggerFactory logger, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            this._logger = logger.CreateLogger<AuthController>();
            this._configSettingsBase = configSettingsBase;
            this._logger.LogInformation("AccountController init success");
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
                return result.ReturnCustomException(new Exception(tokenResponse.Error), "Calemas.Erp.Sso.Api - Account");

            return result.ReturnCustomResponse(tokenResponse);
        }
        

    }
}
