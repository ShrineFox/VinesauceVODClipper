using ShrineFox.IO;

namespace VinesauceVODClipper
{
    public partial class MainForm : Form
    {
        public List<Video> videoList = new List<Video>();

        public MainForm()
        {
            InitializeComponent();
            // Set up error logging
            Output.LogPath = "log.txt";
            Output.LogControl = rtb_Log;
            Output.Logging = true;
        }

        // Update form to reflect changes from input .txt file
        private void Txt_Changed(object sender, EventArgs e)
        {
            string txtPath = txt_TxtFile.Text;

            if (File.Exists(txtPath))
            {
                // Exit early if the user doesn't want to overwrite video list
                if (videoList.Count > 0 && !WinFormsDialogs.ShowMessageBox(
                    "Overwrite Video List Form","Changing the input text file will reset the video list below. " +
                    "Do you want to continue?", MessageBoxButtons.YesNo))
                {
                    return;
                }

                // Remove existing entries from video list
                videoList.Clear();

                var txtLines = File.ReadAllLines(txtPath);

                // Create new video list
                for (int i = 0; i < txtLines.Length; i++)
                {
                    var splitLine = txtLines[i].Trim().Split(' ');

                    if (splitLine.Length < 3)
                        Output.Log($"Syntax error on line {i + 1}: Missing timestamp?\r\n\t{txtLines[i]}", ConsoleColor.Yellow);
                    else
                    {
                        Video video = new Video();

                        // Attempt to get timestamps from .txt line
                        string startTime = TimestampStringToHourFormat(splitLine[splitLine.Length - 2]);
                        try
                        {
                            video.StartTime = TimeSpan.Parse(startTime);
                        }
                        catch
                        {
                            Output.Log($"Syntax error on line {i + 1}: Invalid Start Time timestamp: \"{startTime}\"" +
                                $"\r\nFormat must be hh:mm:ss", ConsoleColor.Yellow);
                        }
                        string endTime = TimestampStringToHourFormat(splitLine.Last());
                        try
                        {
                            video.EndTime = TimeSpan.Parse(endTime);
                        }
                        catch
                        {
                            Output.Log($"Syntax error on line {i + 1}: Invalid End Time timestamp: \"{endTime}\"" +
                                $"\r\nFormat must be hh:mm:ss", ConsoleColor.Yellow);
                        }

                        // Join all strings except the last two timestamps to create Title
                        video.Title = string.Join(" ", splitLine, 0, splitLine.Length - 2);
                        videoList.Add(video);
                    }
                }

                // Update form with video list
                if (videoList.Count > 0)
                {
                    CreateVideoListControls();
                }

                Output.Log($"Done reading {videoList.Count} entries from file:\r\n\t{txtPath}", ConsoleColor.Green);
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

        private void CreateVideoListControls()
        {
            var headerFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

            TableLayoutPanel tlp_VideoList = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoSize = true,
                AutoScroll = false,
                Size = new Size(762, 22),
                Location = new Point(0, 0),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Name = "tlp_VideoList"
            };
            // Create TLP layout
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            // Create header row
            tlp_VideoList.RowStyles.Add(new RowStyle());
            Label lbl_VideoTitleHeader = new Label() { Text = "Video Title", Font = headerFont };
            Label lbl_VideoPathHeader = new Label() { Text = "Video Path", Font = headerFont };
            Label lbl_StartTimeHeader = new Label() { Text = "Start Time", Font = headerFont };
            Label lbl_EndTimeHeader = new Label() { Text = "End Time", Font = headerFont };
            tlp_VideoList.Controls.Add(lbl_VideoTitleHeader, 0, 0);
            tlp_VideoList.Controls.Add(lbl_VideoPathHeader, 1, 0);
            tlp_VideoList.Controls.Add(lbl_StartTimeHeader, 3, 0);
            tlp_VideoList.Controls.Add(lbl_EndTimeHeader, 4, 0);
            // Populate with video titles and timestamps from .txt
            for (int i = 0; i < videoList.Count; i++)
            {
                tlp_VideoList.RowStyles.Add(new RowStyle());
                Label lbl_VideoTitle = new Label() { Text = videoList[i].Title, Dock = DockStyle.Fill, Name = $"lbl_VideoTitle_{i}" };
                TextBox txt_VideoPath = new TextBox() { Text = "", Dock = DockStyle.Fill, Name = $"txt_VideoPath_{i}" };
                Button btn_VideoPath = new Button() { Text = "...", Dock = DockStyle.Fill, Name = $"btn_VideoPath_{i}" };
                TextBox txt_StartTime = new TextBox() { Text = videoList[i].StartTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_StartTime_{i}" };
                TextBox txt_EndTime = new TextBox() { Text = videoList[i].EndTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_EndTime_{i}" };
                tlp_VideoList.Controls.Add(lbl_VideoTitle, 0, i + 1);
                tlp_VideoList.Controls.Add(txt_VideoPath, 1, i + 1);
                tlp_VideoList.Controls.Add(btn_VideoPath, 2, i + 1);
                tlp_VideoList.Controls.Add(txt_StartTime, 3, i + 1);
                tlp_VideoList.Controls.Add(txt_EndTime, 4, i + 1);
            }
            // Add TLP to form (remove existing)
            pnl_VideoList.Controls.Clear();
            pnl_VideoList.Controls.Add(tlp_VideoList);
        }

        // Browse for .txt file
        private void TxtBtn_Click(object sender, EventArgs e)
        {
            var selectedFiles = WinFormsDialogs.SelectFile("Choose .txt with Timestamps", false, new string[] { "Text Document (.txt)" });
            if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
            {
                txt_TxtFile.Text = selectedFiles.First();
            }
        }

        // Browse for output directory
        private void OutputDirBtn_Click(object sender, EventArgs e)
        {

        }

        // Create clips from selected videos using ffmpeg
        private void CreateClipsBtn_Click(object sender, EventArgs e)
        {

        }
    }

    public class Video
    {
        public string Title { get; set; } = "";
        public string Path { get; set; } = "";
        public TimeSpan StartTime { get; set; } = new TimeSpan(hours: 0, minutes: 0, seconds: 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(hours: 0, minutes: 0, seconds: 0);
    }
}
