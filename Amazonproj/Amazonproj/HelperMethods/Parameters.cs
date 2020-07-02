namespace Amazonproj.Support
{
    /// <summary>
    /// Parameters from user to search
    /// </summary>
    public class Parameters
    {
        #region properties
        private string userName;
        private string password;
        private string searchtext;
        private string emulator;
        private string platformName;
        private string platformVersion;
        private string automationName;
        private string appPackage;
        private string appActivity;
        public  string Username { get => userName; set => userName = value; }
        public  string Password { get => password; set => password = value; }
        public  string Searchtext { get => searchtext; set => searchtext = value; }
        public string Emulator { get => emulator; set => emulator = value; }
        public string PlatformName { get => platformName; set => platformName = value; }
        public string PlatformVersion { get => platformVersion; set => platformVersion = value; }
        public string AutomationName { get => automationName; set => automationName = value; }
        public string AppPackage { get => appPackage; set => appPackage = value; }
        public string AppActivity { get => appActivity; set => appActivity = value; }
        #endregion
    }
}
