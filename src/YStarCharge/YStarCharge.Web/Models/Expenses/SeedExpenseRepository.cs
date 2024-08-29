
using YStarCharge.Web.Data;

namespace YStarCharge.Web.Models
{
    public class SeedExpenseRepository : IExpensesRepository
    {
        private SqlDBContext _SqlDBContext;
        public SeedExpenseRepository(SqlDBContext sqlDBContext) { 
            _SqlDBContext = sqlDBContext;
        }


        public Expenses Add(Expenses expenses)
        {
            if(expenses == null)
            {
                return null;
            }
            _SqlDBContext.Expenses.Add(expenses);
            _SqlDBContext.SaveChanges();
            return expenses;
        }

        public Expenses Delete(int? id)
        {
            var expense = _SqlDBContext.Expenses.FirstOrDefault(x => x.Id == id);
            if (expense != null)
            {
                _SqlDBContext.Expenses.Remove(expense);
                _SqlDBContext.SaveChanges();
            }

            return expense;

        }

        public Expenses Get(int? id)
        {
            return _SqlDBContext.Expenses.FirstOrDefault(x => x.Id == id);
        }

        public IList<Expenses> GetIncomes()
        {
            return _SqlDBContext.Expenses.ToList();
        }

        public bool IsExist(Expenses t)
        {
            var expense = _SqlDBContext.Expenses.FirstOrDefault(x => x.Id == t.Id);

            return expense != null;
        }

        public Expenses Update(Expenses t)
        {
            var expense = _SqlDBContext.Expenses.FirstOrDefault(x => x.Id == t.Id);
            if(expense != null)
            {
                expense.IsSelected = t.IsSelected;
                expense.CreateAt = t.CreateAt;
                expense.Money = t.Money;
                expense.Remark = t.Remark;
                expense.To = t.To;
            }

            return expense;
        }
    }
}
