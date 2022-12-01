using SqlLib;
using SqlLib.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
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
                $"{CreateAt}= '{entity.CreateAt}' " +
                $"Where {Id} = {entity.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql);
        }

        public DataTable Query(IncomeFliter fliter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Select * From {DataTableName} Where ");
            if(fliter.StartDate != fliter.EndDate)
            {
                sb.Append($"{CreateAt} Between '{fliter.StartDate}' And '{fliter.EndDate}' And ");
            }
            if(fliter.MinMoney != 0 || fliter.MaxMoney != 0)
            {
                sb.Append($"{Amount} >= {fliter.MinMoney} And {Amount} <= {fliter.MaxMoney}  And ");
            }
            sb.Append($"{Channel} = {(int)fliter.Channel} And {Username} = '{AppContext.Instacne.Username}'");
            return SqlHelper.Instance.ExcuteCommand(sb.ToString());
        }

        public ObservableCollection<Income> ToObservableList(DataTable table)
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

        public DataTable Query(TimeUnit unit,DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Select * From {DataTableName} Where ");
            switch (unit)
            {
                case TimeUnit.年:
                    sb.Append($"Year({CreateAt}) = '{date.Year}'");
                    break;
                case TimeUnit.月:
                    sb.Append($"Month({CreateAt}) = '{date.Month}'");
                    break;
                case TimeUnit.日:
                    sb.Append($"Day({CreateAt}) = '{date.Day}'");
                    break;
            }
            sb.Append($" And {Username} = '{AppContext.Instacne.Username}'");
            return SqlHelper.Instance.ExcuteCommand(sb.ToString());
        }

        public List<Income> ToList(DataTable table)
        {
            List<Income> expends = new List<Income>();
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
