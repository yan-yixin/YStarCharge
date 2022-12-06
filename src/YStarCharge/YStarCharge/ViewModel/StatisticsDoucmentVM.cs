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
        public Querier Querier { get; set; } 

        public Grid ChartGrid { get; set; }

        public List<BaseIncomeExpend> Datas { get; private set; } = new List<BaseIncomeExpend>();

        private IncomeController incomeController = new IncomeController();
        private ExpendController expendController = new ExpendController();
        public ICommand Query => new RelayCommand(obj => {

            DataTable table;
            Datas.Clear();
            if (Querier.IncomeAndExpend == IncomeAndExpend.支出)
            {
                table = expendController.Query(Querier.TimeUnit, Querier.Date);
                var temp = expendController.ToList(table);

                temp.ForEach(ex => Datas.Add(ex));
            }
            else
            {
                table = incomeController.Query(Querier.TimeUnit, Querier.Date);
                var temp = incomeController.ToList(table);
                temp.ForEach(ex => Datas.Add(ex));
            }

            ChartUserControl cuc = new ChartUserControl(Querier,Datas);
            ChartGrid.Children.Clear();
            ChartGrid.Children.Add(cuc);


        });

        public StatisticsDoucmentVM()
        {
            Querier = new Querier
            {
                Date = DateTime.Now
            };
        }
    }
}
