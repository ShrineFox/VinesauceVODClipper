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
                    "Overwrite Video List Form", "Changing the input text file will reset the video list below. " +
                    "Do you want to continue?", MessageBoxButtons.YesNo))
                {
                    return;
                }

                // Remove existing TableLayoutPanel
                pnl_VideoList.Controls.Clear();

                // Remove existing entries from video list
                videoList.Clear();

                var txtLines = File.ReadAllLines(txtPath);

                // Create new video list
                for (int i = 0; i < txtLines.Length; i++)
                {
                    var splitLine = txtLines[i].Trim().Split(' ');

                    if (splitLine.Length < 3)
                        Output.Log($"Syntax error on line {i + 1}: Missing timestamp?\n\t{txtLines[i]}", ConsoleColor.Yellow);
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

                // Update form with video list
                if (videoList.Count > 0)
                {
                    CreateVideoListControls();
                }

                Output.Log($"Done reading {videoList.Count} entries from file:\n\t{txtPath}", ConsoleColor.Green);
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

            TableLayoutPanel tlp = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoSize = true,
                AutoScroll = false,
                Size = new Size(762, 22),
                Location = new Point(0, 0),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Name = "tlp"
            };

            // Create TLP layout
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            // Create header row
            tlp.RowStyles.Add(new RowStyle());
            Label lbl_VideoTitleHeader = new Label() { Text = "Video Title", Font = headerFont };
            Label lbl_VideoPathHeader = new Label() { Text = "Video Path", Font = headerFont };
            Label lbl_StartTimeHeader = new Label() { Text = "Start Time", Font = headerFont };
            Label lbl_EndTimeHeader = new Label() { Text = "End Time", Font = headerFont };
            tlp.Controls.Add(lbl_VideoTitleHeader, 0, 0);
            tlp.Controls.Add(lbl_VideoPathHeader, 1, 0);
            tlp.Controls.Add(lbl_StartTimeHeader, 3, 0);
            tlp.Controls.Add(lbl_EndTimeHeader, 4, 0);
            
            // Populate with video titles and timestamps from .txt
            for (int i = 0; i < videoList.Count; i++)
            {
                tlp.RowStyles.Add(new RowStyle());
                Label lbl_VideoTitle = new Label() { Text = videoList[i].Title, Dock = DockStyle.Fill, Name = $"lbl_VideoTitle_{i}" };
                TextBox txt_VideoPath = new TextBox() { Text = "", Dock = DockStyle.Fill, Name = $"txt_VideoPath_{i}" };
                Button btn_VideoPath = new Button() { Text = "...", Dock = DockStyle.Fill, Name = $"btn_VideoPath_{i}" };
                TextBox txt_StartTime = new TextBox() { Text = videoList[i].StartTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_StartTime_{i}" };
                TextBox txt_EndTime = new TextBox() { Text = videoList[i].EndTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_EndTime_{i}" };
                tlp.Controls.Add(lbl_VideoTitle, 0, i + 1);
                tlp.Controls.Add(txt_VideoPath, 1, i + 1);
                tlp.Controls.Add(btn_VideoPath, 2, i + 1);
                tlp.Controls.Add(txt_StartTime, 3, i + 1);
                tlp.Controls.Add(txt_EndTime, 4, i + 1);
            }

            // Add TLP to form (remove existing)
            pnl_VideoList.Controls.Clear();
            pnl_VideoList.Controls.Add(tlp);
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
            var selectedDir = WinFormsDialogs.SelectFolder("Choose Clips Output Folder", Exe.Directory());
            if (Directory.Exists(selectedDir))
            {
                txt_ClipsDir.Text = selectedDir;
            }
        }

        // Enable Create Clips button depending on if output folder exists
        private void OutputDirTxt_Changed(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_ClipsDir.Text))
                btn_CreateClips.Enabled = true;
            else
                btn_CreateClips.Enabled = false;
        }

        // Create clips from selected videos using ffmpeg
        private void CreateClipsBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateTextboxInput())
                return;

            CreateClips();
        }

        private void CreateClips()
        {
            string ffmpegPath = Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");
            if (!File.Exists(ffmpegPath))
            {
                string errorText = $"Could not find ffmpeg.exe at path:\n\t\"{ffmpegPath}\"";
                Output.Log(errorText, ConsoleColor.Red);
                MessageBox.Show(errorText);
                return;
            }

            int successCount = 0;
            int failureCount = 0;
            foreach(var video in videoList)
            {
                string outputFilePath = FileSys.CreateUniqueFilePath(Path.Combine(txt_ClipsDir.Text, video.Title) + Path.GetExtension(video.Path));

                // Create clip from video in output directory without re-encoding
                Exe.Run(ffmpegPath, $"-copyts -ss {video.StartTime} -i \"{video.Path}\" -to {video.EndTime}  -map 0 -c copy {outputFilePath}", hideWindow: false);
                using (FileSys.WaitForFile(outputFilePath)) { };
                // Let user know if task succeeded or not
                if (!File.Exists(outputFilePath))
                {
                    Output.Log($"Failed to Create Clip: \"{outputFilePath}\"", ConsoleColor.Red);
                    failureCount++;
                }
                else
                {
                    Output.Log($"Clip Created: \"{outputFilePath}\"", ConsoleColor.Green);
                    successCount++;
                }
            }

            MessageBox.Show($"Finished creating clips.\n\nSucceeded: {successCount}\nFailed: {failureCount}", "Finished Creating Clips");
            Output.Log($"Done creating clips.");
        }

        // Make sure timestamps are parsed correctly and input video files exist
        private bool ValidateTextboxInput()
        {
            var tlp = pnl_VideoList.GetAllControls<TableLayoutPanel>().First();
            var txtCtrls = tlp.GetAllControls<TextBox>();

            foreach(TextBox txtBox in txtCtrls)
            {
                int rowID = Convert.ToInt32(txtBox.Name.Split('_').Last());
                try
                {
                    if (txtBox.Name.Split('_')[1] == "StartTime")
                        videoList[rowID].StartTime = TimeSpan.Parse(TimestampStringToHourFormat(txtBox.Text));
                    else if (txtBox.Name.Split('_')[1] == "EndTime")
                        videoList[rowID].EndTime = TimeSpan.Parse(TimestampStringToHourFormat(txtBox.Text));
                    else if (txtBox.Name.Split('_')[1] == "VideoPath") 
                    {
                        videoList[rowID].Path = txtBox.Text;

                        if (!File.Exists(txtBox.Text))
                        {
                            string errorText = $"Could not find video file for \"{videoList[rowID].Title}\" at specified path:" +
                                $"\\n\t\"{txtBox.Text}\"";
                            Output.Log(errorText, ConsoleColor.Red);
                            MessageBox.Show(errorText);

                            return false;
                        }
                    }
                }
                catch
                {
                    string errorText = $"Failed to convert provided timestamp for {videoList[rowID].Title} to hh:mm:ss format:" +
                        $"\n\t\"{txtBox.Text}\"";
                    Output.Log(errorText, ConsoleColor.Red);
                    MessageBox.Show(errorText);
                    return false;
                }
            }
            return true;
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
