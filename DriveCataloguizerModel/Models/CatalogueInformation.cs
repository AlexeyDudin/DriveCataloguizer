using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DriveCataloguizerModel.Models
{
    public class CatalogueInformation : INotifyPropertyChanged
    {
        private string _number = string.Empty;
        private long _capacity = 0;
        private ObservableCollection<CatalogueToDriveInformation> _drives = new ObservableCollection<CatalogueToDriveInformation>();

        [Key]
        public long Id { get; set; }

        public string Number 
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        public long Capacity 
        { 
            get => _capacity;
            set
            {
                _capacity = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<CatalogueToDriveInformation> Drives 
        {
            get => _drives;
            set
            {
                _drives = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
