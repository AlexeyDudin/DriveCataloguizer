using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DriveCataloguizerModel.Models;
using DriveCataloguizerModels.Interfaces;

namespace DriveCataloguizerViewModel
{
    public class DriveViewModel : INotifyPropertyChanged
    {
        private readonly DriveInformation _driveInformation;
        private IDriveHandler _driveHandler;
        private Action _closeFlyoutAction;
        private bool _isEdit;

        public DriveViewModel(DriveInformation driveInformation, IDriveHandler driveHandler, Action closeFlyoutAction, bool isEdit = true)
        {
            _driveInformation = driveInformation;
            _driveHandler = driveHandler;
            _closeFlyoutAction = closeFlyoutAction;
            _isEdit = isEdit;
        }


        public string Name 
        {
            get => _driveInformation.MainNumber;
            set
            {
                _driveInformation.MainNumber = value;
                OnPropertyChanged();
            } 
        }

        public string SecondName
        {
            get => _driveInformation.SecondNumber;
            set
            {
                _driveInformation.SecondNumber = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _driveInformation.Description;
            set
            {
                _driveInformation.Description = value;
                OnPropertyChanged();
            }
        }

        public void SaveChanges()
        {
            if (_isEdit)
                _driveHandler.Edit(_driveInformation);
            else
                _driveHandler.Add(_driveInformation);
            _closeFlyoutAction();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
