using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]

    public class JSChromeTest
    {
        static IWebDriver web = null;

        [ClassInitialize]
        public static void Setup(TestContext tc)
        {

            web = new ChromeDriver();

            web.Navigate().GoToUrl("http://localhost:63818/Home/CalcButtons");
        }

        [TestInitialize]
        public void RefreshWeb()
        {
            web.Navigate().Refresh();
        }

        [ClassCleanup]
        public static void QuitWeb()
        {

            web.Quit();

        }

        [DataTestMethod]
        [DataRow("num1", "1")]
        [DataRow("num2", "2")]
        [DataRow("num3", "3")]
        [DataRow("num4", "4")]
        [DataRow("num5", "5")]
        [DataRow("num6", "6")]
        [DataRow("num7", "7")]
        [DataRow("num8", "8")]
        [DataRow("num9", "9")]
        [DataRow("num0", "0")]
        [DataRow("op_minus", "-")]
        [DataRow("op_plus", "+")]
        [DataRow("op_multiply", "*")]
        [DataRow("op_divide", "/")]
        [DataRow("calculate", "=")]
        [DataRow("answer", "")]
        public void JSTestChrome(string button, string result)
        {
            IWebElement webel = web.FindElement(By.Id(button));

            Assert.AreEqual(result, webel.GetAttribute("value"));
        }

        [DataTestMethod]
        [DataRow("num1", "1")]
        [DataRow("num2", "2")]
        [DataRow("num3", "3")]
        [DataRow("num4", "4")]
        [DataRow("num5", "5")]
        [DataRow("num6", "6")]
        [DataRow("num7", "7")]
        [DataRow("num8", "8")]
        [DataRow("num9", "9")]
        [DataRow("num0", "0")]
        public void JSTestCalcChromeSeimpleCheck(string button, string result)
        {
            web.FindElement(By.Id(button)).Click();
            string res = web.FindElement(By.Id("answer")).GetAttribute("value");
            Assert.AreEqual(result, res);
        }

        [DataTestMethod]
        [DataRow("num1", "num3", "13")]
        [DataRow("num2", "num4", "24")]
        [DataRow("num3", "num6", "36")]
        [DataRow("num4", "num7", "47")]
        [DataRow("num5", "num4", "54")]
        [DataRow("num6", "num2", "62")]
        [DataRow("num7", "num3", "73")]
        [DataRow("num8", "num3", "83")]
        [DataRow("num9", "num2", "92")]
        [DataRow("num0", "num9", "09")]
        public void JSTestCalcChromeComplexCheck(string firstbutton, string secondbutton, string result)
        {
            web.FindElement(By.Id(firstbutton)).Click();
            web.FindElement(By.Id(secondbutton)).Click();
            string res = web.FindElement(By.Id("answer")).GetAttribute("value");
            Assert.AreEqual(result, res);
        }

        [DataTestMethod]
        [DataRow("num1", "op_minus", "num5", "-4")]
        [DataRow("num7", "op_plus", "num5", "12")]
        [DataRow("num5", "op_multiply", "num6", "30")]
        [DataRow("num6", "op_divide", "num3", "2")]
        public void JSTestCalcChromeRealJob(string firstbutton, string operation, string secondbutton, string result)
        {
            web.FindElement(By.Id(firstbutton)).Click();
            web.FindElement(By.Id(operation)).Click();
            web.FindElement(By.Id(secondbutton)).Click();
            web.FindElement(By.Id("calculate")).Click();
            string res = web.FindElement(By.Id("answer")).GetAttribute("value");
            Assert.AreEqual(result, res);
        }
    }
}
