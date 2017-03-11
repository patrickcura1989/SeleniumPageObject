using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTest.PageObjects;

namespace SeleniumTest.Scripts
{
    [TestClass]
    public class TestCase : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Website website = new Website(Driver);
            website
                .ClickOnDocuments()
                .ValidateExcelDocuments(new string[] { "accounting.xls",
                                                        "ar.xls" })
                .ValidateWordDocuments(new string[] { "do it yourselfs->using styles.doc",
                                                        "homework.doc"});
        }
    }
}
