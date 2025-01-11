namespace VinesauceVODClipper
{
    public class DataGridItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Path { get; set; } = "";
        public TimeSpan StartTime { get; set; } = new TimeSpan(hours: 0, minutes: 0, seconds: 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(hours: 0, minutes: 0, seconds: 0);
    }
}