using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCentiumChallenge.Controllers.api;
using XCentiumChallenge.Models;
using XCentiumChallenge.Helpers;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWordCount()
        {
            var testResults = GetWebpageDetails.fetch("https://www.whitsendcabin.com");
            Assert.AreEqual(138, testResults.CountOfWords);
        }
        [TestMethod]
        public void TestImgCount()
        {
            var testResults = GetWebpageDetails.fetch("https://www.whitsendcabin.com/activities/");
            Assert.AreEqual(1, testResults.ImageSrcList.Count);
        }
        [TestMethod]
        public void TestImgCount2()
        {
            var testResults = GetWebpageDetails.fetch("https://www.loc.gov/rr/print/list/listguid.html");
            Assert.AreEqual(45, testResults.ImageSrcList.Count);
        }
        [TestMethod]
        public void TestWordCount2()
        {
            var testResults = GetWebpageDetails.fetch("https://www.loc.gov/rr/print/list/listguid.html");
            Assert.AreEqual(749, testResults.CountOfWords);
        }

    }
}
