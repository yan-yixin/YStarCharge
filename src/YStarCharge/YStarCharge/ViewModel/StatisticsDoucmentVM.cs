using SqlLib;
using SqlLib.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Controller;
using YStarCharge.Document;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public class StatisticsDoucmentVM : NotifyPropertyChanged
    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if(date == value)
                {
                    return;
                }
                date = value;
                OnPropertyChanged(this, "Date");
            }
        }

        private TimeUnit timeUnit;
        public TimeUnit TimeUnit
        {
            get
            {
                return timeUnit;
            }
            set
            {
                if (timeUnit == value)
                {
                    return;
                }
                timeUnit = value;
                OnPropertyChanged(this, "TimeUnit");
            }
        }

        private IncomeAndExpend incomeAndExpend;
        public IncomeAndExpend IncomeAndExpend
        {
            get
            {
                return incomeAndExpend;
            }
            set
            {
                if(incomeAndExpend == value)
                {
                    return;
                }
                incomeAndExpend = value;
                OnPropertyChanged(this, "IncomeAndExpend");
            }
        }

        public Grid ChartGrid { get; set; }

        public List<BaseIncomeExpend> Datas { get; private set; } = new List<BaseIncomeExpend>();

        private IncomeController incomeController = new IncomeController();
        private ExpendController expendController = new ExpendController();
        public ICommand Query => new RelayCommand(obj => {

            DataTable table;
            Datas.Clear();
            if (IncomeAndExpend == IncomeAndExpend.支出)
            {
                table = expendController.Query(timeUnit, date);
                var temp = expendController.ToList(table);

                temp.ForEach(ex => Datas.Add(ex));
            }
            else
            {
                table = incomeController.Query(timeUnit, date);
                var temp = incomeController.ToList(table);
                temp.ForEach(ex => Datas.Add(ex));
            }

            ChartUserControl cuc = new ChartUserControl(TimeUnit, Datas);
            ChartGrid.Children.Clear();
            ChartGrid.Children.Add(cuc);


        });

        public StatisticsDoucmentVM()
        {
            Date = DateTime.Now;
        }
    }
}
