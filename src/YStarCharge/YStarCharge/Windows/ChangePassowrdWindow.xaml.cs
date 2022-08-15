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
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// ChangePassowrdWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePassowrdWindow : Window
    {
        public ChangePassowrdWindow()
        {
            InitializeComponent();
            DataContext = new ChangePasswordVM();
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Close();
        }
    }
}
