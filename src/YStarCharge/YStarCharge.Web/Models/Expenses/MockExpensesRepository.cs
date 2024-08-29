
namespace YStarCharge.Web.Models
{
    public class MockExpensesRepository : IExpensesRepository
    {
        private List<Expenses> _Expenses;

        public MockExpensesRepository() {

            _Expenses = new List<Expenses>()
            {
                new Expenses()
                {
                    Id = 1,
                    CreateAt = DateTime.Now,
                    Money = 50,
                    To = Enums.ExpensesTo.Shopping,
                    Remark ="买菜"
                },
                new Expenses()
                {
                    Id = 2,
                    CreateAt = DateTime.Now,
                    Money = 1425,
                    To = Enums.ExpensesTo.Tour,
                    Remark ="白石山"
                },
                new Expenses()
                {
                    Id = 3,
                    CreateAt = DateTime.Now,
                    Money = 17,
                    To = Enums.ExpensesTo.Repast,
                    Remark ="早饭"
                },
                
            };
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

        public IList<Expenses> GetList()
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
                expense.CreateAt = t.CreateAt;
                expense.Remark = t.Remark;
                expense.Money = t.Money;
                expense.To = t.To;
            }
            return expense;

        }
    }
}
