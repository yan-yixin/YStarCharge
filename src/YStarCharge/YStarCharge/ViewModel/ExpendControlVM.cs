using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public sealed class ExpendControlVM: NotifyPropertyChanged
    {
        private ExpendController controller = new ExpendController();
        public ObservableCollection<Expend> Expends { get; set; } = new ObservableCollection<Expend>();

        public DataGrid DataGrid { get; set; }

        public ExpendFliter Fliter { get; set; } = new ExpendFliter();

        public ICommand Add => new RelayCommand(obj => {
            EditExpendWindow editChargeWindow = new EditExpendWindow();
            editChargeWindow.ViewModel.Title = "新增";
            if (editChargeWindow.ShowDialog() == true)
            {
                editChargeWindow.ViewModel.Expend.Id = Expends.Count + 1;
                editChargeWindow.ViewModel.Expend.Username = AppContext.Instacne.Username;
                Expends.Add(editChargeWindow.ViewModel.Expend);

                controller.Insert(editChargeWindow.ViewModel.Expend);
            }
        });

        public ICommand Edit => new RelayCommand(obj =>
        {
            var expend = Expends.FirstOrDefault(e=>e.IsSelected);
            if(expend == null)
            {
                MessageBox.Show("请先选中一条数据。", "提示");
                return;
            }
            EditExpendWindow editChargeWindow = new EditExpendWindow();
            editChargeWindow.ViewModel.Title = "编辑";
            var temp = expend;
            editChargeWindow.ViewModel.Expend = new Expend() { 
                Id = temp.Id,
                Amount = temp.Amount,
                Direction = temp.Direction,
                Remark = temp.Remark,
                CreateAt = temp.CreateAt.Date,
                Username = AppContext.Instacne.Username
            };
            if (editChargeWindow.ShowDialog() == true)
            {
                int index = Expends.IndexOf(expend);

                Expends.RemoveAt(index);
                editChargeWindow.ViewModel.Expend.IsSelected = true;
                Expends.Insert(index, editChargeWindow.ViewModel.Expend);
                controller.Update(editChargeWindow.ViewModel.Expend);
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
            var tempExpends = Expends.ToList();

            foreach (var ex in tempExpends)
            {
                if (ex.IsSelected)
                {
                    controller.Delete(ex);
                }
            }
            //重新数据查询
            tempExpends.RemoveAll(te =>te.IsSelected);
            Expends.Clear();
            foreach(var ex in tempExpends)
            {
                Expends.Add(ex);
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
            var temp  = controller.ToList(datatable);
            Expends.Clear();
            foreach (var ex in temp)
            {
                Expends.Add(ex);
            }
        });

        public ExpendControlVM()
        {
            Fliter.StartDate = DateTime.Now;
            Fliter.EndDate = DateTime.Now;
        }

        public void SetCheckBoxChecked(bool isCheck)
        {
            var tempExpends = Expends.ToList();
            tempExpends.ForEach(te => te.IsSelected = isCheck);
            Expends.Clear();
            foreach (var ex in tempExpends)
            {
                Expends.Add(ex);
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
