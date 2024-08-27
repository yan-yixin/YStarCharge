using System;
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
using System.Windows.Shapes;
using YStarCharge.Model;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// ChangePassowrdWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePassowrdWindow : Window
    {
        public ChangePasswordVM ViewModel { get; }

        public ChangePassowrdWindow()
        {
            InitializeComponent();
            ViewModel = new ChangePasswordVM(); 
            DataContext = ViewModel;
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == false)
            {
                DialogResult = true;
                Close();
            }
            
        }
    }
}
