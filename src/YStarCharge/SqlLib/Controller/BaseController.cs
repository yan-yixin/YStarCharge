using System;
using System.Data;
using System.Linq;
using System.Text;

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
                if(pro.Name == "Id" || pro.Name == "IsSelected")
                {
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
                    else if(pro.PropertyType == typeof(DateTime))
                    {
                        sb.Append($"{(DateTime)value:yyyy-MM-dd},");
                    }
                    else
                    {
                        sb.Append($"{value},");
                    }
                }
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

        public DataTable Query(string username)
        {
            string sql = $"Select * From {GetName()} Where Username = '{username}'";
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

        public T Get<T>(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return default;
            }

            string sql = $"Select * From {GetName()} Where Username = '{username}'";
            var table = SqlHelper.Instance.ExcuteCommand(sql);
            if (table == null || table.Rows.Count <= 0)
            {
                return default;
            }
            T t = System.Activator.CreateInstance<T>();
            Type type = t.GetType();
            var properties = type.GetProperties();
            if (properties == null)
            {
                return default;
            }
            for (int i = 0; i < properties.Length; i++)
            {
                var pro = properties[i];
                if (table.Columns.Contains(pro.Name))
                {
                    var value = table.Rows[0][pro.Name];
                    if (string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        value = string.Empty;
                    }
                    pro.SetValue(t, value);
                }
            }
            return (T)t;
        }

        public bool IsExist(IEntity entity)
        {
            if(entity == null)
            {
                return false;
            }
            string sql = $"Select * From {GetName()} Where Id = {entity.Id};";
            var table = SqlHelper.Instance.ExcuteCommand(sql);
            if (table == null || table.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }

        protected virtual string GetName()
        {
            return GetType().Name.Replace("Controller", "").Trim();
        }



    }
}
