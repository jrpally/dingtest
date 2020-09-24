using NUnit.Framework;
using OpenQA.Selenium;
using System;
using DingJobTests.Core.Pages;
using TechTalk.SpecFlow;

namespace DingJobTests.StepsDefinitions
{
    [Binding]
    public class DingTestSteps
    {
        private IWebDriver driver = null;
        private PayPalLoginPage payPalLoginPage = null;

        [Given(@"The a browser like '(.*)' Go to the PayPal Signin Page")]
        public void GivenTheABrowserLikeGoToThePayPalSigninPage(string browser)
        {
            this.driver = DriverFactory.CreateBrowser(browser);
            this.payPalLoginPage = new PayPalLoginPage(driver);
            this.payPalLoginPage.GoToHomePage();
        }

        [Given(@"Write the username as (.*)")]
        public void GivenWriteTheUsernameAs(string username)
        {
            this.payPalLoginPage.Username = username;
        }

        [When(@"I click next button")]
        public void WhenIClickNextButton()
        {
            this.payPalLoginPage = this.payPalLoginPage.ClickNextButton();
        }

        [When(@"Write the password as (.*)")]
        public void WhenWriteThePasswordAs(string password)
        {
            this.payPalLoginPage.Password = password;
        }

        [When(@"I click login")]
        public void WhenIClickLogin()
        {
            this.payPalLoginPage.ClickLoginButton();
        }

        [Then(@"Then the (.*) is displayed")]
        public void ThenThenTheIsDisplayed(string message)
        {            
            string password = this.payPalLoginPage.Password;
            Assert.IsTrue(string.IsNullOrEmpty(password));
            
            WebElement passwordError = this.payPalLoginPage.ErrorMessagePassword;
            Assert.AreEqual(passwordError.Text, message);
        }

        [Then(@"The Bad Password Error (.*) is displayed")]
        public void ThenTheBadPasswordErrorIsDisplayed(string message)
        {
            string password = this.payPalLoginPage.Password;
            Assert.IsTrue(string.IsNullOrEmpty(password));

            WebElement informationNotCorrect = this.payPalLoginPage.InformationNotCorrect;
            Assert.AreEqual(informationNotCorrect.Text, message);
        }

        [Then(@"The Bad Number Error (.*) is displayed")]
        public void ThenTheBadNumberErrorIsDisplayed(string message)
        {
            WebElement numberNotConfirmedMsg = this.payPalLoginPage.NumberNotConfirmedMessage;
            Assert.AreEqual(numberNotConfirmedMsg.Text, message);
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            this.driver.Close();
        }


    }
}
