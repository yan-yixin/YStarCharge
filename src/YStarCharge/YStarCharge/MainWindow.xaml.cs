using System.Windows;
using YStarCharge.Windows;

namespace YStarCharge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditChargeWindow addChargeWindow = new EditChargeWindow();
            addChargeWindow.ShowDialog();
        }
    }
}
