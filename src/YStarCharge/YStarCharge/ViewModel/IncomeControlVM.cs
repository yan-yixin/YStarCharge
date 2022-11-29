using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Controller;
using YStarCharge.Model;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    public sealed class IncomeControlVM:NotifyPropertyChanged, ICommandVM
    {
        private IncomeController controller = new IncomeController();

        public ObservableCollection<Income> Incomes { get; set; } = new ObservableCollection<Income>();

        public IncomeFliter Fliter { get; set; } = new IncomeFliter();

        public ICommand Add => new RelayCommand(obj => {
            EditIncomeWindow editChargeWindow = new EditIncomeWindow();
            editChargeWindow.ViewModel.Title = "新增";
            if (editChargeWindow.ShowDialog() == true)
            {
                editChargeWindow.ViewModel.Income.Id = Incomes.Count + 1;
                editChargeWindow.ViewModel.Income.Username = AppContext.Instacne.Username;
                Incomes.Add(editChargeWindow.ViewModel.Income);
                controller.Add<Income>();
            }
        });

        public ICommand Edit => new RelayCommand(obj =>
        {
            var expend = Incomes.FirstOrDefault(e => e.IsSelected);
            if (expend == null)
            {
                MessageBox.Show("请先选中一条数据。", "提示");
                return;
            }
            EditIncomeWindow editChargeWindow = new EditIncomeWindow();
            editChargeWindow.ViewModel.Title = "编辑";
            var temp = expend;
            editChargeWindow.ViewModel.Income = new Income()
            {
                Id = temp.Id,
                Amount = temp.Amount,
                Channel = temp.Channel,
                Remark = temp.Remark,
                CreateAt = temp.CreateAt,
                Username = AppContext.Instacne.Username
            };
            if (editChargeWindow.ShowDialog() == true)
            {
                int index = Incomes.IndexOf(expend);

                Incomes.RemoveAt(index);
                editChargeWindow.ViewModel.Income.IsSelected = true;
                Incomes.Insert(index, editChargeWindow.ViewModel.Income);
                controller.Update<Income>();
            }
        });

        public ICommand Delete => new RelayCommand(obj =>
        {
            MessageBoxResult result = MessageBox.Show("确定要删除记录", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            //无法直接删除，因为会删除不干净
            var tempExpends = Incomes.ToList();
            tempExpends.RemoveAll(te => te.IsSelected);
            Incomes.Clear();
            foreach (var ex in tempExpends)
            {
                Incomes.Add(ex);
            }
        });

        public ICommand Export => new RelayCommand(obj => {
            MessageBox.Show("导出数据");

        });

        public ICommand Query => new RelayCommand(obj => {
            List<Income> tempIncomes = Incomes.ToList();
            IEnumerable<Income> result = tempIncomes.Where(e => e.CreateAt >= Fliter.StartDate && e.CreateAt <= Fliter.EndDate).
            Where(ex => ex.Amount >= Fliter.MinMoney && ex.Amount <= Fliter.MaxMoney && ex.Channel == Fliter.From);
            if (result != null)
            {
                Incomes.Clear();
                result.ToList().ForEach(r => Incomes.Add(r));
            }

        });

        public ICommand Refresh => new RelayCommand(obj=> {

            RefreshData();
        });

        public IncomeControlVM()
        {
            Fliter.StartDate = DateTime.Now;
            Fliter.EndDate = DateTime.Now;
            RefreshData();
        }

        public void SetCheckBoxChecked(bool isCheck)
        {
            var tempExpends = Incomes.ToList();
            tempExpends.ForEach(te => te.IsSelected = isCheck);
            Incomes.Clear();
            foreach (var ex in tempExpends)
            {
                Incomes.Add(ex);
            }
        }

        private void RefreshData()
        {
            Income expend = new Income()
            {
                Id = 1,
                CreateAt = DateTime.Now.Date,
                Amount = 15323.45f,
                Channel = IncomeFrom.工资

            };
            Income expend1 = new Income()
            {
                Id = 2,
                CreateAt = DateTime.Now.Date,
                Amount = 1532,
                Channel = IncomeFrom.副业,
                Remark = "忘了怎么花的"
            };
            Income expend2 = new Income()
            {
                Id = 3,
                CreateAt = DateTime.Now.Date,
                Amount = 15000,
                Channel = IncomeFrom.其他,
                Remark = "忘了怎么花的"
            };
            Incomes.Add(expend);
            Incomes.Add(expend1);
            Incomes.Add(expend2);
        }
    }
}
