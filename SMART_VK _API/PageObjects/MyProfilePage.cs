using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SMART_VK__API.PageObjects
{
    internal class MyProfilePage : Form
    {
        public MyProfilePage() : base(By.XPath("//div[@class='InlineShortInfoCell-module__label--sdxaV']"), "learnMoreBtn")
        {
        }

    }
}
