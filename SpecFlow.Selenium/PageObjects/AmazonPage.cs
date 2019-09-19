using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace SpecFlow.Selenium.PageObjects
{
    public class AmazonPage : PageObject
    {
        private readonly IWebDriver _driver;
        private string _url = "https://www.amazon.com/";
        private int value;

        //Init driver
        public AmazonPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            
        }

        public static void WaitForElement(IWebDriver driver, IWebElement element, int timeout)
        {
            //new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(element));
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver => {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }

        // Navigate to Amazon Homepage
        public void Navigate()
        {
            base.Navigate(_url);
        }

        public void ChangeZip()
        {
            Zipchange.Click();
            WaitForElement(_driver, Zipcodefield, 30);
            Zipcodefield.SendKeys("10001");
            //I want to be clear, I dislike using Sleep, but for some reason DotNet wanted to click instantly and my wait ExpectedConditions.ElementToBeClickable(element) was not stopping it because the element was already there.
            Thread.Sleep(1500);
            ZipConfirm.Click();
            //I want to be clear, I dislike using Sleep, but for some reason DotNet wanted to click instantly and my wait ExpectedConditions.ElementToBeClickable(element) was not stopping it because the element was already there.
            Thread.Sleep(2500);
            Actions Builder = new Actions(_driver);
            Builder.SendKeys(Keys.Enter);
        }
        //Search for a product
        public void Search(string searchText)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(searchText);
            SearchBox.Submit();
        }

        //Store the Price of the first item in the Search list
        public void StorePrice()
        {
            Thread.Sleep(2000);
            string tPrice = PriceTag.Text.ToString();
            tPrice = tPrice.Trim((new Char[] { '$' }));
            int Price = int.Parse(tPrice);
            value = Price;

            
        }

        //Compare prices
        public void ComparePrice()
        {
           //Thread.Sleep(1500);
           //string oPrice = OurPrice.Text.ToString();
           //oPrice = oPrice.Trim((new Char[] { '$' }));
           //int cPrice = int.Parse(oPrice);
           //Console.WriteLine("Comparing Price in the Search Page: " + value + " with Price in the Product selection: " + cPrice + " the result is: " + value.CompareTo(cPrice));
        }
        //Add to Cart
        public void AddToCart()
        {
            AddToCarts.Click();
        }
        //Select first item in the results list
        public void SelectResult()
        {
            FirstItem.Click();
        }

        public void MakeUser()
        {
            Navigate();
            YourAmazon.Click();
            NewUser.Click();
            Assert.Contains("Create account", CreateText.Text);
            Name.Clear();
            Name.SendKeys("TestUser");
            Email.Clear();
            Email.SendKeys("Test@test.com");
            Pass.Clear();
            Pass.SendKeys("123123123");
            PassConf.Clear();
            PassConf.SendKeys("123123123");

        }


        public IWebElement ZipConfirm => _driver.FindElement(By.XPath("//*[@id='GLUXZipUpdate']"));

        public IWebElement ZipConfirm2 => _driver.FindElement(By.XPath("//*[@id='GLUXConfirmClose']"));

        public IWebElement Zipchange => _driver.FindElement(By.CssSelector("span.a-button:nth-child(2) > span:nth-child(1) > input:nth-child(1)"));

        public IWebElement Zipcodefield => _driver.FindElement(By.CssSelector("#GLUXZipUpdateInput"));

        public IWebElement SearchBox => _driver.FindElement(By.CssSelector("#twotabsearchtextbox"));

        public IWebElement PriceTag => _driver.FindElement(By.XPath("//span[@class='celwidget slot=SEARCH_RESULTS template=SEARCH_RESULTS widgetId=search-results index=1']//span[@class='a-price']//span[@aria-hidden='true']"));

        public IWebElement FirstItem => _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div/span[3]/div[1]/div[2]/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a"));

        public IWebElement OurPrice => _driver.FindElement(By.XPath("//*[@id='priceblock_ourprice']"));

        public IWebElement AddToCarts => _driver.FindElement(By.CssSelector("#add-to-cart-button"));

        public IWebElement YourAmazon => _driver.FindElement(By.CssSelector("#nav-your-amazon"));

        public IWebElement NewUser => _driver.FindElement(By.CssSelector("#createAccountSubmit"));

        public IWebElement Name => _driver.FindElement(By.CssSelector("#ap_customer_name"));

        public IWebElement Email => _driver.FindElement(By.CssSelector("#ap_email"));

        public IWebElement Pass => _driver.FindElement(By.CssSelector("#ap_password"));

        public IWebElement PassConf => _driver.FindElement(By.CssSelector("#ap_password_check"));
    
        public IWebElement CreateText => _driver.FindElement(By.CssSelector("h1.a-spacing-small"));
    }
}