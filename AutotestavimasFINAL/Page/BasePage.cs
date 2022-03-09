using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace AutotestavimasFINAL.Page
{
    public class BasePage
    {
        protected ChromeDriver Driver;

        public BasePage(ChromeDriver driver)
        {
            this.Driver = driver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }




}
