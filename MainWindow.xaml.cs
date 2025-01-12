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
using FFMpegCore;
using FFMpegCore.Enums;

namespace VinesauceVODClipper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string ffmpegPath = System.IO.Path.Combine(Exe.Directory(), "./Dependencies/ffmpeg.exe");
        List<int> selectedRowIDs;
        int selectedCellRow;
        private readonly ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _Log.AppendText("Created by ShrineFox\nBackground image by AlizarinRed, Icon by Yoshitura");
            this.viewModel = new ViewModel();
            this.DataContext = this.viewModel;
            ffmpegPath = System.IO.Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");

            OutputDirBrowseField.ButtonClicked += OutputDirBrowseField_ButtonClicked;
            // setting global options
            GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./Dependencies", TemporaryFilesFolder = "/Logs", LogLevel = FFMpegLogLevel.Error });

#if DEBUG
            viewModel.DataGridItems.Add(new DataGridItem() { Title = "Monke", EndTime = TimeSpan.Parse("0:6:0"), Path = "C:\\Users\\Ryan\\Downloads\\Vinesauce： The Full Sauce - Vinny - Super Monkey Ball Banana Rumble (PART 7) Re-encode.mp4" });
            OutputDirBrowseField.Text = "C:\\Users\\Ryan\\Downloads\\Clips";
