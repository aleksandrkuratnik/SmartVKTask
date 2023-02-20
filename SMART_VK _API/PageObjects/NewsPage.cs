using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SMART_VK__API.Pages
{
    internal class NewsPage : Form
    {
        private IButton myProfileBtn => ElementFactory.GetButton(By.XPath("//*[@id='l_pr']"), "My Profile");

        public NewsPage() : base(By.XPath("//div[@class='feed_lists_icon_content ui_rmenu_right-icon']//*[name()='svg']"), "Choose content Btn")
        {
        }

        public void ClickMyProfileButton()
        {
            myProfileBtn.Click();
        }
    }
}
