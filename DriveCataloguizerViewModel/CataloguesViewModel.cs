using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DriveCataloguizerModel.Models;
using DriveCataloguizerModels.Interfaces;
using DriveCataloguizerViewModel.Interfaces;
using System.Windows.Data;
using System;
using DriveCataloguizerModels.Handlers;

namespace DriveCataloguizerViewModel
{
    public class CataloguesViewModel : ICataloguesViewModel, INotifyPropertyChanged
    {
        //private ObservableCollection<CatalogueViewModel> _catalogs;
        private CatalogueViewModel _selectedCatalogue;
        private bool _isAddCatalogueOpen = false;
        private bool _isAddDriveOpen = false;
        private ICatalogueHandler _catalogueHandler;
        private IDriveHandler _driveHandler;
        private string _searchString;
        private ICollectionView _catalogs;
        private ICollectionView _nonCataloguedDrives;
        private DriveViewModel _selectedDrive;

        public CataloguesViewModel(ICatalogueHandler catalogueHandler, IDriveHandler driveHandler)
        {
            _catalogueHandler = catalogueHandler;
            _driveHandler = driveHandler;
            UpdateCatalogues();
            UpdateDrives();
        }

        private void UpdateDrives()
        {
            NonCataloguedDrives = CollectionViewSource.GetDefaultView(new ObservableCollection<DriveViewModel>(_driveHandler.NonCataloguedDrives.Select(c => new DriveViewModel(c, _driveHandler, () => IsAddDriveOpen = false, true)).ToList()));
            NonCataloguedDrives.Filter = DrivesFilter;
        }

        private bool DrivesFilter(object obj)
        {
            return obj is DriveViewModel driveViewModel && (string.IsNullOrEmpty(SearchString) ||
                                         driveViewModel.Name.Contains(SearchString) ||
                                         driveViewModel.SecondName.Contains(SearchString) || 
                                         driveViewModel.Description.Contains(SearchString));
        }

        private bool Catalogs_Filter(object obj)
        {
            return obj is CatalogueViewModel catalogueViewModel && (string.IsNullOrEmpty(SearchString) ||
                                             catalogueViewModel.Drives.Any(cd => cd.Drive.MainNumber.Contains(SearchString) ||
                                                    cd.Drive.SecondNumber.Contains(SearchString) ||
                                                    cd.Drive.Description.Contains(SearchString)));
        }

        private void UpdateCatalogues()
        {
            Catalogs = CollectionViewSource.GetDefaultView(new ObservableCollection<CatalogueViewModel>(_catalogueHandler.Catalogues.Select(c => new CatalogueViewModel(c, _catalogueHandler, () => IsAddCatalogueOpen = false)).ToList()));
            Catalogs.Filter = Catalogs_Filter;
        }

        public ICollectionView Catalogs
        {
            get => _catalogs;
            set
            {
                _catalogs = value;
                OnPropertyChanged();
            }
        }

        public CatalogueViewModel SelectedCatalogue
        {
            get => _selectedCatalogue;
            set
            {
                _selectedCatalogue = value;
                SelectedCatalogue.SearchString = SearchString;
                OnPropertyChanged();
            }
        }

        public bool IsAddCatalogueOpen
        {
            get => _isAddCatalogueOpen;
            set
            {
                _isAddCatalogueOpen = value;
                if (!IsAddCatalogueOpen)
                    UpdateCatalogues();
                OnPropertyChanged();
            }
        }

        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged();
                if (SelectedCatalogue != null)
                    SelectedCatalogue.SearchString = SearchString;
                Catalogs.Refresh();
                NonCataloguedDrives.Refresh();
            }
        }

        public ICollectionView NonCataloguedDrives
        {
            get => _nonCataloguedDrives;
            set
            {
                _nonCataloguedDrives = value;
                OnPropertyChanged();
            }
        }

        public DriveViewModel SelectedDrive 
        {
            get => _selectedDrive;
            set
            {
                _selectedDrive = value;
                OnPropertyChanged();
            }
        }

        public bool IsAddDriveOpen 
        { 
            get => _isAddDriveOpen;
            set
            {
                _isAddDriveOpen = value;
                if (!IsAddDriveOpen)
                    UpdateDrives();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public void AddNewCatalogue()
        {
            SelectedCatalogue = new CatalogueViewModel(new CatalogueInformation(), _catalogueHandler, () => IsAddCatalogueOpen = false, false);
            IsAddCatalogueOpen = true;
        }

        public void EditCatalogue()
        {
            if (SelectedCatalogue != null)
                IsAddCatalogueOpen = true;
        }

        public void AddNewDrive()
        {
            SelectedDrive = new DriveViewModel(new DriveInformation(), _driveHandler, () => IsAddDriveOpen = false, false);
            IsAddDriveOpen = true;
        }

        public void EditDrive()
        {
            if (SelectedDrive != null)
                IsAddDriveOpen = true;
        }
    }
}
