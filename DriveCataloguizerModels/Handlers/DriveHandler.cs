using System.Collections.ObjectModel;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerModel.Models;
using DriveCataloguizerModels.Interfaces;

namespace DriveCataloguizerModels.Handlers
{
    public class DriveHandler : IDriveHandler
    {
        private readonly IDriveRepository _driveRepository;
        public DriveHandler(IDriveRepository driveRepository) => _driveRepository = driveRepository;

        public ObservableCollection<DriveInformation> NonCataloguedDrives => _driveRepository.Database.Where(d => d.CatalogueToDrive == null);

        public void Add(DriveInformation driveInformation) => _driveRepository.Database.Add(driveInformation);

        public void Edit(DriveInformation driveInformation)
        {
            var driveInRepo = _driveRepository.Database.Where(d => d.Id == driveInformation.Id).FirstOrDefault();
            if (driveInRepo == null)
                return;
            driveInRepo.CatalogueToDrive = driveInformation.CatalogueToDrive;
            driveInRepo.Description = driveInformation.Description;
            driveInRepo.DriveStatus = driveInformation.DriveStatus;
            driveInRepo.DriveType = driveInformation.DriveType;
            driveInRepo.MainNumber = driveInformation.MainNumber;
            driveInRepo.PathToDirectory = driveInformation.PathToDirectory;
            driveInRepo.SecondNumber = driveInformation.SecondNumber;
            _driveRepository.Commit();
        }
        public void Delete(DriveInformation driveInformation) => _driveRepository.Database.Delete(driveInformation);
    }
}
