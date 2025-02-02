using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerModel.Models;
using DriveCataloguizerModels.Interfaces;

namespace DriveCataloguizerModels.Handlers
{
    public class CatalogueHandler : ICatalogueHandler, INotifyPropertyChanged
    {
        private readonly ICatalogueRepository _catalogueRepository;
        public CatalogueHandler(ICatalogueRepository catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
            _catalogueRepository.Database.Local.CollectionChanged += Local_CollectionChanged;
        }

        private void Local_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Catalogues));
        }

        public ReadOnlyObservableCollection<CatalogueInformation> Catalogues => new ReadOnlyObservableCollection<CatalogueInformation>(_catalogueRepository.Database.Local);

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public void AddCatalogue(CatalogueInformation catalogue)
        {
            _catalogueRepository.Database.Add(catalogue);
            _catalogueRepository.Commit();
        }

        public void DeleteCatalogue(CatalogueInformation catalogue)
        {
            _catalogueRepository.Database.Delete(catalogue);
            _catalogueRepository.Commit();
        }

        public void EditCatalogue(CatalogueInformation catalogue)
        {
            var fileInDb = _catalogueRepository.Database.Where(c => c.Id == catalogue.Id).FirstOrDefault();
            if (fileInDb != null)
            {
                fileInDb.Number = catalogue.Number;
                fileInDb.Capacity = catalogue.Capacity;
            }
            _catalogueRepository.Commit();
        }
    }
}
