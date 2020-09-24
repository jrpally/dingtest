using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DingJobTests.Core.Pages
{
    public abstract class BasePage
    {
        private const int Timeout = 10;
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void Navigate(string url)
        {
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Timeout);
            this.driver.Navigate().GoToUrl(url);
            WebDriverWait waitForDocumentReady = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout));
            waitForDocumentReady.Until((driver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected IWebElement FindElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout));
            IWebElement element = wait
                .Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));

            return element;
        }
    }
}