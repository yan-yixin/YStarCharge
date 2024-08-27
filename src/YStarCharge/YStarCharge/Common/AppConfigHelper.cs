using System.Configuration;

namespace YStarCharge.Common
{
    internal static class AppConfigHelper
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private static bool isRemeberAccount;
        public static bool IsRemeberAccount
        {
            get
            {
                return isRemeberAccount;
            }
            set
            {
                if(isRemeberAccount == value)
                {
                    return;
                }
                isRemeberAccount = value;
                UpdateConfig("IsRemeberAccount", value.ToString());
            }
        }

        static AppConfigHelper()
        {
            Username = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
            IsRemeberAccount = bool.Parse(ConfigurationManager.AppSettings["IsRemeberAccount"]);
        }

        private static void UpdateConfig(string setName,string setValue)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[setName].Value = setValue;

            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);
        }
        
    }
}
