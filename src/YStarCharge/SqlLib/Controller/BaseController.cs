using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlLib.Controller
{
    public abstract class BaseController : IController
    {
        public int Add(IEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"参数{entity}不能为空。");
            }
         
            Type type = entity.GetType();
            var properties = type.GetProperties();
            if(properties == null || properties.Count() <= 0)
            {
                return -1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"Insert Into {type.Name} Values (");
            for(int i =0;i< properties.Length; i++)
            {
                var pro = properties[i];
                var value = pro.GetValue(entity);

                if(pro.Name == "Id")
                {
                    sb.Append($"{GetMaxId() + 1},");
                    continue;
                }
                if(i == properties.Length - 1)
                {
                    if(pro.PropertyType == typeof(string))
                    {
                        sb.Append($"'{value}')");
                    }
                    else
                    {
                        sb.Append($"{value})");
                    }
                }
                else
                {
                    if (pro.PropertyType == typeof(string))
                    {
                        sb.Append($"'{value}',");
                    }
                    else
                    {
                        sb.Append($"{value},");
                    }
                }
            }

            return SqlHelper.Instance.ExecuteNonCommand(sb.ToString());
        }

        public int Add()
        {
            //根据配置文件获取字段名
            Type type = this.GetType();
            var properties = type.GetProperties();
            if (properties == null || properties.Count() <= 0)
            {
                return -1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"Insert Into {GetName()} Values (");
            foreach (var pro in properties)
            {
                var value = pro.GetValue(this);
                sb.Append($"{value},");
            }

            return SqlHelper.Instance.ExecuteNonCommand(sb.ToString());
        }

        public int Delete(IEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"参数{entity}不能为空。");
            }
            string sql = $"Delete From {GetName()} Where Id = {entity.Id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql); ;
        }

        public int Delete(int id)
        {
            string sql = $"Delete From {GetName()} Where Id = {id}";
            return SqlHelper.Instance.ExecuteNonCommand(sql); ;
        }

        public int GetMaxId()
        {
            string sql = $"Select Max(Id) From {GetName()};";
            var table = SqlHelper.Instance.ExcuteCommand(sql);
            if(table == null || table.Rows.Count <= 0)
            {
                return 0;
            }
            var value = table.Rows[0][0].ToString();

            return string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
        }

        public DataTable Query()
        {
            string sql = $"Select * From {GetName()}";
            return SqlHelper.Instance.ExcuteCommand(sql);
        }

        public int Update(IEntity entity)
        {
            //根据配置文件获取字段名
            Type type = entity.GetType();
            var properties = type.GetProperties();
            if (properties == null || properties.Count() <= 0)
            {
                return -1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"Update {type.Name} Set ");
            var id = -1;
            for(int i = 0; i < properties.Length; i++)
            {
                var pro = properties[i];
                var name = pro.Name;
                var value = pro.GetValue(entity);
                if (name == "Id" || value == null)
                {
                    continue;
                }
                if (i == properties.Length - 1)
                {
                    sb.Append($"{name} = '{value}' ");
                }
                else
                {
                    sb.Append($"{name} = '{value}' ");
                }
            }
            sb.Append($"Where Id = {entity.Id}");
            return SqlHelper.Instance.ExecuteNonCommand(sb.ToString());
        }

        public int Update()
        {
            //根据配置文件获取字段名
            Type type = this.GetType();
            var properties = type.GetProperties();
            if (properties == null || properties.Count() <= 0)
            {
                return -1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"Update {type.Name.Replace("Controller","").Trim()} Set (");
            var id = -1;
            foreach (var pro in properties)
            {
                var name = pro.Name;
                var value = pro.GetValue(this);          
                if(name == "Id")
                {
                    id = int.Parse(value.ToString());
                    continue;
                }
                sb.Append($"{name} = {value},");
            }
            sb.Append($"Where Id = {id}");
            return SqlHelper.Instance.ExecuteNonCommand(sb.ToString());
        }

        protected virtual string GetName()
        {
            return GetType().Name.Replace("Controller", "").Trim();
        }

        //private T FromDataTable<T>(DataTable table) where T :IEntity
        //{
        //    if(table == null)
        //    {
        //        return default(T);
        //    }
        //    Type type = typeof(T);
        //    for(int i = 0; i < table.Columns.Count; i++)
        //    {
        //        var col = table.Columns[i];

        //        var property = type.GetProperty(col.ColumnName);
        //        if(property == null)
        //        {
        //            continue;
        //        }

        //        property.SetValue(T,table.Rows[0][col.ColumnName]);
        //    }
        //}
    }
}
