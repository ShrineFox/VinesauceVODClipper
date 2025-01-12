using System.ComponentModel;

public class DataGridItem : INotifyPropertyChanged
{
    private string _title;
    private string _description;
    private string _path;
    private TimeSpan _startTime;
    private TimeSpan _endTime;

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public string Path
    {
        get => _path;
        set
        {
            if (_path != value)
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }
    }

    public TimeSpan StartTime
    {
        get => _startTime;
        set
        {
            if (_startTime != value)
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }
    }

    public TimeSpan EndTime
    {
        get => _endTime;
        set
        {
            if (_endTime != value)
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
