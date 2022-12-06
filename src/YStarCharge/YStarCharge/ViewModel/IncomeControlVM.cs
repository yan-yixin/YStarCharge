using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YStarCharge.Common;
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

        public DataGrid DataGrid { get; set; }

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
            if (Util.Export(GetDataTable()))
            {
                MessageBox.Show("导出成功。", "提示");
            }

        });

        public ICommand Query => new RelayCommand(obj => {
            var datatable = controller.Query(Fliter);
            var temp = controller.ToObservableList(datatable);
            Incomes.Clear();
            foreach (var ex in temp)
            {
                Incomes.Add(ex);
            }

            Income income = new Income()
            {
                CreateAt = DateTime.Now,
                Channel = IncomeFrom.其他,
                Amount = Incomes.Sum(e => e.Amount),
                Remark = "总额"
            };
            Incomes.Add(income);
        });

        public ICommand Refresh => new RelayCommand(obj=> {
            var datatable = controller.Query(AppContext.Instacne.Username);
            var temp = controller.ToObservableList(datatable);
            Incomes.Clear();
            foreach (var ex in temp)
            {
                Incomes.Add(ex);
            }
            Income income = new Income()
            {
                CreateAt = DateTime.Now,
                Channel = IncomeFrom.其他,
                Amount = Incomes.Sum(e => e.Amount),
                Remark = "总额"
            };
            Incomes.Add(income);
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

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < DataGrid.Columns.Count; i++)
            {
                if (DataGrid.Columns[i].Visibility == Visibility.Visible)//只导出可见列  
                {
                    dt.Columns.Add(DataGrid.Columns[i].Header.ToString());//构建表头  
                }
            }

            for (int i = 0; i < DataGrid.Items.Count; i++)
            {
                int columnsIndex = 0;
                DataRow row = dt.NewRow();
                for (int j = 0; j < DataGrid.Columns.Count; j++)
                {
                    if (DataGrid.Columns[j].Visibility == Visibility.Visible)
                    {
                        if (DataGrid.Items[i] != null && (DataGrid.Columns[j].GetCellContent(DataGrid.Items[i]) as TextBlock) != null)//填充可见列数据  
                        {
                            row[columnsIndex] = (DataGrid.Columns[j].GetCellContent(DataGrid.Items[i]) as TextBlock).Text.ToString();
                        }
                        else row[columnsIndex] = "";

                        columnsIndex++;
                    }
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
