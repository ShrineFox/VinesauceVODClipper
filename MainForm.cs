using ShrineFox.IO;
using MetroSet_UI;
using MetroSet_UI.Forms;

namespace VinesauceVODClipper
{
    public partial class MainForm : MetroSetForm
    {
        public List<Video> videoList = new List<Video>();
        string ffmpegPath = "";

        public MainForm()
        {
            InitializeComponent();
            ffmpegPath = Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");
            toolStripComboBox_AvoidNegativeTS.ComboBox.SelectedIndex = 0;
            Theme.ThemeStyle = this.Style;
            Theme.ApplyToForm(this);
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
                    UpdateInstructions();
                    CreateVideoListControls();
                }
                rtb_Log.Text = "";
                groupBox_VideoList.Text = "Videos to Generate Clips From";
                Output.Log($"Done reading {videoList.Count} entries from file:\n\t{txtPath}", ConsoleColor.Green);
            }
        }

        private void UpdateInstructions()
        {
            rtb_Instructions.Text = "Instructions:\r\n" +
                "- Drag Raw VOD video files onto table rows with matching titles below.\r\n" +
                "- Click \"Create Clips\" when finished to generate new videos in Output folder.";
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
                AllowDrop = true,
                Size = new Size(783, 22),
                Location = new Point(0, 0),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Name = "tlp"
            };

            // Create TLP layout
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            // Create header row
            tlp.RowStyles.Add(new RowStyle());
            Label lbl_VideoNumberHeader = new Label() { Text = "#", Font = headerFont };
            Label lbl_VideoTitleHeader = new Label() { Text = "Video Title", Font = headerFont };
            Label lbl_VideoPathHeader = new Label() { Text = "Video Path", Font = headerFont };
            Label lbl_StartTimeHeader = new Label() { Text = "Start Time", Font = headerFont };
            Label lbl_EndTimeHeader = new Label() { Text = "End Time", Font = headerFont };
            tlp.Controls.Add(lbl_VideoNumberHeader, 0, 0);
            tlp.Controls.Add(lbl_VideoTitleHeader, 1, 0);
            tlp.Controls.Add(lbl_VideoPathHeader, 2, 0);
            tlp.Controls.Add(lbl_StartTimeHeader, 4, 0);
            tlp.Controls.Add(lbl_EndTimeHeader, 5, 0);

            // Populate with video titles and timestamps from .txt
            for (int i = 0; i < videoList.Count; i++)
            {
                tlp.RowStyles.Add(new RowStyle());
                Label lbl_VideoNumber = new Label() { Text = $"#{i + 1}", Dock = DockStyle.Fill, Name = $"lbl_VideoNumber_{i}", AllowDrop = true, AutoSize = true };
                lbl_VideoNumber.DragEnter += DragEnter;
                lbl_VideoNumber.DragDrop += VideoDragDrop;
                Label lbl_VideoTitle = new Label() { Text = videoList[i].Title, Dock = DockStyle.Fill, Name = $"lbl_VideoTitle_{i}", AllowDrop = true, AutoSize = true };
                lbl_VideoTitle.DragEnter += DragEnter;
                lbl_VideoTitle.DragDrop += VideoDragDrop;
                TextBox txt_VideoPath = new TextBox() { Text = "", Dock = DockStyle.Fill, Name = $"txt_VideoPath_{i}", AllowDrop = true, BorderStyle = BorderStyle.None };
                txt_VideoPath.DragEnter += DragEnter;
                txt_VideoPath.DragDrop += VideoDragDrop;
                Button btn_VideoPath = new Button() { Text = "...", Dock = DockStyle.Fill, Name = $"btn_VideoPath_{i}", AllowDrop = true, Size = new Size(100, 30) };
                btn_VideoPath.DragEnter += DragEnter;
                btn_VideoPath.DragDrop += VideoDragDrop;
                btn_VideoPath.Click += VideoPathBtnClick;
                TextBox txt_StartTime = new TextBox() { Text = videoList[i].StartTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_StartTime_{i}", AllowDrop = true, BorderStyle = BorderStyle.None };
                txt_StartTime.DragEnter += DragEnter;
                txt_StartTime.DragDrop += VideoDragDrop;
                TextBox txt_EndTime = new TextBox() { Text = videoList[i].EndTime.ToString(@"hh\:mm\:ss"), Dock = DockStyle.Fill, Name = $"txt_EndTime_{i}", AllowDrop = true, BorderStyle = BorderStyle.None };
                txt_EndTime.DragEnter += DragEnter;
                txt_EndTime.DragDrop += VideoDragDrop;
                tlp.Controls.Add(lbl_VideoNumber, 0, i + 1);
                tlp.Controls.Add(lbl_VideoTitle, 1, i + 1);
                tlp.Controls.Add(txt_VideoPath, 2, i + 1);
                tlp.Controls.Add(btn_VideoPath, 3, i + 1);
                tlp.Controls.Add(txt_StartTime, 4, i + 1);
                tlp.Controls.Add(txt_EndTime, 5, i + 1);
            }

            // Add TLP to form (remove existing)
            pnl_VideoList.Controls.Clear();
            pnl_VideoList.Controls.Add(tlp);
            Theme.ApplyToForm(this);
        }

        // Choose video file path for button clicked in TLP row
        private void VideoPathBtnClick(object? sender, EventArgs e)
        {
            Control control = (Control)sender;
            int rowID = Convert.ToInt32(control.Name.Split("_").Last());

            var selectedFiles = WinFormsDialogs.SelectFile("Pick matching raw VOD video file");
            if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
            {
                TextBox txtBox = WinForms.GetControl(this, $"txt_VideoPath_{rowID}");
                txtBox.Text = selectedFiles.First();
            }
        }

        // Get file path of video dropped on controls in TLP row
        private void VideoDragDrop(object? sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length <= 0)
                return;

            int rowID = Convert.ToInt32(control.Name.Split("_").Last());
            TextBox txtBox = WinForms.GetControl(this, $"txt_VideoPath_{rowID}");
            txtBox.Text = files.First();
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
            if (!File.Exists(ffmpegPath))
            {
                string errorText = $"Clip creation failed. Could not find ffmpeg.exe at path:\n\t\"{ffmpegPath}\"";
                Output.Log(errorText, ConsoleColor.Red);
                MessageBox.Show(errorText);
                return;
            }

            int successCount = 0;
            int failureCount = 0;
            foreach (var video in videoList)
            {
                string outputFilePath = FileSys.CreateUniqueFilePath(Path.Combine(txt_ClipsDir.Text, video.Title) + Path.GetExtension(video.Path));

                // Add selected avoid negative timestamp mode to args
                string avoidNegativeTSArgs = "";
                if (avoidNegativeTimestampsToolStripMenuItem.Checked)
                    avoidNegativeTSArgs += $" -avoid_negative_ts {toolStripComboBox_AvoidNegativeTS.ComboBox.SelectedItem.ToString()}";

                // Create clip from video in output directory without re-encoding
                string args = $"-i \"{video.Path}\" -ss {video.StartTime} -to {video.EndTime} -map 0 -c copy{avoidNegativeTSArgs} \"{outputFilePath}\" -report";

                Output.Log($"Running ffmpeg with args:\n\t{args}");
                Exe.Run(ffmpegPath, args, hideWindow: false);
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

            foreach (TextBox txtBox in txtCtrls)
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
                                $"\n\t\"{txtBox.Text}\"";
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

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Set text file to drag/dropped one
        private void TxtFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length <= 0 || Path.GetExtension(files.First()).ToLower() != ".txt")
                return;

            txt_TxtFile.Text = files.First();
        }

        // Set output directory to drag/dropped one

        private void ClipsDir_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length <= 0 || !Directory.Exists(files.First()))
                return;

            txt_ClipsDir.Text = files.First();
        }

        // Select video files to re-encode
        private void ReEncodeClips_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(ffmpegPath))
            {
                string errorText = $"Clip re-encoding failed. Could not find ffmpeg.exe at path:\n\t\"{ffmpegPath}\"";
                Output.Log(errorText, ConsoleColor.Red);
                MessageBox.Show(errorText);
                return;
            }

            var selectedFiles = WinFormsDialogs.SelectFile("Choose video clips to re-encode", true);
            if (selectedFiles.Count > 0)
            {
                foreach (var file in selectedFiles)
                {
                    string outputFilePath = FileSys.CreateUniqueFilePath(Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)) + " (Re-Encoded)" + Path.GetExtension(file));
                    string args = $"-i \"{file}\"  -y -map 0 -c copy -c:a aac \"{outputFilePath}\" -report";
                    Output.Log($"Running ffmpeg with args:\n\t{args}");
                    Exe.Run(ffmpegPath, args, hideWindow: false);
                    using (FileSys.WaitForFile(outputFilePath)) { };
                    // Let user know if task succeeded or not
                    if (!File.Exists(outputFilePath))
                    {
                        Output.Log($"Failed to re-encode Clip: \"{outputFilePath}\"", ConsoleColor.Red);
                    }
                    else
                    {
                        Output.Log($"Clip re-encoded: \"{outputFilePath}\"", ConsoleColor.Green);
                    }
                }
            }

            Output.Log("Done re-encoding clips.");
        }

        private void ToggleTheme_Click(object sender, EventArgs e)
        {
            if (toggleThemeToolStripMenuItem.Checked)
                this.Style = MetroSet_UI.Enums.Style.Dark;
            else
                this.Style = MetroSet_UI.Enums.Style.Light;

            Theme.ThemeStyle = this.Style;

            Theme.ApplyToForm(this);
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
