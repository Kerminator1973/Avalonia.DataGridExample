using System.ComponentModel;

namespace Avalonia.DataGridExample.Models
{
    public class Banknote : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Currency { get; set; } = null!;
        public string Denomination { get; set; } = null!;

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
