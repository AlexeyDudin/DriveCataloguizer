using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public void Add(DriveInformation driveInformation)
        {
            _driveRepository.Database.Add(driveInformation);
            _driveRepository.Commit();
        }

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
        public void Delete(DriveInformation driveInformation)
        {
            _driveRepository.Database.Delete(driveInformation);
            _driveRepository.Commit();
        }

        public void OpenExplorerDirectory(DriveInformation driveInformation)
        {
            if (driveInformation == null || string.IsNullOrEmpty(driveInformation.PathToDirectory))
                throw new ArgumentException("Ошибка! Путь к директории не указан!");
            if (!Directory.Exists(driveInformation.PathToDirectory))
                throw new ArgumentException("Ошибка! Указанный путь на данном компьютере не существует!");

            Process.Start("explorer.exe", driveInformation.PathToDirectory);
        }

        public bool IsDirectoryExist(DriveInformation driveInformation) => Directory.Exists(driveInformation.PathToDirectory);
    }
}
