using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JwtAuth.Web.API.Security;

namespace JwtAuth.Web.API.Controllers
{
    [Authorize]
    public class JwtTestController : ApiController
    {
        [Authorize]
        public string Get()
        {
            return ((PrincipalPersonalizado)User).Identity.Name;
        }

        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var message = request.Content.ReadAsStringAsync().Result;
            Trace.TraceInformation(message);

            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Authorize(Roles = "Administrator")]
        public void Delete(string id)
        {
            Trace.TraceInformation(id);
        }

    }
}
