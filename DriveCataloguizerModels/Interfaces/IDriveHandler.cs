using System.Collections.ObjectModel;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerModels.Interfaces
{
    public interface IDriveHandler
    {
        public ObservableCollection<DriveInformation> NonCataloguedDrives { get; }

        void Add(DriveInformation driveInformation);
        void Edit(DriveInformation driveInformation);
        void Delete(DriveInformation driveInformation);
    }
}
