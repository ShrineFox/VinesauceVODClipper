﻿using System.Text;
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

            // Subscribe to the ButtonClicked event of the UserControl
            OutputDirBrowseField.ButtonClicked += OutputDirBrowseField_ButtonClicked;
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
                var dgi = (DataGridItem)control.DataContext;

                var selectedFiles = WinFormsDialogs.SelectFile("Pick matching raw VOD video file");
                if (selectedFiles.Count > 0 && File.Exists(selectedFiles.First()))
                {
                    dgi.Path = selectedFiles.First();
                    control.Text = dgi.Path;
                }
            }
        }

        

        private void LogText(string text)
        {
            _Log.AppendText($"\n[{DateTime.Now.ToString("HH:mm tt")}] {text}");
        }

        private void DataGrid_RightClick(object sender, MouseButtonEventArgs e)
        {
            // Get row of selected cell
            DataGridRow dataGridRow = null;
            var visibleParent = VisualTreeHelper.GetParent(e.OriginalSource as FrameworkElement);
            while (dataGridRow == null && visibleParent != null)
            {
                dataGridRow = visibleParent as DataGridRow;
                visibleParent = VisualTreeHelper.GetParent(visibleParent);
            }
            if (dataGridRow == null) { return; }

            selectedCellRow = dataGridRow.GetIndex();

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

        private void DataGridContextMenu_Add(object sender, EventArgs e)
        {
            viewModel.DataGridItems.Add(new DataGridItem());
        }
        private void DataGridContextMenu_Duplicate(object sender, EventArgs e)
        {
            if (selectedRowIDs.Any(x => x.Equals(selectedCellRow)))
            {
                foreach (var index in selectedRowIDs)
                    viewModel.DataGridItems.Add(viewModel.DataGridItems[index].Copy());
            }
            else
                viewModel.DataGridItems.Add(viewModel.DataGridItems[selectedCellRow].Copy());
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