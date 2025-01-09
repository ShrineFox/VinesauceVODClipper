using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VinesauceVODClipper.Controls
{
    /// <summary>
    /// Interaction logic for BrowseField.xaml
    /// </summary>
    public partial class BrowseField : UserControl
    {
        // Dependency Property for Text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(BrowseField),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public BrowseField()
        {
            InitializeComponent();
            // Bind the internal TextBox.Text to the custom Text property
            _BrowseTxtBox.SetBinding(TextBox.TextProperty, new Binding("Text") { Source = this, Mode = BindingMode.TwoWay });

        }
    }
}
