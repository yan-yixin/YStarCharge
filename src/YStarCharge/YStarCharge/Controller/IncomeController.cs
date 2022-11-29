using SqlLib;
using SqlLib.Controller;
using System;
using System.Collections.ObjectModel;
using System.Data;
using YStarCharge.Model;

namespace YStarCharge.Controller
{
    public class IncomeController : BaseController
    {
        private const string DataTableName = "Income";
        private const string Id = "Id";
        private const string Username = "Username";
        private const string Amount = "Amount";
        private const string CreateAt = "CreateAt";
        private const string Channel = "Channel";
        private const string Remark = "Remark";

        public int Insert(Income entity)
        {
            if (entity == null)
            {
                return -1;
            }
            string sql = $"Insert Into {GetName()} " +
                $"({Amount},{CreateAt},{Channel},{Remark},{Username}) " +
                $"Values " +
                $"({entity.Amount},{entity.CreateAt:yyyy-MM-dd},{(int)entity.Channel},'{entity.Remark}','{entity.Username}')";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public int Update(Income entity)
        {
            if (entity == null)
            {
                return -1;
            }
            string sql = $"Update {GetName()} Set " +
                $"{Amount}= {entity.Amount},{Channel} = {(int)entity.Channel},{Remark} = '{entity.Remark}'," +
                $"{CreateAt}= {entity.CreateAt:yyyy-MM-dd} " +
                $"Where {Id} = {entity.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public DataTable Query(ExpendFliter fliter)
        {
            string sql = $"Select * From {DataTableName} Where " +
                $"{CreateAt} Between {fliter.StartDate} And {fliter.EndDate}";

            return SqlHelper.Instance.ExcuteCommand(sql);
        }

        public ObservableCollection<Income> ToList(DataTable table)
        {
            ObservableCollection<Income> expends = new ObservableCollection<Income>();
            if (table == null || table.Rows.Count <= 0)
            {
                return expends;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                Income expend = new Income();
                var id = row[Id].ToString();
                expend.Id = int.Parse(row[Id].ToString());
                expend.Username = row[Username].ToString();
                expend.CreateAt = DateTime.Parse(row[CreateAt].ToString());
                expend.Channel = (IncomeFrom)int.Parse(row[Channel].ToString());
                expend.Amount = float.Parse(row[Amount].ToString());
                expend.Remark = row[Remark].ToString();
                expends.Add(expend);
            }
            return expends;
        }
    }
}
