using System.Windows;
using WPF_FINAL.ViewModel; // Импорт правильного пространства имен

namespace WPF_FINAL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Привязка DataContext к MainViewModel
            DataContext = new MainViewModel();
        }
    }
}