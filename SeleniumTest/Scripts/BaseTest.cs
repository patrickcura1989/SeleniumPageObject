using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTest.Scripts
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [TestInitialize]
        public void Setup()
        {
            this.Driver = new FirefoxDriver();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }
    }
}
