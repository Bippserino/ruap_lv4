using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace lv4
{
    public class Tests
    {
        [TestFixture]
        public class AccountSettingsTest
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new FirefoxDriver();
                baseURL = "https://www.google.com/";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void TheAccountSettingsTest()
            {
                driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
                driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/a")).Click();
                driver.FindElement(By.Name("username")).Click();
                driver.FindElement(By.Name("username")).Clear();
                driver.FindElement(By.Name("username")).SendKeys("mirkosvemirko@gmail.com");
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys("mirkosvemirko123");
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/button")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/div/div/a[1]")).Click();
            }

            [Test]
            public void TheCookiePolicyTest()
            {
                driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
                driver.FindElement(By.XPath("/html/body/div[1]/div[9]/div/button")).Click();
                driver.FindElement(By.LinkText("Cookie policy")).Click();
            }

            [Test]
            public void TheLoginTest()
            {
                driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
                driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
                driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/a")).Click();
                driver.FindElement(By.Name("username")).Click();
                driver.FindElement(By.Name("username")).Clear();
                driver.FindElement(By.Name("username")).SendKeys("mirkosvemirko@gmail.com");
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys("mirkosvemirko123");
                driver.FindElement(By.CssSelector(".form-style")).Submit();
            }

            [Test]
            public void ThePrivacyLinkTest()
            {
                driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
                driver.FindElement(By.XPath("/html/body/div[1]/div[9]/div/button")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/footer/div[1]/nav/article[1]/a[3]")).Click();
            }

            [Test]
            public void TheRegisterTest()
            {
                driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
                driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/a[2]")).Click();
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).Clear();
                Random rnd = new Random();
                int num = rnd.Next();
                driver.FindElement(By.Name("email")).SendKeys("asdasd" + num.ToString() + "@gmail.com");
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys("asdfghjkl");
                driver.FindElement(By.Name("password-repeat")).Clear();
                driver.FindElement(By.Name("password-repeat")).SendKeys("asdfghjkl");
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys("Asdf");
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys("Jgl");
                driver.FindElement(By.Name("telephone")).Clear();
                driver.FindElement(By.Name("telephone")).SendKeys("+38569696969");
                driver.FindElement(By.XPath("//button[@name='']")).Click();
                driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
                driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
            }

            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }
}