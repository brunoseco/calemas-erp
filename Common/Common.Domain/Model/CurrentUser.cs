using Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{

    public class CurrentUser
    {
 
        private string _token;
     
        public void Init(string token, Dictionary<string, object> claims)
        {
            this._token = token;
            this._claims = claims;
        }

        public int UserId { get; set; }

        public object UserInfo { get; set; }

        private Dictionary<string, object> _claims;

        public string GetToken()
        {
            return this._token;
        }

        public Dictionary<string, object> GetClaims()
        {
            return this._claims;
        }

        public bool IsSubscriber()
        {
            return this._claims
                .Where(_ => _.Key.ToLower() == "role")
                .Where(_ => _.Value.ToString() == "subscriber").IsAny();
        }
        public TS GetSubjectId<TS>()
        {
            if (this.IsSubscriber())
            {
                var subjectId = this._claims
                    .Where(_ => _.Key.ToLower() == "sub")
                    .SingleOrDefault()
                    .Value;

                return (TS)Convert.ChangeType(subjectId, typeof(TS));
            }
            return default(TS);
        }

        public T GetUserInfo<T>() where T : class
        {
            var result = (T)UserInfo as T;
            return result;
        }

    }
}
