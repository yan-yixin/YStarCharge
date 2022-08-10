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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YStarCharge.Document
{
    /// <summary>
    /// ExpendAndIncomeDocument.xaml 的交互逻辑
    /// </summary>
    public partial class ExpendAndIncomeDocument : UserControl
    {
        private readonly Color SelectedColor = Color.FromRgb(91, 150, 219);
        private readonly Color DefaultColor = Color.FromRgb(177,189,203);
        private ExpendUserControl expendUserControl = new ExpendUserControl();
        public ExpendAndIncomeDocument()
        {
            InitializeComponent();
        }

        private void ExpendButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                button.Foreground = new SolidColorBrush(SelectedColor);
            }
            incomeButton.Foreground = new SolidColorBrush(DefaultColor);

            if (contentGrid.Children.Contains(expendUserControl))
            {
                return;
            }
            contentGrid.Children.Clear();
            contentGrid.Children.Add(expendUserControl);
        }

        private void IncomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                button.Foreground = new SolidColorBrush(SelectedColor);
            }
            expendButton.Foreground = new SolidColorBrush(DefaultColor);

        }
    }
}
