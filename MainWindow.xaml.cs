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
                DataGridItems = new List<DataGridItem>() { new DataGridItem() {  Title = "Test lol", Path = @"C:\Path\To\FullVOD.mp4" } },
            };
            this.DataContext = this.viewModel;
            ffmpegPath = System.IO.Path.Combine(Exe.Directory(), "Dependencies//ffmpeg.exe");

            // Subscribe to the ButtonClicked event of the UserControl
            OutputDirBrowseField.ButtonClicked += OutputDirBrowseField_ButtonClicked;
        }

        private void OutputDirBrowseField_ButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Output dir clicked!");
        }

        private void VideoGridBrowseField_ButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Video Grid dir clicked!");
        }

    }
}