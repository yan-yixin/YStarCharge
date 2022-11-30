using SqlLib;
using SqlLib.Controller;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using YStarCharge.Model;

namespace YStarCharge.Controller
{
    public class ExpendController : BaseController
    {
        private const string DataTableName = "Expend";
        private const string Id = "Id";
        private const string Username = "Username";
        private const string Amount = "Amount";
        private const string CreateAt = "CreateAt";
        private const string Direction = "Direction";
        private const string Remark = "Remark";

        public int Insert(Expend entity)
        {
            if(entity == null)
            {
                return -1;
            }
            string sql = $"Insert Into {GetName()} " +
                $"({Amount},{CreateAt},{Direction},{Remark},{Username}) " +
                $"Values " +
                $"({entity.Amount},'{entity.CreateAt}',{(int)entity.Direction},'{entity.Remark}','{entity.Username}')";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public int Update(Expend entity)
        {
            if (entity == null)
            {
                return -1;
            }
            string sql = $"Update {GetName()} Set " +
                $"{Amount}= {entity.Amount},{Direction} = {(int)entity.Direction},{Remark} = '{entity.Remark}'," +
                $"{CreateAt}= '{entity.CreateAt}' " +
                $"Where {Id} = {entity.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public DataTable Query(ExpendFliter fliter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Select * From {DataTableName} Where ");
            if (fliter.StartDate != fliter.EndDate)
            {
                sb.Append($"{CreateAt} Between '{fliter.StartDate}' And '{fliter.EndDate}' And ");
            }
            if (fliter.MinMoney != 0 && fliter.MaxMoney != 0)
            {
                sb.Append($"{Amount} >= {fliter.MinMoney} And {Amount} <= {fliter.MaxMoney}  And ");
            }
            sb.Append($"{Direction} = {(int)fliter.Direction}");
            return SqlHelper.Instance.ExcuteCommand(sb.ToString());
        }

        public ObservableCollection<Expend> ToList(DataTable table)
        {
            ObservableCollection<Expend> expends = new ObservableCollection<Expend>();
            if (table == null || table.Rows.Count <= 0)
            {
                return expends;
            }
            for(int i =0;i< table.Rows.Count;i++)
            {
                var row = table.Rows[i];
                Expend expend = new Expend();
                var id = row[Id].ToString();
                expend.Id = int.Parse(row[Id].ToString());
                expend.Username = row[Username].ToString();
                expend.CreateAt = DateTime.Parse(row[CreateAt].ToString());
                expend.Direction = (ExpendTo)int.Parse(row[Direction].ToString());
                expend.Amount = float.Parse(row[Amount].ToString());
                expend.Remark = row[Remark].ToString();
                expends.Add(expend);
            }
            return expends;
        }
    }
}
