using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace VinesauceVODClipper.Controls
{
    public partial class BrowseField : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
            _BrowseTxtBox.TextChanged += TextBox_TextChanged;
        }


        public event EventHandler ButtonClicked;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public event TextChangedEventHandler TextChanged;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the source binding explicitly
            var bindingExpression = _BrowseTxtBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();

            TextChanged?.Invoke(this, e);
        }
    }
}
