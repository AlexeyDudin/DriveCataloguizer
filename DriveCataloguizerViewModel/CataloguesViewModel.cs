using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerViewModel.Interfaces;

namespace DriveCataloguizerViewModel
{
    public class CataloguesViewModel : ICataloguesViewModel, INotifyPropertyChanged
    {
        private readonly ObservableCollection<CatalogueViewModel> _catalogs;
        private CatalogueViewModel _selectedCatalogue;

        public CataloguesViewModel(ICatalogueRepository catalogueRepository)
        {
            _catalogs = new ObservableCollection<CatalogueViewModel>(catalogueRepository.Database.Local.Select(c => new CatalogueViewModel(c)).ToList());
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
