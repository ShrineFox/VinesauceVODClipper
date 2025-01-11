using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinesauceVODClipper
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataGridItem> _dataGridItems;
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
