using SqlLib;
using SqlLib.Controller;
using YStarCharge.Model;

namespace YStarCharge.Controller
{
    public class UserAccountController : BaseController
    {
        private const string DataTableName = "UserAccount";
        private const string Id = "Id";
        private const string Username = "Username";
        private const string Password = "Password";
        private const string HeadIcon = "HeadIcon";

        public int Insert(UserAccount entity)
        {
            if (entity == null)
            {
                return -1;
            }
            string sql = $"Insert Into {DataTableName} " +
                $"({Password},{HeadIcon},{Username}) " +
                $"Values " +
                $"('{entity.Password}','{entity.HeadIcon}','{entity.Username}')";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public int Update(UserAccount userInfo)
        {
            if (userInfo == null)
            {
                return -1;
            }
            string sql = $"Update {DataTableName} Set " +
                $"{Password}= '{userInfo.Password}',{HeadIcon} = '{userInfo.HeadIcon}' "+
                $"Where {Id} = {userInfo.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }
    }
}
