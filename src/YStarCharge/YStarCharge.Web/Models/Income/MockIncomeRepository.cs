
using Microsoft.EntityFrameworkCore;
using YStarCharge.Web.Data;

namespace YStarCharge.Web.Models
{
    public class MockIncomeRepository : IIncomeRepository
    {
        private List<Income> _Incomes;
        public MockIncomeRepository() {
            _Incomes = new List<Income>()
            { 
                new Income()
                {
                    Id = 1,
                    From = Enums.IncomeFrom.Salary,
                    Money = 15000,
                    CreateAt = DateTime.Now,
                    Remark = "八月份工资"
                },
                new Income()
                {
                    Id = 2,
                    From = Enums.IncomeFrom.Salary,
                    Money = 14780,
                    CreateAt = DateTime.Now.AddMonths(-1),
                    Remark = "七月月份工资"
                },
                new Income()
                {
                    Id = 3,
                    From = Enums.IncomeFrom.Bywork,
                    Money = 1240,
                    CreateAt = DateTime.Now.AddMonths(-1),
                    Remark = "七月月份兼职"
                },
            };
        }

        public Income Add(Income income)
        {
            _Incomes.Add(income);
            return income;
        }

        public Income Delete(int? id)
        {
            var income = _Incomes.FirstOrDefault(x => x.Id == id);
            if (income != null)
            {
                _Incomes.Remove(income);
            }
            return income;
        }

        public Income Get(int? id)
        {
            return _Incomes.FirstOrDefault(x => x.Id == id);
        }

        public IList<Income> GetIncomes()
        {
            return _Incomes;
        }

        public bool IsExist(Income t)
        {
            return _Incomes.FirstOrDefault(x => x.Id == t.Id) != null;
        }

        public Income Update(Income income)
        {
            var inc = _Incomes.FirstOrDefault(x => x.Id == income.Id);
            if (inc != null) { 
                inc.From = income.From;
                inc.Remark = income.Remark;
                inc.Money = income.Money;
                inc.CreateAt = income.CreateAt;
            }

            return inc;
        }
    }
}
