using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DriveCataloguizerViewModel;

namespace DriveCataloguizer
{
    /// <summary>
    /// Interaction logic for AddEditDrive.xaml
    /// </summary>
    public partial class AddEditDrive : System.Windows.Controls.UserControl
    {
        private FolderBrowserDialog _openFolderDialog;
        public AddEditDrive()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as DriveViewModel;
            viewModel?.SaveChanges();
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (_openFolderDialog == null)
            {
                _openFolderDialog = new FolderBrowserDialog();
                _openFolderDialog.AutoUpgradeEnabled = true;
                _openFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
                _openFolderDialog.ShowNewFolderButton = true;
            }
            if (_openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var viewModel = DataContext as DriveViewModel;
                if (viewModel != null)
                    viewModel.PathToDirectory = _openFolderDialog.SelectedPath;
            }
        }
    }
}
