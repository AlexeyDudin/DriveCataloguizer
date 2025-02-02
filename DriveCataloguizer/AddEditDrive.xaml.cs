using System.Windows;
using System.Windows.Controls;
using DriveCataloguizerViewModel;

namespace DriveCataloguizer
{
    /// <summary>
    /// Interaction logic for AddEditDrive.xaml
    /// </summary>
    public partial class AddEditDrive : UserControl
    {
        public AddEditDrive()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as DriveViewModel;
            viewModel?.SaveChanges();
        }
    }
}
