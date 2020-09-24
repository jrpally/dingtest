using System;
using OpenQA.Selenium;

namespace DingJobTests.Core.Lib
{
    internal class WebElement
    {
        private IWebElement webElement;

        public WebElement(IWebElement webElement)
        {
            this.webElement = webElement ?? throw new ArgumentNullException(nameof(webElement));
        }

        public bool IsVisible => this.webElement.Displayed;

        public string Text => this.webElement.Text;
    }
}