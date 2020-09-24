using DingJobTests.StepsDefinitions;
using OpenQA.Selenium;

namespace DingJobTests.Core.Pages
{
    internal class PayPalLoginPage : BasePage
    {
        private const string Url = @"https://www.sandbox.paypal.com/uk/signin";
        //private readonly IWebDriver driver;
        private IWebElement NextButtonElement => FindElement(By.Id("btnNext"));
        private IWebElement UsernameTextBoxElement => FindElement(By.Id("email"));
        private IWebElement PasswordElement => FindElement(By.Id("password"));
        private IWebElement LoginButtonElement => FindElement(By.Id("btnLogin"));

        /// <summary>
        /// Sets Username Textfield
        /// </summary>
        public string Username
        {
            get => this.UsernameTextBoxElement.Text;
            set => this.UsernameTextBoxElement.SendKeys(value);
        }

        /// <summary>
        /// Set the password to the given page
        /// </summary>
        public string Password
        {
            get => this.PasswordElement.Text;
            set => this.PasswordElement.SendKeys(value);
        }

        public WebElement ErrorMessagePassword => new WebElement(FindElement(By.Id("passwordErrorMessage")));

        public WebElement InformationNotCorrect => new WebElement(FindElement(By.XPath("//*[@id='content']/div[1]/p")));

        public WebElement NumberNotConfirmedMessage => new WebElement(FindElement(By.XPath("//*[@id='content']/div[1]/p")));

        public PayPalLoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToHomePage()
        {
            this.Navigate(Url);
        }

        /// <summary>
        /// Click On Login button
        /// </summary>
        /// <returns>Same Page is expected</returns>
        public PayPalLoginPage ClickLoginButton()
        {
            this.LoginButtonElement.Click();

            return new PayPalLoginPage(this.driver);
        }

        /// <summary>
        /// Click Next Button should return same page
        /// </summary>
        /// <returns></returns>
        public PayPalLoginPage ClickNextButton()
        {
            this.NextButtonElement.Click();

            return new PayPalLoginPage(this.driver);
        }
    }
}