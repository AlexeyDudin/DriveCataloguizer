using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerViewModel
{
    public class CataloguesViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<CatalogueViewModel> _catalogs;
        private CatalogueViewModel _selectedCatalogue;

        public CataloguesViewModel(ObservableCollection<CatalogueInformation> catalogs)
        {
            _catalogs = new ObservableCollection<CatalogueViewModel>(catalogs.Select(c => new CatalogueViewModel(c)).ToList());
        }

        public ObservableCollection<CatalogueViewModel> Catalogs => _catalogs;

        public CatalogueViewModel SelectedCatalogue
        {
            get => _selectedCatalogue;
            set
            {
                _selectedCatalogue = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
