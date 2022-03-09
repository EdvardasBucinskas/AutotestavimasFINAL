using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutotestavimasFINAL.Page
{
    public class MainPage : BasePage
    {
        
        public MainPage(ChromeDriver driver) : base(driver)
        {

        }
        public IWebElement EmailTab => Driver.FindElement(By.CssSelector("input[type='email']"));
        public IWebElement PasswordTab => Driver.FindElement(By.CssSelector("input[type='password']"));
        public IWebElement SubmitLoginButton => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement ConfirmLogin => Driver.FindElement(By.CssSelector("a[href='http://www.draugas.lt/profilis.cfm']"));

        public IWebElement Logout => Driver.FindElement(By.CssSelector("a[class='__logout']"));
        public IWebElement Showlogout => Driver.FindElement(By.CssSelector("svg[class='arrow-d2']"));

        public By FailedLoginMessageSelector = By.CssSelector("div[class='app-login-msg __statusMessage __actAs-__logIn-ErrorHolder alert-danger']");

        public IWebElement FailedLoginMessage => Driver.FindElement(FailedLoginMessageSelector);

        public IWebElement RegistrationMain => Driver.FindElement(By.CssSelector("a[href='https://pazintys.draugas.lt/prisijungti.cfm']"));

        public IWebElement RegistrationByEmail => Driver.FindElement(By.CssSelector("div[class='mygtukas mygtukas26 __btn']"));

        public IWebElement RegName => Driver.FindElement(By.CssSelector("input[class='laukeliai2']"));

        public IWebElement Sex => Driver.FindElement(By.Id("registracija_lytis"));
        public SelectElement RegSex => new SelectElement(Sex);

        public IWebElement Year => Driver.FindElement(By.Id("registracija_metai"));

        public SelectElement RegYear => new SelectElement(Year);

        public IWebElement RegMonth => Driver.FindElement(By.Id("registracija_menuo"));

        public SelectElement Month => new SelectElement(RegMonth);

        public IWebElement RegDay => Driver.FindElement(By.Id("registracija_diena"));

        public SelectElement Day => new SelectElement(RegDay);

        public IWebElement RegEmail => Driver.FindElement(By.Id("registracija_email"));

        public IWebElement RegPass => Driver.FindElement(By.Id("registracija_slaptazodis"));

        public IWebElement RegNextButton => Driver.FindElement(By.Id("istoti_toliau"));

        public IWebElement EmailAlert => Driver.FindElement(By.CssSelector("P[class='dr-text-red']"));

        public IWebElement CheckBoxWomen => Driver.FindElement(By.Id("lytis_moterys"));

        public IWebElement AgeFrom => Driver.FindElement(By.CssSelector("Select[name='amzius']"));

        public SelectElement AgeFr => new SelectElement(AgeFrom);

        public IWebElement AgeTo => Driver.FindElement(By.CssSelector("Select[name='amzius2']"));

        public SelectElement AgeT => new SelectElement(AgeTo);

        public IWebElement SubmitSearch => Driver.FindElement(By.Id("spaieska_ieskoti"));

        public By PicturesSelector = By.CssSelector("img[class='bu-userPhoto']");
















        //  public IWebElement RegNewEmail => Driver.FindElement(By.CssSelector("input[class="laukeliai2"]"));

        // public IWebElement RegNewPassword 

        // public IWebElement

        // public IWebElement













    }
}

