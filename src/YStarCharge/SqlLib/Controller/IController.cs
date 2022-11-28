using System.Data;

namespace SqlLib.Controller
{
    public interface IController
    {
        int Add(IEntity entity);

        int Update(IEntity entity);

        int Delete(IEntity entity);

        int Delete(int id);

        DataTable Query();

        int Add();

        int Update();

        int GetMaxId();

    }
}
