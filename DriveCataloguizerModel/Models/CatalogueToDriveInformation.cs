using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DriveCataloguizerModel.Models
{
    public class CatalogueToDriveInformation : INotifyPropertyChanged
    {
        private CatalogueInformation _catalogue;
        private DriveInformation _drive;
        private long _drivePosition;

        [Key]
        public long Id { get; set; }
        public long CatalogueId { get; set; }
        public long DriveId { get; set; }
        public virtual CatalogueInformation Catalogue
        {
            get => _catalogue;
            set
            {
                _catalogue = value;
                OnPropertyChanged();
            }
        }
        public virtual DriveInformation Drive
        {
            get => _drive;
            set
            {
                _drive = value;
                OnPropertyChanged();
            }
        }
        public long DrivePosition
        {
            get => _drivePosition;
            set
            {
                _drivePosition = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
