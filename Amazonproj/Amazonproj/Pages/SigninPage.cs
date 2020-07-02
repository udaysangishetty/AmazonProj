using OpenQA.Selenium;

namespace Amazonproj.Pages
{
    /// <summary>
    /// Sign in page objects
    /// </summary>
    class SigninPage
    {
        
        #region objects
        public By  signinAnywayButton= By.Id("in.amazon.mShop.android.shopping:id/sign_in_button");
        public By emailIdTextBox = By.ClassName("android.widget.EditText");
        public By contiueButton = By.ClassName("android.widget.Button");
        public By passwordTextBox = By.ClassName("android.widget.EditText");
        public By signinButton = By.ClassName("android.widget.Button");
        public By searchTextBox = By.Id("in.amazon.mShop.android.shopping:id/search_edit_text");
        public string passwordCheckBox = "auth-signin-show-password-checkbox";
        #endregion

       
    }
}