#endif
        }

        private void NewList_Click(object sender, EventArgs e)
        {
            // Exit early if the user doesn't want to overwrite video list
            if (viewModel.DataGridItems.Count > 0 && !WinFormsDialogs.ShowMessageBox(
                "Reset Video List", "All unsaved work will be lost. Do you want to continue?", MessageBoxButtons.YesNo))
            {
                return;
            }

            viewModel.DataGridItems = new ObservableCollection<DataGridItem>() { new DataGridItem() };
        }

        private void ImportList_Click(object sender, EventArgs e)
        {
            var selectedFiles = WinFormsDialogs.SelectFile("Import .tsv File", false, new string[] { "Tab-Separated Values File (.tsv)" });
            if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
            {
                ImportTsvFile(selectedFiles.First());
            }
        }

        private void ImportTsvFile(string txtPath)
        {
            var tsvLines = File.ReadAllLines(txtPath);
            List<DataGridItem> videoList = new List<DataGridItem>();

            // Create new video list
            for (int i = 0; i < tsvLines.Length; i++)
            {
                var splitLine = tsvLines[i].Trim().Split('\t');

                if (splitLine.Length >= 5)
                {
                    DataGridItem video = new DataGridItem();

                    video.Title = splitLine[0];
                    video.Description = splitLine[1];

                    if (video.Title != "Title" && video.Description != "Description")
                    {
                        video.Path = splitLine[2];

                        // Attempt to get timestamps from .tsv line
                        string startTime = TimestampStringToHourFormat(splitLine[splitLine.Length - 2]);
                        try
                        {
                            video.StartTime = TimeSpan.Parse(startTime);
                        }
                        catch
                        {
                            LogText($"Syntax error on line {i + 1}: Invalid Start Time timestamp: \"{startTime}\"" +
                                $"\nFormat must be hh:mm:ss");
                        }
                        string endTime = TimestampStringToHourFormat(splitLine.Last());
                        try
                        {
                            video.EndTime = TimeSpan.Parse(endTime);
                        }
                        catch
                        {
                            LogText($"Syntax error on line {i + 1}: Invalid End Time timestamp: \"{endTime}\"" +
                                $"\nFormat must be hh:mm:ss");
                        }

                        // Join all strings except the last two timestamps to create Title
                        videoList.Add(video);
                    }
                    else
                    {
                        LogText($"Skipping line {i + 1}: Suspected header line (starts with \"Title\tDescription\")");
                    }
                }
                else
                    LogText($"Syntax error on line {i + 1}: Not enough columns separated by Tab character. Expected:" +
                        $"\nTitle\tDescription\tPath\tStartTime\tEndTime");
            }

            foreach (var item in videoList)
                viewModel.DataGridItems.Add(item);
            LogText($"Imported {videoList.Count} rows from file: {txtPath}");
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

        private void ExportList_Click(object sender, EventArgs e)
        {
            var selectedFiles = WinFormsDialogs.SelectFile("Import .tsv File", false, new string[] { "Tab-Separated Values File (.tsv)" }, true);
            if (selectedFiles.Count > 0)
            {
                ExportTsvFile(selectedFiles.First());
            }
        }

        private void ExportTsvFile(string tsvPath)
        {
            if (!tsvPath.ToLower().EndsWith(".tsv"))
                tsvPath += ".tsv";

            string tsvText = "";
            foreach(var item in viewModel.DataGridItems)
            {
                tsvText += $"{item.Title}\t{item.Description}\t{item.Path}\t{item.StartTime}\t{item.EndTime}\n";
            }
            File.WriteAllText(tsvPath, tsvText);
            LogText($"Saved new .tsv file to: \"{tsvPath}\"");
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
                var selectedFiles = WinFormsDialogs.SelectFile("Pick matching raw VOD video file");
                if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
                {
                    control.Text = selectedFiles.First();
                }
            }
        }

        private void VideoGridBrowseField_TextChanged(object sender, EventArgs e)
        {
            if (sender is BrowseField control)
            {
                var dataGridRow = _VideosDataGrid.Items.IndexOf(_VideosDataGrid.CurrentItem);
                if (dataGridRow == -1)
                    return;

                string title = viewModel.DataGridItems[dataGridRow].Title;

                foreach (var item in viewModel.DataGridItems.Where(x => x.Title == title))
                {
                    item.Path = control.Text;
                }
            }
        }

        private void CreateClipsBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ffmpegPath))
            {
                LogText($"Failed to process videos, ffmpeg.exe was not found at: \"{ffmpegPath}\"");
                return;
            }

            CreateClips(viewModel.DataGridItems);
        }

        private void CreateClips(ObservableCollection<DataGridItem> items)
        {
            int successCount = 0;
            int failureCount = 0;
            for (int i = 0; i < items.Count; i++)
            {
                bool success = ValidateInput(items[i], i);
                if (success)
                {
                    // Set Output Path
                    string outputDir = OutputDirBrowseField.Text;
                    if (string.IsNullOrEmpty(outputDir))
                        outputDir = Exe.Directory();
                    else if (!Directory.Exists(outputDir))
                        Directory.CreateDirectory(outputDir);
                    string outputFileName = $"{items[i].Title} - {items[i].Description}";
                    string extension = System.IO.Path.GetExtension(items[i].Path);
                    string outputPath = System.IO.Path.Combine(outputDir, outputFileName + extension);

                    // Create Clip
                    StringBuilder logBuilder = new StringBuilder();

                    try
                    {
                        FFMpegArguments
                        .FromFileInput(items[i].Path, true, options => options
                            .Seek(items[i].StartTime)
                            .WithCustomArgument($"-to {items[i].EndTime}"))
                        .OutputToFile(outputPath, true, options => options
                            .WithCustomArgument($"-map 0 -c copy -avoid_negative_ts {_TimeStampModeComboBox.SelectedItem.ToString()}"))
                        .NotifyOnOutput(line =>
                        {
                            logBuilder.AppendLine(line);
                            LogText(line);
                        })
                        .ProcessSynchronously();

                        LogText($"Created Clip {i + 1}/{items.Count}: \"{outputPath}\"");
                        successCount++;
                    }
                    catch { failureCount++; }
                }
                else
                    failureCount++;
            }
            System.Windows.MessageBox.Show($"Finished creating clips.\n\nSucceeded: {successCount}\nFailed: {failureCount}", "Finished Creating Clips");
            LogText("Done creating clips.");
        }

        private bool ValidateInput(DataGridItem item, int index)
        {
            string outputFileName = $"{item.Title} - {item.Description}";
            var timespanDifference = item.EndTime.Subtract(item.StartTime);
            var clipLengthSeconds = timespanDifference.TotalSeconds;

            if (!File.Exists(item.Path))
            {
                LogText($"Error! Input video not found for [Row {index}]: \"{item.Path}\" Skipping export of \"{outputFileName}\"...");
                return false;
            }

            if (clipLengthSeconds <= 5)
            {
                LogText($"Error! Timespan needs to be 5 seconds or longer for [Row {index}]: Currently \"{clipLengthSeconds}\" seconds. Skipping export of \"{outputFileName}\"...");
                return false;
            }

            return true;
        }

        private void LogText(string text)
        {
            _Log.AppendText($"\n[{DateTime.Now.ToString("HH:mm tt")}] {text}");
        }

        private void DataGrid_RightClick(object sender, MouseButtonEventArgs e)
        {
            selectedCellRow = GetCurrentCellRow(e.OriginalSource as FrameworkElement);

            // Get all selected row IDs
            selectedRowIDs = new List<int>();
            foreach (var item in _VideosDataGrid.SelectedItems)
            {
                int index = _VideosDataGrid.Items.IndexOf(item);
                if (index != -1)
                {
                    selectedRowIDs.Add(index);
                }
            }

            // Show context menu
            ContextMenu contextMenu = (ContextMenu)_VideosDataGrid.Resources["dataGridContextMenu"];
            contextMenu.IsOpen = true;
        }

        private int GetCurrentCellRow(FrameworkElement originalSource)
        {
            // Get row of selected cell
            DataGridRow dataGridRow = null;
            var visibleParent = VisualTreeHelper.GetParent(originalSource);
            while (dataGridRow == null && visibleParent != null)
            {
                dataGridRow = visibleParent as DataGridRow;
                visibleParent = VisualTreeHelper.GetParent(visibleParent);
            }
            if (dataGridRow == null) { return -1; }

            return dataGridRow.GetIndex();
        }

        private void DataGridContextMenu_MoveUp(object sender, EventArgs e)
        {
            var indexAbove = selectedRowIDs[0] - 1;
            if (indexAbove <= -1) return;
            var itemAbove = viewModel.DataGridItems[indexAbove];
            viewModel.DataGridItems.RemoveAt(indexAbove);
            var indexLastItem = selectedRowIDs[selectedRowIDs.Count - 1];
            if (indexLastItem == viewModel.DataGridItems.Count)
            {
                viewModel.DataGridItems.Add(itemAbove);
            }
            else
            {
                try
                {
                    viewModel.DataGridItems.Insert(indexLastItem, itemAbove);
                }
                catch { }
            }
        }

        private void DataGridContextMenu_MoveDown(object sender, EventArgs e)
        {
            var indexBelow = selectedRowIDs[selectedRowIDs.Count - 1] + 1;
            if (indexBelow >= viewModel.DataGridItems.Count) return;
            var itemBelow = viewModel.DataGridItems[indexBelow];
            viewModel.DataGridItems.RemoveAt(indexBelow);
            var indexAbove = selectedRowIDs[0] - 1;
            viewModel.DataGridItems.Insert(indexAbove + 1, itemBelow);
        }

        private void DataGridContextMenu_Add(object sender, EventArgs e)
        {
            viewModel.DataGridItems.Insert(selectedRowIDs.Order().ToList().First(), new DataGridItem());
        }

        private void DataGridContextMenu_Duplicate(object sender, EventArgs e)
        {
            if (selectedRowIDs.Any(x => x.Equals(selectedCellRow)))
            {
                foreach (var index in selectedRowIDs)
                    viewModel.DataGridItems.Insert(selectedRowIDs.Order().ToList().First(), viewModel.DataGridItems[index].Copy());
            }
            else
                viewModel.DataGridItems.Insert(selectedCellRow, viewModel.DataGridItems[selectedCellRow].Copy());
        }
        private void DataGridContextMenu_Delete(object sender, EventArgs e)
        {
            // If selected cell's row ID is part of full row selection, apply selected option to all rows
            if (selectedRowIDs.Any(x => x.Equals(selectedCellRow)))
            {
                selectedRowIDs = selectedRowIDs.Order().ToList();
                selectedRowIDs.Reverse();
                foreach (var index in selectedRowIDs)
                {
                    try
                    {
                        viewModel.DataGridItems.RemoveAt(index);
                    }
                    catch { }
                }
            }
            else
            {
                // Otherwise, apply selection to only selected individual row
                viewModel.DataGridItems.RemoveAt(selectedCellRow);
            }
        }

        // Add row numbers to DataGrid
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
    }
}