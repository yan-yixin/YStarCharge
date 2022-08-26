using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLib
{
    public static class ConfigureHelper
    {
        public static string ConnectionString { get; set; }

        static ConfigureHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
        }
    }
}
