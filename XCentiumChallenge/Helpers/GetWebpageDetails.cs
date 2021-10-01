using System;
using System.Collections.Generic;
using System.Linq;
using XCentiumChallenge.Models;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Web;

namespace XCentiumChallenge.Helpers
{
    public class GetWebpageDetails
    {
        public static WebPageDetails fetch(string url)
        {
            //RegEx to check for a valid URL
            var urlRegEx = new Regex(@"(https?):\/\/([\w-]+(\.[\\w-]+)*\.([a-z]+))(([\w.,@?^=%&amp;:\/~+#()!-]*)([\w@?^=%&amp;\/~+#()!-]))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //If url string does not contain a valid url, return an error.
            if (!urlRegEx.IsMatch(url))
            {
                return null;
            }

            //define a var to return eventually
            var retCollection = new WebPageDetails();

            //define an int to track total number of words

            //use html agility pack (hap) to fetch the page
            var web = new HtmlWeb();
            var doc = web.Load(url);

            //get a list of image src
            retCollection.ImageSrcList = new List<string>();
            retCollection.ImageSrcList = doc.DocumentNode.Descendants("img") //select only img components
                .Select(img => img.GetAttributeValue("src", null)) //get the src from the img components
                .Distinct() //unique images only
                .Where(src => !String.IsNullOrEmpty(src)) //let's not keep the empty or null values
                .ToList();

            //get content from page
            var content = doc.DocumentNode.InnerText;

            //RegEx used to remove non-letter characters (exceptions: whitespace and apostrophes)
            var goodChars = new Regex("[^-A-Za-z'\\s]");

            //decode any html encoded characters which may exist
            var htmlDecodedContent = HttpUtility.HtmlDecode(content);

            //remove non-letter from content so we can focus on the words. Leave apostrophes and whitespace
            var trimmedContent = goodChars.Replace(htmlDecodedContent, "").Trim(); //remove any leading or trailing whitespaces

            //load WordList with unique words while calculating number of occurences and keeping track of total number of words
            var wordList = trimmedContent.Split();
            var resultList = new SortedDictionary<string,int>();
            foreach (var word in wordList)
            {
                //remove leading or trailing apostrophes in case of quoting, remove leading or trailing hyphens, and make lowercase
                var trimmedWord = word.Trim((char)39).Trim((char)45).ToLower();
                if (string.IsNullOrWhiteSpace(trimmedWord)) continue;   //if this "word" is basically nothing, let's skip it.
                if (resultList != null && resultList.ContainsKey(trimmedWord)) //if this word has already been found...
                {
                    //increment by 1
                    resultList[trimmedWord] += 1;
                }
                else //if this word hasn't been found before...
                {
                    //start at 1
                    resultList.Add(trimmedWord, 1);
                }
                retCollection.CountOfWords += 1; //keep track of total number of words
            }

            //let's order the list by number of occurrences
            retCollection.WordList = new SortedDictionary<string, int>(resultList);

            return retCollection;
        }
    }
}