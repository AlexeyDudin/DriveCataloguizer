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
        private readonly CataloguesViewModel _cataloguesViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _cataloguesViewModel = Locator.Current.GetService<ICataloguesViewModel>() as CataloguesViewModel;
            DataContext = _cataloguesViewModel;
        }

        private void TapeControlAdd_Click(object sender, RoutedEventArgs e)
        {
            _cataloguesViewModel?.AddNewCatalogue();
        }

        private void DiskControlAdd_Click(object sender, RoutedEventArgs e)
        {
            _cataloguesViewModel?.AddNewDrive();
        }

        private void TapeControlEdit_Click(object sender, RoutedEventArgs e)
        {
            _cataloguesViewModel?.EditCatalogue();
        }

        private void DiskControlEdit_Click(object sender, RoutedEventArgs e)
        {
            _cataloguesViewModel?.EditDrive();
        }

        private void NonCataloguedDrives_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _cataloguesViewModel?.SelectedDrive?.OpenExplorerWithDirectory();
        }
    }
}
