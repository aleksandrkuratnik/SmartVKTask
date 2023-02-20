using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_VK__API.Utils;

namespace SMART_VK__API.Pages
{
    internal class WelcomePage : Form
    {
        private IButton signInBtn => ElementFactory.GetButton(By.XPath("//button[@type='submit']//span[@class='FlatButton__in']"), nameof(signInBtn));
        private ITextBox phoneEmailInput => ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), nameof(phoneEmailInput));

        public WelcomePage() : base(By.XPath("//button[@type='submit']//span[@class='FlatButton__in']"), "FlatButton")
        {
        }

        public void InputLoginAndClickSingInButton()
        {
            phoneEmailInput.ClearAndType(TestConfigManager.userData.Login);
            signInBtn.Click();
        }
    }
}
