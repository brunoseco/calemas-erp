using Calemas.Erp.Sso.Api.Model;
using Calemas.Erp.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Sso.Api
{
    public class UserServices
    {

        private IColaboradorRepository _rep;

        public UserServices(IColaboradorRepository rep)
        {
            this._rep = rep;
        }

        public async Task<User> Auth(string userName, string password)
        {
            var _userName = userName.ToLower();
            var _password = password.ToLower();

            var colaborador = await this._rep.SingleOrDefaultAsync(this._rep.GetAll()
                .Where(_ => _.Account == _userName)
                .Where(_ => _.Password == _password));

            var user = new User();

            if (colaborador.IsNotNull())
            {
                user.Claims = Config.ClaimsForColaborador(colaborador.ColaboradorId.ToString(), colaborador.Pessoa.Nome, colaborador.Pessoa.Email);
                user.SubjectId = colaborador.ColaboradorId.ToString();
                user.Username = colaborador.Pessoa.Nome;

                return user;
            }

            var userAdmin = Config.GetUsers()
                .Where(_ => _.Username.ToLower() == _userName)
                .Where(_ => _.Password.ToLower() == _password)
                .SingleOrDefault();

            if (userAdmin.IsNotNull())
                return userAdmin;

            return null;
        }

    }
}
