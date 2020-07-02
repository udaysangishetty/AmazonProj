using Amazonproj.HelperMethods;
using Amazonproj.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.Android;

namespace Appium
{
    /// <summary>
    /// Testing Amazon add to Cart functionality
    /// </summary>
    [TestClass]
    public class AmazonAppTest: BaseTest
    {
        AndroidDriver<AndroidElement> _Testdriver;
        public  AmazonAppTest()
        {
            _Testdriver = _driver;
        }

      
        
       
        /// <summary>
        /// Verify flow to add an item to cart
        /// </summary>
        [TestMethod]
        public void VerifyAddItemToCart()
        {
            //Signin to App
            PageMethods page = new PageMethods();
            page.SignIn();

            //Search for Item and Click on it
            page.SearchItemAndAddtoCart();
        }

        
    }
}
