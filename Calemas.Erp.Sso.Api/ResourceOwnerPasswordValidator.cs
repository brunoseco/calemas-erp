using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Calemas.Erp.Sso.Api
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = new TestUser();

            var userAdmin = Config.GetUsers()
                .Where(_ => _.Username == context.UserName)
                .Where(_ => _.Password == context.Password)
                .SingleOrDefault();

            if (userAdmin.IsNotNull())
                user = userAdmin;

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
    }
}
