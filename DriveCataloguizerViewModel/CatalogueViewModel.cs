using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerModel.Models;
using DriveCataloguizerModels.Interfaces;

namespace DriveCataloguizerViewModel
{
    public class CatalogueViewModel : INotifyPropertyChanged
    {
        private readonly CatalogueInformation _catalogueInformation;
        private readonly ICatalogueHandler _catalogueHandler;
        private bool _isEdit;
        private ICollectionView _drivesCollectionView;
        private Action _closeFlyoutAction;
        private string _searchString = string.Empty;
        public CatalogueViewModel(CatalogueInformation catalogueInformation, ICatalogueHandler catalogueHandler, Action closeFlyoutAction, bool isEdit = true)
        {
            _isEdit = isEdit;
            _catalogueInformation = catalogueInformation;
            _catalogueHandler = catalogueHandler;
            _closeFlyoutAction = closeFlyoutAction;
            DrivesView = CollectionViewSource.GetDefaultView(_catalogueInformation.Drives);
        }

        public string Name
        {
            get => _catalogueInformation.Number;
            set
            {
                _catalogueInformation.Number = value;
                OnPropertyChanged();
            }
        }

        public long Capacity
        {
            get => _catalogueInformation.Capacity;
            set
            {
                _catalogueInformation.Capacity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PersentOfFull));
            }
        }

        public ObservableCollection<CatalogueToDriveInformation> Drives => _catalogueInformation.Drives;

        public ICollectionView DrivesView
        {
            get => _drivesCollectionView;
            private set
            {
                _drivesCollectionView = value;
                if (DrivesView != null)
                    DrivesView.Filter = FilterDrives;
                OnPropertyChanged();
            }
        }

        private bool FilterDrives(object obj)
        {
            return obj is DriveInformation drives && (string.IsNullOrEmpty(SearchString) ||
                                           drives.MainNumber.Contains(SearchString) ||
                                           drives.SecondNumber.Contains(SearchString) ||
                                           drives.Description.Contains(SearchString));
        }

        public long DrivesCount => _catalogueInformation.Drives.Count;

        public string PersentOfFull => string.Format("{0:0.000} % ({1}/{2})", (double)_catalogueInformation.Drives.Count / (double)_catalogueInformation.Capacity * 100, DrivesCount, Capacity);

        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                if (DrivesView != null)
                    DrivesView.Refresh();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SaveCatalogue()
        {
            if (_isEdit)
                _catalogueHandler.EditCatalogue(_catalogueInformation);
            else
                _catalogueHandler.AddCatalogue(_catalogueInformation);
            _closeFlyoutAction();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
