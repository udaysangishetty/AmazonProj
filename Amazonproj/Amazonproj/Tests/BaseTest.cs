using Amazonproj.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Amazonproj.Tests
{
    /// <summary>
    /// Base test class for all test classes
    /// </summary>
    public class BaseTest
    {
        public static AndroidDriver<AndroidElement> _driver;
        public static Parameters param1;
        
        
        /// <summary>
        /// Initializes App and emulator device
        /// </summary>
         [TestInitialize]
        public void Initialize()
        {
            //Set options
            AppiumOptions opt = new AppiumOptions();
            Parameters param;
            string fileName = @"C:/Users/Uday.Sangishetty/source/repos/Amazonproj/Amazonproj/Data/Data.json";
            string json = System.IO.File.ReadAllText(fileName);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Parameters));
                 param = (Parameters)deserializer.ReadObject(ms);
               
            }
            opt.AddAdditionalCapability(MobileCapabilityType.DeviceName, param.Emulator);
            opt.AddAdditionalCapability(MobileCapabilityType.PlatformName, param.PlatformName);
            opt.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, param.PlatformVersion);
            opt.AddAdditionalCapability(MobileCapabilityType.AutomationName, param.AutomationName);
            opt.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, param.AppPackage);
            opt.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, param.AppActivity);

            //Invoke Driver
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), opt);
            param1 = param;
        }

        /// <summary>
        /// Clean up driver
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            _driver.CloseApp();
            _driver.Dispose();
        }
    }
}
