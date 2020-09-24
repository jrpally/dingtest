using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DingJobTests.Core.Lib
{
    public class DriverFactory
    {
        /// <summary>
        /// Create a Browser based on the parameter
        /// </summary>
        /// <param name="browser">Browser can be 'Chrome' for now</param>
        /// <returns>Webdriver for Browser</returns>
        public static IWebDriver CreateBrowser(string browser)
        {
            if (browser == null) throw new ArgumentNullException(nameof(browser));
            BrowserType browserType = (BrowserType)Enum.Parse(typeof(BrowserType),
                browser, true);

            if (browserType == BrowserType.Chrome)
            {
                return new ChromeDriver();
            }

            return new ChromeDriver();
        }
    }
}