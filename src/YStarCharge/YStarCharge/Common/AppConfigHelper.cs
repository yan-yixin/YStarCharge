using System.Configuration;

namespace YStarCharge.Common
{
    internal static class AppConfigHelper
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        static AppConfigHelper()
        {
            Username = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
        }

        
    }
}
