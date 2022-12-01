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
                controller.Insert(editChargeWindow.ViewModel.Income);
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
                controller.Update(editChargeWindow.ViewModel.Income);
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
            foreach (var ex in tempExpends)
            {
                if (ex.IsSelected)
                {
                    controller.Delete(ex);
                }
            }
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
            var datatable = controller.Query(Fliter);
            var temp = controller.ToObservableList(datatable);
            Incomes.Clear();
            foreach (var ex in temp)
            {
                Incomes.Add(ex);
            }
        });

        public ICommand Refresh => new RelayCommand(obj=> {
            var datatable = controller.Query(AppContext.Instacne.Username);
            var temp = controller.ToObservableList(datatable);
            Incomes.Clear();
            foreach (var ex in temp)
            {
                Incomes.Add(ex);
            }
        });

        public IncomeControlVM()
        {
            Fliter.StartDate = DateTime.Now;
            Fliter.EndDate = DateTime.Now;
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

      
    }
}
