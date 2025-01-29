using DriveCataloguizerModel.Models;

namespace DriveCataloguizerViewModel
{
    public class CatalogueViewModel
    {
        private readonly CatalogueInformation _catalogueInformation;
        public CatalogueViewModel(CatalogueInformation catalogueInformation)
        {
            _catalogueInformation = catalogueInformation;
        }

        public string Name => _catalogueInformation.Number;
        public string PersentOfFull => string.Format("{0:0.000} %", (double)_catalogueInformation.Drives.Count / (double)_catalogueInformation.Capacity * 100);
    }
}
