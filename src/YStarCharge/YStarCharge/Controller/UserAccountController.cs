using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLib.Controller;
using YStarCharge.Model;

namespace YStarCharge.Controller
{
    public class UserAccountController : BaseController
    {
        public UserAccount GetAccount(string username)
        {
            UserAccount ua = new UserAccount();
            
            string sql = $"Select * From UserAccount Where Username = '{username}'";
            var table = SqlLib.SqlHelper.Instance.ExcuteCommand(sql);
            if(table == null || table.Rows.Count <= 0)
            {
                return null;
            }
            Type type = ua.GetType();
            var properties = type.GetProperties();
            if(properties == null)
            {
                return null;
            }
            for (int i =0;i<properties.Length;i++)
            {
                var pro = properties[i];
                if (table.Columns.Contains(pro.Name))
                {
                    pro.SetValue(ua,table.Rows[0][pro.Name]);
                }
            }
            return ua;
        }
    }
}
