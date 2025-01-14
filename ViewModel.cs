using System.Collections.ObjectModel;
using System.ComponentModel;

namespace VinesauceVODClipper
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataGridItem> _dataGridItems = new ObservableCollection<DataGridItem>();
        public ObservableCollection<DataGridItem> DataGridItems
        {
            get => _dataGridItems;
            set
            {
                _dataGridItems = value;
                OnPropertyChanged(nameof(DataGridItems));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}