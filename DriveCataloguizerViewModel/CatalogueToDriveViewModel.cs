using DriveCataloguizerModel.Models;

namespace DriveCataloguizerViewModel
{
    public class CatalogueToDriveViewModel
    {
        private readonly CatalogueToDriveInformation _catalogueToDriveInformation;
        public CatalogueToDriveViewModel(CatalogueToDriveInformation catalogueToDriveInformation)
        {
            _catalogueToDriveInformation = catalogueToDriveInformation;
        }

        public long DrivePosition => _catalogueToDriveInformation.DrivePosition;

    }
}
