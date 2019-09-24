using OpenQA.Selenium;
using SpecFlow.Selenium.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlow.Selenium.StepDefinitions
{
	[Binding]
	public class StepDefinitions
	{
		private readonly AmazonPage _page;
		
		public StepDefinitions(IWebDriver driver)
		{
			_page = new AmazonPage(driver);
		}
		
		[Given(@"I am on ""(.*)""")]
		public void GivenIAmOn(string url)
		{
			_page.Navigate(url);
            _page.ChangeZip();
		}
	
        
		[Given(@"I search for ""(.*)""")]
		public void WhenISearchFor(string library)
		{
			_page.Search(library);
		}
        
		[Given(@"select ""(.*)"" in the search results")]
		public void WhenSelectInTheSearchResults(string library)
		{
            _page.StorePrice();
			_page.SelectResult();
		}

        [When(@"I enter the product and add it")]
        public void WhenAddingToCart()
        {
            _page.ComparePrice();
            _page.AddToCart();
        }
        
		[Then(@"I create account")]
		public void ThenICreateAccount()
		{
            _page.MakeUser();
		}
	}
}