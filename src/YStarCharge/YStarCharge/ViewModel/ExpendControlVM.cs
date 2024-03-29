﻿using System;
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
using YStarCharge.Model;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    public sealed class ExpendControlVM: NotifyPropertyChanged
    {
        public ObservableCollection<Expend> Expends { get; set; } = new ObservableCollection<Expend>();

        public DataGrid DataGrid { get; set; }

        public ExpendFliter Fliter { get; set; } = new ExpendFliter();

        public ICommand Add => new RelayCommand(obj => {
            EditExpendWindow editChargeWindow = new EditExpendWindow();
            editChargeWindow.ViewModel.Title = "新增";
            if (editChargeWindow.ShowDialog() == true)
            {
                editChargeWindow.ViewModel.Expend.Number = Expends.Count + 1;
                Expends.Add(editChargeWindow.ViewModel.Expend);
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
                Number = temp.Number,
                Money = temp.Money,
                To = temp.To,
                Remark = temp.Remark,
                CreateAt = temp.CreateAt 
            };
            if (editChargeWindow.ShowDialog() == true)
            {
                int index = Expends.IndexOf(expend);

                Expends.RemoveAt(index);
                editChargeWindow.ViewModel.Expend.IsSelected = true;
                Expends.Insert(index, editChargeWindow.ViewModel.Expend);
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
            MessageBox.Show($"金额范围：{Fliter.MinMoney}-{Fliter.MaxMoney},日期：{Fliter.StartDate}-{Fliter.EndDate},用于：{Fliter.To}");
            
        });

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
