namespace YStarCharge.Web.Models
{
    public interface IIncomeRepository
    {
        bool Add(Income income);

        Income Update(Income income);

        Income Delete(int? id);

        Income Get(int? id);

        IList<Income> GetIncomes();
    }
}
