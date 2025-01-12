using System.ComponentModel;

public class DataGridItem : INotifyPropertyChanged
{
    private string title;
    private string description;
    private string path;
    private TimeSpan startTime;
    private TimeSpan endTime;

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public string Path
    {
        get => path;
        set
        {
            if (path != value)
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }
    }

    public TimeSpan StartTime
    {
        get => startTime;
        set
        {
            if (startTime != value)
            {
                startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }
    }

    public TimeSpan EndTime
    {
        get => endTime;
        set
        {
            if (endTime != value)
            {
                endTime = value;
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