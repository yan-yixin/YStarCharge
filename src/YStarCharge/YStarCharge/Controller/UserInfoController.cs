using SqlLib;
using SqlLib.Controller;
using YStarCharge.Model;

namespace YStarCharge.Controller
{
    public class UserInfoController : BaseController
    {
        private const string DataTableName = "UserInfo";
        private const string Id = "Id";
        private const string Username = "Username";
        private const string Name = "Name";
        private const string Gender = "Gender";
        private const string Age = "Age";
        private const string Industry = "Industry";
        private const string Address = "Address";

        public int Insert(UserInfo entity)
        {
            if (entity == null)
            {
                return -1;
            }
            string sql = $"Insert Into {DataTableName} " +
                $"({Name},{Gender},{Age},{Industry},{Address},{Username}) " +
                $"Values " +
                $"('{entity.Name}','{entity.Gender}',{entity.Age},'{entity.Industry}','{entity.Address}','{entity.Username}')";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public int Update(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return -1;
            }
            string sql = $"Update {DataTableName} Set " +
                $"{Name}= '{userInfo.Name}',{Gender} = '{userInfo.Gender}',{Age} = {userInfo.Age}," +
                $"{Industry} = '{userInfo.Industry}',{Address} = '{userInfo.Address}' " +
                $"Where {Id} = {userInfo.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }
    }
}
