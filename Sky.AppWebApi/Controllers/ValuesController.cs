using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sky.Models;
using XCode.Membership;

namespace Sky.AppWebApi.Controllers
{
    [MvcHandleError]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public JsonTips Login(string username, string password)
        {
            var ret = new JsonTips();
            var provider = ManageProvider.Provider;
            if (provider.Login(username, password) == null)
            {
                ret.Result = false;
                ret.Message = "提供的用户名或密码不正确。";
            }
            return ret;
        }
    }
}
