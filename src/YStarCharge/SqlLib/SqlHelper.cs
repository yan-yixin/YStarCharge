using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SqlLib
{
    public class SqlHelper
    {
        private static SqlHelper instance = new SqlHelper();

        public static SqlHelper Instance
        {
            get
            {
                return instance;
            }
        }

        private SqlConnection connection;

        private SqlHelper()
        {
            connection = new SqlConnection();
        }

        public bool InitlizeDatabase()
        {
            var controllerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Controller");
            if (!Directory.Exists(controllerPath))
            {
                throw new IOException("不存在文件夹Controller");
            }
            var controllers =  Directory.GetFiles(controllerPath);
            if(controllers == null || controllers.Length <= 0)
            {
                throw new IOException("不存在任何Controller类。");
            }

            foreach (var con in controllers)
            {
                var contollrer = Path.GetFileNameWithoutExtension(con);
                
            }
            return true;
        }

        public int ExecuteNonCommand(string sqlStr)
        {
            try
            {
                Connect(ConfigureHelper.ConnectionString);
                SqlCommand command = new SqlCommand(sqlStr, connection);
                int count = command.ExecuteNonQuery();
                Disconnect();
                return count;
            }
            catch(Exception ex)
            {
                throw new Exception($"关闭数据库出错，{ex}");
            }
            
        }

        public DataTable ExcuteCommand(string sqlComm)
        {
            try
            {
                Connect(ConfigureHelper.ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = new SqlCommand(sqlComm, connection);

                DataSet ds = new DataSet();
                sda.Fill(ds);
                Disconnect();
                if(ds == null)
                {
                    return null;
                }
                if(ds.Tables.Count <= 0)
                {
                    return null;
                }
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception($"查询数据出错，{ex}");
            }
        }

        public void ExecuteTransaction()
        {

        }

        public void ExecuteProcedure(string procName,Dictionary<string,object> param)
        {
            if (string.IsNullOrWhiteSpace(procName))
            {
                return;
            }
            Connect(ConfigureHelper.ConnectionString);

            SqlCommand command = new SqlCommand(procName,connection);
            command.CommandType = CommandType.StoredProcedure;

            if(param != null)
            {
                foreach(var key in param.Keys)
                {
                    command.Parameters.Add(new SqlParameter(key, param[key]));
                }
            }
            command.ExecuteNonQuery();
        }

        private void Connect(string connectString)
        {
            if (string.IsNullOrWhiteSpace(connectString))
            {
                throw new Exception("连接字符串不能为空！");
            }
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectString);
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.ConnectionString = connectString;
                    connection.Open();
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"连接数据库出错，{ex}");
            }
        }

        private void Disconnect()
        {
            try
            {
                if (connection == null)
                {
                    return;
                }
                if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"关闭数据库出错，{ex}");
            }
        }

       

    }
}
