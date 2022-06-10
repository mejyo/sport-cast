using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using sport_cast.Global;
using System.Threading;

namespace sport_cast
{
    class Login
    {
            public Login()
            {
                PageFactory.InitElements(GlobalDefinitions.driver, this);
            }

            #region  Initialize Web Elements 
   
            //Element for UserName Field
            [FindsBy(How = How.Id, Using = "login-username")]
            private IWebElement UserNameLogin { get; set; }

            //Element for UserName Error message
            [FindsBy(How = How.CssSelector, Using = "#login-username-error")]
            private IWebElement UsernameLoginError { get; set; }

            //Element for Password field
            [FindsBy(How = How.Id, Using = "login-password")]
            private IWebElement Password { get; set; }

            //Element for Password error message
            [FindsBy(How = How.CssSelector, Using = "#login-password-error")]
            private IWebElement PasswordError { get; set; }

            //Element for login button
            [FindsBy(How = How.Id, Using = "login-btn")]
            private IWebElement LoginButton { get; set; }

            //Element for forgot password link
            [FindsBy(How = How.CssSelector, Using = "#email-link")]
            private IWebElement ForgotPasswordLink { get; set; }

            //Element for RememberMe
            [FindsBy(How = How.CssSelector, Using = "label[for='RememberMe']")]
            private IWebElement RememberMe { get; set; }

            //Element for Invalid Login Attempt message
            [FindsBy(How = How.CssSelector, Using = "div[id='validation-summary'] ul li")]
            private IWebElement InValidLoginAttempt { get; set; }

        #endregion

        internal void ErrorMessagesAndTextValidationSteps()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.TagName("img"), 10);
            Assert.AreEqual("Username", UserNameLogin.GetAttribute("placeholder"));
            Assert.AreEqual("Password", Password.GetAttribute("placeholder"));
            Assert.AreEqual("Remember me", RememberMe.Text);
            Assert.AreEqual("Forgot Password?", ForgotPasswordLink.GetAttribute("value"));
            Assert.AreEqual("Login", LoginButton.GetAttribute("value"));
            LoginButton.Click();
            Assert.AreEqual("The User Name field is required.", UsernameLoginError.Text);
            Assert.AreEqual("The Password field is required.", PasswordError.Text);
            Assert.Pass("Error messages and element texts have been verified!");
        }

        internal void LoginWithInvaildDataSteps()
            {
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.TagName("img"), 10);
                UserNameLogin.SendKeys("abc");
                Password.SendKeys("abc");
                GlobalDefinitions.ImplicitWaitTime(20);
                LoginButton.Click();
                Thread.Sleep(2000);
                Assert.AreEqual("Invalid login attempt.", InValidLoginAttempt.Text);
                Assert.Pass("Login with invalid data error message has been verified!");
            }

    }
    }
