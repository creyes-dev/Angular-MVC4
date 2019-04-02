using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JwtAuth.Web.API.Controllers
{
    public class ValoresController : ApiController
    {
        public string Get()
        {
            return "hola mundo";
        }
    }
}
