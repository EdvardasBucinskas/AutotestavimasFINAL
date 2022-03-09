using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutotestavimasFINAL.Page;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutotestavimasFINAL.Test
{
    public class Tests
    {
        MainPage Page;
        ChromeDriver Driver;
        
        [OneTimeSetUp]

        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Url = "https://www.draugas.lt/";
            Page = new MainPage(Driver);

        }

        [Test]
        [Order(1)]
        public void Successfullogin()
        {
            Page.EmailTab.SendKeys("edvardas.bucinskas@gmail.com");
            Page.PasswordTab.SendKeys("Andrina123*");
            Page.SubmitLoginButton.Click();
            var x = Driver.FindElements(By.CssSelector("a[href='http://www.draugas.lt/profilis.cfm']"));
            Assert.That(x.Count(), Is.AtLeast(1));
        }

        [Test]
        [Order(2)]
        public void SuccessfullLogout()
        {
            Page.Showlogout.Click();
            Page.Logout.Click();
            var x = Driver.FindElements(By.CssSelector("a[href='http://www.draugas.lt/profilis.cfm']"));
            Assert.That(x.Count(), Is.EqualTo(0));
        }

        [Test]
        [Order(3)]
        public void Unsuccessfulllogin()
        {
            Page.EmailTab.SendKeys("edvardasbucinskas@gmail.com");
            Page.PasswordTab.SendKeys("Andrina123");
            Page.SubmitLoginButton.Click();
            var y = Driver.FindElements(Page.FailedLoginMessageSelector);
            Assert.That(y.Count(), Is.EqualTo(1));
        }

        [Test]
        [Order(4)]

        public void ValidateEmailAdress()
        {
            Page.RegistrationMain.Click();
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[class='mygtukas mygtukas26 __btn']")));
            Thread.Sleep(3000); //Nes neveikia explicit wait
            Page.RegistrationByEmail.Click();
            Page.RegName.SendKeys("Edvardas");
            Page.RegSex.SelectByText("Vyras");
            Page.RegYear.SelectByValue("1990");
            Page.Month.SelectByValue("4"); // kodel cia taip? Page.Month o ne Page.Reg? 
            Page.Day.SelectByValue("6");
            Page.RegEmail.SendKeys("edvardas.bucinskas@gmail.com");
            Page.RegPass.SendKeys("Slaptazodis");
            Page.RegNextButton.Click();
            Assert.That(Page.EmailAlert.Displayed);
            
        }

        [Test]
        [Order(5)]
        public void SearchResults()
        {
            Driver.Url = "https://pazintys.draugas.lt/ngrupe.cfm";
            Page.CheckBoxWomen.Click();
            Page.AgeFr.SelectByValue("25");
            Page.AgeT.SelectByValue("26");
            Page.SubmitSearch.Click();
            var x = Driver.FindElements(Page.PicturesSelector);
            Assert.That(x.Count(), Is.AtLeast(10));
        }

        [Test]
        [Order(6)]

        public void FailingTest()
        {
            Assert.AreEqual(1, 11);
        }











        // Registracijos testas, registracija sekminga pop up (pranesimas)
        // 6 testas bus blank su aserto pagalba 1=0 parasysiu, kad nx
        // Page Object Pattern (google)
        // Generic < > 




        [OneTimeTearDown]
        public void TearDown()
        {

            Page.CloseBrowser();
        }

        [TearDown]
        public void SnapshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)

            {
                Driver.GetScreenshot().SaveAsFile("C:\\Users\\user\\Desktop\\TestasSC\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds() + ".png");
            }
        }
    }
}
