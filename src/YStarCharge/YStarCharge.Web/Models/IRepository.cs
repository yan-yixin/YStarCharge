namespace YStarCharge.Web.Models
{
    public interface IRepository<T>
    {
        T Add(T t);

        T Update(T t);

        T Delete(int? id);

        T Get(int? id);

        IList<T> GetIncomes();

        bool IsExist(T t);
    }
}
