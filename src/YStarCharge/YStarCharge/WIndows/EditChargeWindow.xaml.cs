using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YStarCharge.Windows
{
    /// <summary>
    /// AddChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditChargeWindow : Window
    {
        public EditChargeWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DragThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            double nTop = e.VerticalChange;
            double nLeft = e.HorizontalChange;

            Top += nTop;
            Left += nLeft;
        }
    }
}
