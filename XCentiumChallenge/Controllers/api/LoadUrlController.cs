using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XCentiumChallenge.Controllers.api
{
    public class LoadUrlController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index(string url)
        {
            var results = Helpers.GetWebpageDetails.fetch(url);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(Helpers.GetWebpageDetails.fetch(url));

        }

    }
}
