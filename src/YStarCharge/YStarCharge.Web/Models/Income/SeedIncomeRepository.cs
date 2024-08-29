
using YStarCharge.Web.Data;

namespace YStarCharge.Web.Models
{
    public class SeedIncomeRepository : IIncomeRepository
    {

        private SqlDBContext _SqlDBContext;

        public SeedIncomeRepository(SqlDBContext sqlDBContext)
        {
            _SqlDBContext = sqlDBContext;
        }

        public Income Add(Income t)
        {
            if (t == null)
            {
                return null;
            }
            _SqlDBContext.Incomes.Add(t);
            _SqlDBContext.SaveChanges();

            return t;
        }

        public Income Delete(int? id)
        {
            var income = _SqlDBContext.Incomes.FirstOrDefault(x => x.Id == id);
            if(income != null)
            {
                _SqlDBContext.Incomes.Remove(income);
                _SqlDBContext.SaveChanges();
            }
            return income;
        }

        public Income Get(int? id)
        {
            return _SqlDBContext.Incomes.FirstOrDefault(x => x.Id == id);
        }

        public IList<Income> GetIncomes()
        {
            return _SqlDBContext.Incomes.ToList();
        }

        public bool IsExist(Income t)
        {
            var income = _SqlDBContext.Incomes.FirstOrDefault(x => x.Id == t.Id);
            return income != null;
        }

        public Income Update(Income t)
        {
            var income = _SqlDBContext.Incomes.FirstOrDefault(x => x.Id == t.Id);
            if (income != null)
            {
                income.From = t.From;
                income.Remark = t.Remark;
                income.CreateAt = t.CreateAt;
                income.Money = t.Money;
                income.IsSelected = t.IsSelected;
            }
            return income;
        }
    }
}
