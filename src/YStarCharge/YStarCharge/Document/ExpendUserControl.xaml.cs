﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YStarCharge.Model;
using YStarCharge.ViewModel;

namespace YStarCharge.Document
{
    /// <summary>
    /// ExpendUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExpendUserControl : UserControl
    {
        private ExpendUserControlViewModel viewModel;
        public ExpendUserControl()
        {
            InitializeComponent();
            viewModel = new ExpendUserControlViewModel();
            DataContext = viewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Expend expend = new Expend()
            {
                Number = 1,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 153.45f,
                Project = Project.餐饮,

            };
            Expend expend1 = new Expend()
            {
                Number = 2,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.其他,
                Remark ="忘了怎么花的"
            };
            Expend expend2 = new Expend()
            {
                Number = 3,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.旅游,
                Remark = "忘了怎么花的"
            };
            Expend expend3 = new Expend()
            {
                IsSelected = true,
                Number = 4,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.购物,
                Remark = "忘了怎么花的"
            };
            viewModel.Expends.Add(expend);
            viewModel.Expends.Add(expend1);
            viewModel.Expends.Add(expend2);
            viewModel.Expends.Add(expend3);
        }


        private void AllSelectCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetCheckBoxChecked(true);
        }

        private void AllSelectCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckBoxChecked(false);
        }

        private void SetCheckBoxChecked(bool isCheck)
        {
            var tempExpends = viewModel.Expends.ToList();
            tempExpends.ForEach(te => te.IsSelected = isCheck);
            viewModel.Expends.Clear();
            foreach (var ex in tempExpends)
            {
                viewModel.Expends.Add(ex);
            }
        }
    }
}