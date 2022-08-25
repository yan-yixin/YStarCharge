using System.Data;

namespace SqlLib.Controller
{
    public interface IController
    {
        int Add(IEntity entity);

        int Update(IEntity entity);

        int Delete(IEntity entity);

        IEntity Query(int id);

        DataTable Query();
    }
}
