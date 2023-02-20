using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_VK__API.PageObjects;
using SMART_VK__API.Pages;
using SMART_VK__API.Utils;

namespace SMART_VK__API.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private WelcomePage _welcomePage;
        private protected WelcomePage welcomePage => _welcomePage ??= new WelcomePage();

        private EnterPasswordPage _enterPasswordPage;
        private protected EnterPasswordPage enterPasswordPage => _enterPasswordPage ??= new EnterPasswordPage();

        private NewsPage _newsPage;
        private protected NewsPage newsPage => _newsPage ??= new NewsPage();

        private MyProfilePage _myProfilePage;
        private protected MyProfilePage myProfilePage => _myProfilePage ??= new MyProfilePage();

        [SetUp]
        public void Setup()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(TestConfigManager.testConfig.MainUrl);
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void AfterEach()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
