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

namespace YStarCharge.Document
{
    /// <summary>
    /// ExpendAndIncomeDocument.xaml 的交互逻辑
    /// </summary>
    public partial class ExpendAndIncomeDocument : UserControl
    { 
        public ExpendAndIncomeDocument()
        {
            InitializeComponent();

            //ExpendUserControl euc = new ExpendUserControl();
            //contentGrid.Children.Clear();
            //contentGrid.Children.Add(euc);

            IncomeUserControl iuc = new IncomeUserControl();
            contentGrid.Children.Clear();
            contentGrid.Children.Add(iuc);
        }
    }
}
