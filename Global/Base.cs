
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using static sport_cast.Global.GlobalDefinitions;

namespace sport_cast.Global
{
    class Base
    {
        #region To access URLs
        public static string URL = "http://uat.sportcastlive.com/Administration/Account/Login?ReturnUrl=%2F";
        #endregion


        #region setup and tear down
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            NavigateUrl();
            ImplicitWaitTime(20);
        }

        [TearDown]
        public void TearDown()
        {

            GlobalDefinitions.driver.Close();

        }
        #endregion

    }
}