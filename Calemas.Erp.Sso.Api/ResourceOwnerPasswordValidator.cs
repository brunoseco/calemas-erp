using IdentityServer4.Models;
using IdentityServer4.Validation;
using Calemas.Erp.Sso.Api.Model;
using Calemas.Erp.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Sso.Api
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IColaboradorRepository _rep;

        public ResourceOwnerPasswordValidator(IColaboradorRepository rep)
        {
            this._rep = rep;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {

                var userServices = new UserServices(this._rep);
                
                var user = await userServices.Auth(context.UserName, context.Password);

                if (user.IsNotNull())
                {
                    context.Result = new GrantValidationResult(
                        subject: user.SubjectId,
                        authenticationMethod: "custom",
                        claims: user.Claims);

                    return;
                }

                context.Result = new GrantValidationResult(
                            TokenRequestErrors.InvalidGrant,
                            "invalid custom credential");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
