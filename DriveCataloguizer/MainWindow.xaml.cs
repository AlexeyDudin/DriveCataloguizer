using System.Windows;
using DriveCataloguizerViewModel;
using DriveCataloguizerViewModel.Interfaces;
using MahApps.Metro.Controls;
using Splat;

namespace DriveCataloguizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Locator.Current.GetService<ICataloguesViewModel>() as CataloguesViewModel;
        }

        private void TapeControlAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DiskControlAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
