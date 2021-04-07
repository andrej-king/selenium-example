using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace NUnitTests
{
    

    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // driver.Navigate().GoToUrl("https://google.com/");
        }

        // [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(45)]
        [TestCase(80)]
        [TestCase(999)]
        public void TestAgeRange(int age)
        {
            driver.Url = "D:\\NUnitTests\\web\\index.html";
            IWebElement txtAge = driver.FindElement(By.Id("txtAge"));
            IWebElement validations = driver.FindElement(By.Id("validations"));
        
            txtAge.SendKeys(age.ToString());
            txtAge.SendKeys("\t");
            string validationText = validations.GetAttribute("innerHTML");
            if (validationText == "") {
                Assert.Pass();
            } else {
                Assert.Fail();
            }                 
        }

        [OneTimeTearDown]
        public void Close() => driver.Close();
    }
}