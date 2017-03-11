using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.PageObjects
{
    class Website
    {
        private readonly IWebDriver driver;
        private readonly string url = @"http://labs.abeautifulsite.net/archived/phpFileTree/demo/demo_classic.php";

        public Website(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Url = url;
        }

        public Website ClickOnDocuments()
        {
            var root = driver.FindElements(By.TagName("a")).Where(e => e.Text.Contains("documents")).First();
            root.Click();
            return this;
        }

        public Website ValidateExcelDocuments(string [] docs)
        {
            var root = driver.FindElements(By.TagName("a")).Where(e => e.Text.Contains("excel docs")).First();
            root.Click();
            foreach (var doc in docs)
            {
                driver.FindElements(By.TagName("a")).Where(e => e.Text.Contains(doc)).First().Click();
                Task.Delay(3000).Wait();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            return this;
        }

        public Website ValidateWordDocuments(string[] docs)
        {
            var root = driver.FindElements(By.TagName("a")).Where(e => e.Text.Contains("word documents")).First();
            root.Click();
            foreach (var doc in docs)
            {
                var traverse = doc.Split(new[] { "->" }, StringSplitOptions.None);
                var counter = 1;
                foreach(var node in traverse)
                {
                    driver.FindElements(By.TagName("a")).Where(e => e.Text.Contains(node)).First().Click();
                    if (counter >= traverse.Count())
                    {
                        Task.Delay(3000).Wait();
                        IAlert alert = driver.SwitchTo().Alert();
                        alert.Accept();
                    }
                    counter++;
                }
            }
            return this;
        }
    }
}
