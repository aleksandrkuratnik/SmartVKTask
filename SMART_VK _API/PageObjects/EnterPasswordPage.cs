using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using SMART_VK__API.Utils;
using Aquality.Selenium.Forms;

namespace SMART_VK__API.Pages
{
    internal class EnterPasswordPage : Form
    {
        private IButton continueBtn => ElementFactory.GetButton(By.XPath("//span[@class='vkuiButton__in']"), nameof(continueBtn));
        private ITextBox passwordInput = ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), nameof(passwordInput));

        public EnterPasswordPage() : base(By.XPath("//input[@name='password']"), "PasswordInput")
        {
        }

        public void EnterPasswordAndContinue()
        {
            passwordInput.ClearAndType(TestConfigManager.userData.Password);
            continueBtn.Click();
        }
    }
}
