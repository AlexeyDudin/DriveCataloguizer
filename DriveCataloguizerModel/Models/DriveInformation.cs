using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using DriveCataloguizerCommon.Enums;

namespace DriveCataloguizerModel.Models
{
    public class DriveInformation : INotifyPropertyChanged
    {
        private string _mainNumber;
        private string _secondNumber;
        private DriveType _driveType;
        private DriveStatus _driveStatus;
        private string _pathToDirectory;
        private string _description;
        private CatalogueToDriveInformation? _catalogueToDrive;

        [Key]
        public long Id { get; set; }
        public string MainNumber 
        { 
            get => _mainNumber;
            set
            {
                _mainNumber = value;
                OnPropertyChanged();
            }
        }
        public string SecondNumber 
        { 
            get => _secondNumber;
            set
            {
                _secondNumber = value;
                OnPropertyChanged();
            }
        }
        public DriveType DriveType 
        { 
            get => _driveType;
            set
            {
                _driveType = value;
                OnPropertyChanged();
            }
        }

        public DriveStatus DriveStatus
        { 
            get => _driveStatus;
            set
            {
                _driveStatus = value;
                OnPropertyChanged();
            }
        }

        public string PathToDirectory
        {
            get => _pathToDirectory;
            set
            {
                _pathToDirectory = value;
                OnPropertyChanged();
            }
        }

        public virtual CatalogueToDriveInformation? CatalogueToDrive 
        {
            get => _catalogueToDrive;
            set
            {
                _catalogueToDrive = value;
                OnPropertyChanged();
            }
        }

        public string Description 
        { 
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
