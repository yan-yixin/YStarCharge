using System.Windows;
using YStarCharge.ViewModel;

namespace YStarCharge
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            viewModel.ContentGrid = contenGrid;


        }
    }
}
