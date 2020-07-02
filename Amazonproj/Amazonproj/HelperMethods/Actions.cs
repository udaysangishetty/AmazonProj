using Amazonproj.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Amazonproj
{
    /// <summary>
    /// Contains methods to perform actions on app
    /// </summary>
    public class Actions :BaseTest
    {
        public AndroidDriver<AndroidElement> ActionsDriver;
        public Actions()
        {
            ActionsDriver = _driver;
        }
        
        /// <summary>
        /// Wait for a certain element by its identifier
        /// </summary>
        /// <param name="ele"></param>
        public  void ConditionalWait(By ele)
        {
            WebDriverWait wait = new WebDriverWait(ActionsDriver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ele));
        }
        /// <summary>
        /// Click an element
        /// </summary>
        /// <param name="identifier"></param>
        public  void ClickElement(By identifier)
        {
            ActionsDriver.FindElement(identifier).Click();
        }
        /// <summary>
        /// set text for an element
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="text"></param>
        public  void SetTextElement(By identifier, string text)
        {
            ActionsDriver.FindElement(identifier).SendKeys(text);
        }
        /// <summary>
        /// Set Element by feild name
        /// </summary>
        /// <param name="identifier">Identifier</param>
        /// <param name="text">text to be entered</param>
        public void SetTextElementByFeildname(By identifier, string text)
        {
            switch (text)
            {
                case ("UserName"):
                    ActionsDriver.FindElement(identifier).SendKeys(param1.Username);
                    break;
                case ("Password"):
                    ActionsDriver.FindElement(identifier).SendKeys(param1.Password);
                    break;
                case ("SearchText"):
                    ActionsDriver.FindElement(identifier).SendKeys(param1.Searchtext);
                    break;
            }
        }
        /// <summary>
        /// Keyboard enter method
        /// </summary>
        public void ClickOnEnter()
        {
            ActionsDriver.FindElement(By.Id("in.amazon.mShop.android.shopping:id/search_auto_text")).SendKeys("65-inch Tv");
            ActionsDriver.PressKeyCode(AndroidKeyCode.Keycode_TAB);
            ActionsDriver.PressKeyCode(AndroidKeyCode.Keycode_TAB);
            ActionsDriver.PressKeyCode(AndroidKeyCode.Keycode_TAB);
            ActionsDriver.PressKeyCode(AndroidKeyCode.Keycode_TAB);
            TouchAction actions = new TouchAction((IPerformsTouchActions)ActionsDriver);
            actions.Tap(323, 387).Perform();
            ImplicitWait();
        }



        /// <summary>
        /// Scroll in app with mentioned height
        /// </summary>
        /// <param name="driver">intial driver</param>
        /// <param name="height">height of window</param>
        public  void Scroll( double height)
        {
            TouchAction action = new TouchAction(ActionsDriver);
            var dim = ActionsDriver.Manage().Window.Size;
            int startx = dim.Width / 2;
            double starty = (double)(dim.Height * 0.8);
            double endy = (double)(dim.Height * height);
            action.Press(startx, starty).Wait(1000).MoveTo(startx, endy).Release().Perform();
        }

       /// <summary>
       /// Find Element by id
       /// </summary>
       /// <param name="id">Id of element</param>
       /// <returns>Element searched</returns>
        public  AndroidElement FindElementByUiAutomator(string id)
        {
            string resoureId = @"new UiSelector().resourceId(" + "\"" + id + "\"" + ")";
            return ActionsDriver.FindElementByAndroidUIAutomator(resoureId);
        }

        /// <summary>
        /// Find element using UIAutomator using text
        /// </summary>
        /// <param name="id">search element by text</param>
        /// <returns>Element searched</returns>
        public AndroidElement FindElementByUiAutomatorusingText(string id)
        {
            string resoureId = @"new UiSelector().text(" + "\"" + id + "\"" + ")";
            return ActionsDriver.FindElementByAndroidUIAutomator(resoureId);
        }
        /// <summary>
        /// Method for Implicit Wait
        /// </summary>
        public  void ImplicitWait()
        {
            ActionsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
