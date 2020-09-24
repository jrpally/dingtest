using OpenQA.Selenium;

namespace DingJobTests.StepsDefinitions
{
    internal class WebElement
    {
        private IWebElement webElement;

        public WebElement(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public bool IsVisible => this.webElement.Displayed;

        public string Text => this.webElement.Text;
    }
}