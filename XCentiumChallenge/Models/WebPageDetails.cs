using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace XCentiumChallenge.Models
{
    public class WebPageDetails
    {
        public List<string> ImageSrcList { get; set; }
        public List<KeyValuePair<string,int>> WordList { get; set; }
        public int CountOfWords { get; set; }


    }


}