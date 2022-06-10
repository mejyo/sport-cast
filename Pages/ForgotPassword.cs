using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using sport_cast.Global;
using System.Threading;

namespace sport_cast.Pages
{
    class ForgotPassword
    {
        public ForgotPassword()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Element for forgot password link
        [FindsBy(How = How.CssSelector, Using = "#email-link")]
        private IWebElement ForgotPasswordLink { get; set; }

        //Element for forgot password heading message
        [FindsBy(How = How.CssSelector, Using = "h4[class='forgot-password-text']")]
        private IWebElement ForgotPasswordHeading { get; set; }

        //Element for user name on forgot page
        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > form:nth-child(1) > div:nth-child(2) > div:nth-child(3) > input:nth-child(2)")]
        private IWebElement UserNameFromForgotPassword { get; set; }

        //Element for email link
        [FindsBy(How = How.XPath, Using = "(//input[@id='login-btn'])[2]")]
        private IWebElement EmailLink { get; set; }

        //Element for Back to Login link
        [FindsBy(How = How.CssSelector, Using = "#back-log")]
        private IWebElement BackToLogin { get; set; }

        //Element for thank you message
        [FindsBy(How = How.CssSelector, Using = "div[id='forgot-password-response'] span:nth-child(1)")]
        private IWebElement ThankYouMessage { get; set; }

        //Element for user name message
        [FindsBy(How = How.CssSelector, Using = "#response-text-1")]
        private IWebElement UserNameMessage { get; set; }

        //Element for reset password message
        [FindsBy(How = How.CssSelector, Using = "#response-text-2")]
        private IWebElement ResetPasswordMessage { get; set; }

        #endregion

        internal void TextValidationSteps()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.CssSelector("#email-link"), 10);
            ForgotPasswordLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Enter your Username - If you do not know your username please contact your administrator", ForgotPasswordHeading.Text);
            Assert.AreEqual("Username", UserNameFromForgotPassword.GetAttribute("placeholder"));
            Assert.AreEqual("Email Link", EmailLink.GetAttribute("value"));
            Assert.AreEqual("Back to login", BackToLogin.GetAttribute("value"));
            Assert.Pass("Element texts on Forgot Password page have been verified!");
        }
        internal void ResetPasswordSuccessMessageValidationSteps()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.CssSelector("#email-link"), 10);
            ForgotPasswordLink.Click();
            Thread.Sleep(2000);
            UserNameFromForgotPassword.SendKeys("abc");
            GlobalDefinitions.ImplicitWaitTime(20);
            EmailLink.Click();
            Thread.Sleep(2000);
            GlobalDefinitions.ImplicitWaitTime(20);
            Assert.AreEqual("Thank you,abc Please check your email to reset your password.", ThankYouMessage.Text + UserNameMessage.Text + " " + ResetPasswordMessage.Text);
            Assert.Pass("Reset Password Success Message has been verified!");
        }
    }
}