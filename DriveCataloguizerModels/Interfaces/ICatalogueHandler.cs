using System.Collections.ObjectModel;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerModels.Interfaces
{
    public interface ICatalogueHandler
    {
        public ReadOnlyObservableCollection<CatalogueInformation> Catalogues { get; }

        public void AddCatalogue(CatalogueInformation catalogue);
        public void EditCatalogue(CatalogueInformation catalogue);
        public void DeleteCatalogue(CatalogueInformation catalogue);
    }
}
