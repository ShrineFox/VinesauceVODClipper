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
using System.Diagnostics;

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
        private bool updateTextFields = true;

        public MainWindow()
        {
            InitializeComponent();

            _Log.AppendText("Created by ShrineFox\nBackground image by AlizarinRed, Icon by Yoshitura");
            this.viewModel = new ViewModel() { DataGridItems = { new DataGridItem() } };
            this.DataContext = this.viewModel;
            ffmpegPath = System.IO.Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");

            OutputDirBrowseField.ButtonClicked += OutputDirBrowseField_ButtonClicked;
        }

        private void LogDetailComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Directory.CreateDirectory("./Logs");
            ComboBoxItem errorSetting = (ComboBoxItem)_LogDetailComboBox.SelectedItem;

            if (errorSetting.Content.ToString() == "Verbose")
            {
                GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./Dependencies", TemporaryFilesFolder = "/Logs", LogLevel = FFMpegLogLevel.Verbose });
            }
            else
            {
                GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./Dependencies", TemporaryFilesFolder = "/Logs", LogLevel = FFMpegLogLevel.Error });
            }
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
            if (string.IsNullOrEmpty(tsvPath))
                return;

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

        private void VideoGridBrowseField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (updateTextFields && sender is BrowseField control)
            {
                var dataGridRow = _VideosDataGrid.Items.IndexOf(_VideosDataGrid.CurrentItem);
                if (dataGridRow == -1 || viewModel.DataGridItems.Count == 0)
                    return;

                string title = viewModel.DataGridItems[dataGridRow].Title;

                updateTextFields = false;
                foreach (var item in viewModel.DataGridItems.Where(x => x.Title == title && x.Path != control.Text))
                {
                    item.Path = control.Text;
                }
                updateTextFields = true;
            }
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
            ComboBoxItem timeStampMode = (ComboBoxItem)_TimeStampModeComboBox.SelectedItem;
            string logFilePath = System.IO.Path.Combine("./Logs", $"ffmpeg_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

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
                        outputDir = System.IO.Path.Combine(Exe.Directory(), "Output");
                    else if (!Directory.Exists(outputDir))
                        Directory.CreateDirectory(outputDir);
                    string outputFileName = $"{items[i].Title} - {items[i].Description}";
                    string extension = System.IO.Path.GetExtension(items[i].Path);
                    string outputPath = System.IO.Path.Combine(outputDir, outputFileName + extension);
                    Directory.CreateDirectory(outputDir);

                    // Create Clip
                    string arguments = "";

                    string customArgs = $"-map 0 -c copy -avoid_negative_ts {timeStampMode.Content.ToString()}";

                    if ((bool)CheckBox_ReEncode.IsChecked)
                    {
                        // copy audio stream but re-encode video
                        customArgs = $" -map 0 -c copy -c:v libx265";
                        var scaleSetting = (ComboBoxItem)_ScaleVideoComboBox.SelectedItem;
                        // change output scale of video
                        if (scaleSetting.Content.ToString() != "default")
                            customArgs += $" -vf \"scale={scaleSetting.Content.ToString()}\"";
                    }

                    try
                    {
                        var args = FFMpegArguments
                        .FromFileInput(items[i].Path, true, options => options
                            .Seek(items[i].StartTime)
                            .WithCustomArgument($"-to {items[i].EndTime}"))
                        .OutputToFile(outputPath, true, options => options
                            .WithCustomArgument(customArgs));

                        arguments = args.Arguments;


                        VerboseLogText($"Processing Clip {i + 1}/{items.Count} with arguments:\nffmpeg.exe {args.Arguments}");

                        if (args.ProcessSynchronously())
                        {
                            LogText($"Created Clip {i + 1}/{items.Count}: \"{outputPath}\"");
                            successCount++;
                        }
                        else
                            failureCount++;
                    }
                    catch (Exception e) { LogText($"[ERROR] An exception has occured: {e.Message}"); File.WriteAllText(logFilePath, $"{arguments}\n\n{e.Message}"); failureCount++; }
                }
                else
                    failureCount++;
            }
            System.Windows.MessageBox.Show($"Finished creating clips.\n\nSucceeded: {successCount}\nFailed: {failureCount}", "Finished Creating Clips");
            LogText("Done creating clips.");
        }

        private void VerboseLogText(string text)
        {
            ComboBoxItem errorSetting = (ComboBoxItem)_LogDetailComboBox.SelectedItem;
            if (errorSetting.Content.ToString() == "Verbose")
                LogText(text);
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

            if (clipLengthSeconds <= 2)
            {
                LogText($"Error! Timespan needs to be 2 seconds or longer for [Row {index}]: Currently \"{clipLengthSeconds}\" seconds. Skipping export of \"{outputFileName}\"...");
                return false;
            }

            return true;
        }

        private void LogText(string text)
        {
            _Log.AppendText($"\n[{DateTime.Now.ToString("HH:mm tt")}] {text}");
            _Log.ScrollToEnd();
        }

        private void DataGrid_RightClick(object sender, MouseButtonEventArgs e)
        {
            selectedCellRow = GetCurrentCellRow(e.OriginalSource as FrameworkElement);

            GetSelectedRowIDs();

            // Show context menu
            ContextMenu contextMenu = (ContextMenu)_VideosDataGrid.Resources["dataGridContextMenu"];
            contextMenu.IsOpen = true;
        }

        private void GetSelectedRowIDs()
        {
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

            // Get them in order and reverse the list
            selectedRowIDs = selectedRowIDs.Order().ToList();
            selectedRowIDs.Reverse();
        }

        private void StackPanel_RightClick(object sender, MouseButtonEventArgs e)
        {
            // Show context menu
            ContextMenu contextMenu = (ContextMenu)_VideosStackPanel.Resources["stackPanelContextMenu"];
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
            MoveSelectedRowsUp();
        }

        private void MoveSelectedRowsUp()
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
            MoveSelectedRowsDown();
        }

        private void MoveSelectedRowsDown()
        {
            try
            {
                var indexBelow = selectedRowIDs[selectedRowIDs.Count - 1] + 1;
                if (indexBelow >= viewModel.DataGridItems.Count) return;
                var itemBelow = viewModel.DataGridItems[indexBelow];
                viewModel.DataGridItems.RemoveAt(indexBelow);
                var indexAbove = selectedRowIDs[0] - 1;
                viewModel.DataGridItems.Insert(indexAbove + 1, itemBelow);
            }
            catch { }
        }

        private void DataGridContextMenu_Add(object sender, EventArgs e)
        {
            viewModel.DataGridItems.Insert(selectedRowIDs.First(), new DataGridItem());
        }

        private void StackPanelContextMenu_Add(object sender, EventArgs e)
        {
            viewModel.DataGridItems.Add(new DataGridItem());
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

        private void DataGrid_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    var droppedFilePath = files[0];
                    var position = e.GetPosition(_VideosDataGrid);
                    var hitTestResult = VisualTreeHelper.HitTest(_VideosDataGrid, position);
                    if (hitTestResult != null)
                    {
                        var dataGridRow = FindAncestor<DataGridRow>(hitTestResult.VisualHit);
                        if (dataGridRow != null)
                        {
                            var dataGridItem = dataGridRow.Item as DataGridItem;
                            if (dataGridItem != null)
                            {
                                dataGridItem.Path = droppedFilePath;
                            }
                        }
                    }
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null && !(current is T))
            {
                current = VisualTreeHelper.GetParent(current);
            }
            return current as T;
        }

        private void MoveFocusToCellAbove()
        {
            var currentCell = _VideosDataGrid.CurrentCell;
            var currentRowIndex = _VideosDataGrid.Items.IndexOf(currentCell.Item);
            if (currentRowIndex > 0)
            {
                var previousRow = _VideosDataGrid.ItemContainerGenerator.ContainerFromIndex(currentRowIndex - 1) as DataGridRow;
                if (previousRow != null)
                {
                    var cellContent = _VideosDataGrid.Columns[currentCell.Column.DisplayIndex].GetCellContent(previousRow);
                    if (cellContent != null)
                    {
                        var cell = cellContent.Parent as DataGridCell;
                        if (cell != null)
                        {
                            cell.Focus();
                            _VideosDataGrid.CurrentCell = new DataGridCellInfo(cell);
                            _VideosDataGrid.SelectedItem = previousRow.Item;
                        }
                    }
                }
            }
        }

        private void MoveFocusToCellBelow()
        {
            var currentCell = _VideosDataGrid.CurrentCell;
            var currentRowIndex = _VideosDataGrid.Items.IndexOf(currentCell.Item);
            if (currentRowIndex < _VideosDataGrid.Items.Count - 1)
            {
                var nextRow = _VideosDataGrid.ItemContainerGenerator.ContainerFromIndex(currentRowIndex + 1) as DataGridRow;
                if (nextRow != null)
                {
                    var cellContent = _VideosDataGrid.Columns[currentCell.Column.DisplayIndex].GetCellContent(nextRow);
                    if (cellContent != null)
                    {
                        var cell = cellContent.Parent as DataGridCell;
                        if (cell != null)
                        {
                            cell.Focus();
                            _VideosDataGrid.CurrentCell = new DataGridCellInfo(cell);
                            _VideosDataGrid.SelectedItem = nextRow.Item;
                        }
                    }
                }
            }
        }

        private void DataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                GetSelectedRowIDs();
                foreach (var rowID in selectedRowIDs)
                {
                    viewModel.DataGridItems.RemoveAt(rowID);
                }
            }
            else if (e.Key == Key.Up && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                GetSelectedRowIDs();
                MoveSelectedRowsUp();
            }
            else if (e.Key == Key.Down && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                GetSelectedRowIDs();
                MoveSelectedRowsDown();
            }
            else if (e.Key == Key.Up)
            {
                MoveFocusToCellAbove();
            }
            else if (e.Key == Key.Down)
            {
                MoveFocusToCellBelow();
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/ShrineFox/VinesauceVODClipper#vinesaucevodclipper";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}