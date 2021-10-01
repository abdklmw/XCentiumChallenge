using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using HtmlAgilityPack;
using XCentiumChallenge.Models;

namespace XCentiumChallenge.Controllers.api
{
    public class LoadUrlController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public WebPageDetails Index(string url)
        {

            return Helpers.GetWebpageDetails.fetch(url);

        }

    }
}