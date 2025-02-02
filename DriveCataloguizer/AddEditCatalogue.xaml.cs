using System.Windows.Controls;
using DriveCataloguizerViewModel;

namespace DriveCataloguizer
{
    /// <summary>
    /// Interaction logic for AddEditCatalogue.xaml
    /// </summary>
    public partial class AddEditCatalogue : UserControl
    {
        public AddEditCatalogue()
        {
            InitializeComponent();
        }

        public AddEditCatalogue(CatalogueViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = DataContext as CatalogueViewModel;
            viewModel.SaveCatalogue();
        }
    }
}
