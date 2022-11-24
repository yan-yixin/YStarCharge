using System.Windows;
using YStarCharge.ViewModel;

namespace YStarCharge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM viewModel;
        public MainWindow()
        {
            InitializeComponent();

            
            viewModel = new MainWindowVM();
            DataContext = viewModel;
            viewModel.ContentGrid = contenGrid;

            viewModel.WindowClose += ViewModel_WindowClose;
        }

        private void ViewModel_WindowClose(object sender, System.EventArgs e)
        {
            Close();
        }

    }
}
