using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShrineFox.IO;
using System.IO;
using VinesauceVODClipper.Controls;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace VinesauceVODClipper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string ffmpegPath = "";
        private readonly ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            this.viewModel = new ViewModel()
            {
                DataGridItems = new ObservableCollection<DataGridItem>() { new DataGridItem() {  Title = "Test lol", Path = @"C:\Path\To\FullVOD.mp4" } },
            };
            this.DataContext = this.viewModel;
            ffmpegPath = System.IO.Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");

            // Subscribe to the ButtonClicked event of the UserControl
            OutputDirBrowseField.ButtonClicked += OutputDirBrowseField_ButtonClicked;
        }

        private void OutputDirBrowseField_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is BrowseField control)
            {
                var selectedDir = WinFormsDialogs.SelectFolder("Choose Clips Output Folder", Exe.Directory());
                if (Directory.Exists(selectedDir))
                {
                    control.Text = selectedDir;
                }
            }
        }

        private void VideoGridBrowseField_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is BrowseField control)
            {
                var dgi = (DataGridItem)control.DataContext;

                var selectedFiles = WinFormsDialogs.SelectFile("Pick matching raw VOD video file");
                if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
                {
                    dgi.Path = selectedFiles.First();
                    control.Text = dgi.Path;
                }
            }
        }

        private void ImportList_Click(object sender, EventArgs e)
        {
            var selectedFiles = WinFormsDialogs.SelectFile("Choose .txt with Timestamps", false, new string[] { "Text Document (.txt)" });
            if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
            {
                ImportTxtFile(selectedFiles.First());
            }
        }

        private string TimestampStringToHourFormat(string timeStamp)
        {
            if (timeStamp.Split(':').Length == 2)
            {
                // Add hours to timestamp if missing
                return "00:" + timeStamp;
            }
            return timeStamp;
        }

        private void ImportTxtFile(string txtPath)
        {
            // Exit early if the user doesn't want to overwrite video list
            if (viewModel.DataGridItems.Count > 0 && !WinFormsDialogs.ShowMessageBox(
                "Overwrite Video List Form", "Changing the input text file will reset the current video list. " +
                "Do you want to continue?", MessageBoxButtons.YesNo))
            {
                return;
            }

            var txtLines = File.ReadAllLines(txtPath);
            IList<DataGridItem> videoList = new List<DataGridItem>();

            // Create new video list
            for (int i = 0; i < txtLines.Length; i++)
            {
                var splitLine = txtLines[i].Trim().Split(' ');

                if (splitLine.Length < 3)
                    Output.Log($"Syntax error on line {i + 1}: Missing timestamp?\n\t{txtLines[i]}", ConsoleColor.Yellow);
                else
                {
                    DataGridItem video = new DataGridItem();

                    // Attempt to get timestamps from .txt line
                    string startTime = TimestampStringToHourFormat(splitLine[splitLine.Length - 2]);
                    try
                    {
                        video.StartTime = TimeSpan.Parse(startTime);
                    }
                    catch
                    {
                        Output.Log($"Syntax error on line {i + 1}: Invalid Start Time timestamp: \"{startTime}\"" +
                            $"\nFormat must be hh:mm:ss", ConsoleColor.Yellow);
                    }
                    string endTime = TimestampStringToHourFormat(splitLine.Last());
                    try
                    {
                        video.EndTime = TimeSpan.Parse(endTime);
                    }
                    catch
                    {
                        Output.Log($"Syntax error on line {i + 1}: Invalid End Time timestamp: \"{endTime}\"" +
                            $"\nFormat must be hh:mm:ss", ConsoleColor.Yellow);
                    }

                    // Join all strings except the last two timestamps to create Title
                    video.Title = string.Join(" ", splitLine, 0, splitLine.Length - 2);
                    videoList.Add(video);
                }
            }

            viewModel.DataGridItems.Clear();
            viewModel.DataGridItems = new ObservableCollection<DataGridItem>(videoList.Copy());
            Output.Log($"Done reading {videoList.Count} entries from file:\n\t{txtPath}", ConsoleColor.Green);
        }
    }
}