using Amazonproj.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace Amazonproj.HelperMethods
{
    /// <summary>
    /// Page Methods Class, contains methods on each page of App
    /// </summary>
    public class PageMethods
    {
        SearchPage search = new SearchPage();
        SigninPage signin = new SigninPage();
        Actions actobj = new Actions();

        /// <summary>
        /// Signin into App
        /// </summary>
        public void SignIn()
        {
            actobj.ConditionalWait(signin.signinAnywayButton);
            actobj.ClickElement(signin.signinAnywayButton);
            actobj.ConditionalWait(signin.emailIdTextBox);
            actobj.SetTextElementByFeildname(signin.emailIdTextBox,"UserName");
            actobj.ClickElement(signin.contiueButton);
            Thread.Sleep(2000);
            actobj.ConditionalWait(signin.passwordTextBox);
            actobj.FindElementByUiAutomator(signin.passwordCheckBox).Click();
            actobj.SetTextElementByFeildname(signin.passwordTextBox, "Password");
            actobj.ClickElement(signin.signinButton);
            actobj.ConditionalWait(signin.searchTextBox);
        }
        /// <summary>
        /// Seaches an item and add that item to cart
        /// </summary>
        public void SearchItemAndAddtoCart()
        {
            //Search for Desired Item
            actobj.ClickElement(search.searchTextboxMini);
            actobj.ConditionalWait(search.searchTextboxFull);
            actobj.ClickElement(search.searchTextboxFull);
            //actobj.SetTextElementByFeildname(search.searchTextboxFull,"SearchText");

            //actobj.ImplicitWait();
            actobj.ClickOnEnter();

            //Clicking on one of the item in search results

            var listofSearchResultsContainer = actobj.FindElementByUiAutomator(search.listviewOfSearchResults);
            var listofSearchResults = listofSearchResultsContainer.FindElementsByClassName(search.purchaseItem);
            var selectedSearchResult = listofSearchResults[5].FindElementsByClassName(search.purchaseItem);
            string ItemTobeAddedToCart = selectedSearchResult[0].Text.Substring(1, 10);
            actobj.ImplicitWait();
            selectedSearchResult[0].Click();

            //Change orientation not working as app denies it

            /*driver.Orientation = OpenQA.Selenium.ScreenOrientation.Landscape;
            CommonMethods.ConditionalWait(By.Id(addtocartbutton), driver);
            driver.Orientation = OpenQA.Selenium.ScreenOrientation.Portrait;*/

            //Verify if selected element is shown to add to Cart
            actobj.ImplicitWait();
            var cont = actobj.FindElementByUiAutomator(search.containerForSearchItem);
            var SelectedElementText = cont.FindElementByClassName(search.purchaseItem);
            Assert.IsTrue(SelectedElementText.Text.Contains(ItemTobeAddedToCart));

            //Scroll down and add element to Cart
            actobj.Scroll(0.00001);
            actobj.FindElementByUiAutomator(search.addtoCartButton).Click();
            actobj.ImplicitWait();
            actobj.ClickElement(search.cartIcon);

            //Proceed to checkout
            actobj.ImplicitWait();
            actobj.FindElementByUiAutomatorusingText(search.proceedToCheckout).Click();

            //Select Delivery Address
            actobj.ImplicitWait();
            actobj.FindElementByUiAutomator(search.deliverTothisAddressButton).Click();
            actobj.ImplicitWait();
            actobj.ClickElement(search.continueButton);
        }
    }
}
