
namespace YStarCharge.Web.Models
{
    public class MockExpensesRepository : IExpensesRepository
    {
        private List<Expenses> _Expenses;

        public MockExpensesRepository() {

            _Expenses = new List<Expenses>();
        }

        public Expenses Add(Expenses expenses)
        {
            if (!_Expenses.Contains(expenses))
            {
                _Expenses.Add(expenses);
            }
            return expenses;
        }

        public Expenses Delete(int? id)
        {
            var expense = _Expenses.FirstOrDefault(x => x.Id == id);
            if (expense != null)
            {
                _Expenses.Remove(expense);  
            }
            return expense;
        }

        public Expenses Get(int? id)
        {
            return _Expenses.FirstOrDefault(x => x.Id == id);
        }

        public IList<Expenses> GetIncomes()
        {
            return _Expenses;
        }

        public bool IsExist(Expenses t)
        {
            var expense = _Expenses.FirstOrDefault(x => x.Id == t.Id);

            return expense != null;
        }

        public Expenses Update(Expenses t)
        {
            var expense = _Expenses.FirstOrDefault(x => x.Id == t.Id);
            if (expense != null)
            {
                expense.IsSelected = t.IsSelected;
                expense.CreateAt = t.CreateAt;
                expense.Remark = t.Remark;
                expense.Money = t.Money;
                expense.To = t.To;
            }
            return expense;

        }
    }
}
