using System.Configuration;

namespace YStarCharge.Common
{
    internal static class AppConfigHelper
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private static bool initlize;
        public static bool IsInitlize
        {
            get
            {
                return initlize;
            }
            set
            {
                if(initlize == value)
                {
                    return;
                }
                initlize = value;
                ConfigurationManager.AppSettings.Set("IsInitlize", value.ToString());
            }
        }

        static AppConfigHelper()
        {
            Username = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
            initlize = bool.Parse(ConfigurationManager.AppSettings["IsInitlize"]);
        }

        
    }
}
