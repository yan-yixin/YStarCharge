using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLib.Controller
{
    public abstract class BaseController : IController
    {
        public int Add(IEntity entity)
        {
            //根据配置文件获取字段名


            return -1;
        }

        public int Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }


        public IEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable Query()
        {
            throw new NotImplementedException();
        }

        public int Update(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
