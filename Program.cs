using NUnit.Framework;
using sport_cast.Global;
using sport_cast.Pages;

namespace sport_cast
{
    public static class Program
    {
        [TestFixture]
        class User : Base
        {
            [Test, Order(1)]
            public void ErrorMessagesAndTextValidationOnLoginPage()
            {
                Login loginObj = new();
                loginObj.ErrorMessagesAndTextValidationSteps();
            }
            [Test, Order(2)]
            public void LoginWithInvaildData()
            {
                Login loginObj = new();
                loginObj.LoginWithInvaildDataSteps();
            }
            [Test, Order(3)]
            public void TextValidationOnForgotPasswordPage()
            {
                ForgotPassword ForgotPasswordObj = new();
                ForgotPasswordObj.TextValidationSteps();
            }
            [Test, Order(4)]
            public void ResetPasswordSuccessMessageValidation()
            {
                ForgotPassword ForgotPasswordObj = new();
                ForgotPasswordObj.ResetPasswordSuccessMessageValidationSteps();
            }


        }
    }
}