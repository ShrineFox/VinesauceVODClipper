using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace VinesauceVODClipper
{
    partial class DataGridCustomStyle : ResourceDictionary
    {

        // https://stackoverflow.com/a/5276942
        public DataGridCustomStyle()
        {
            InitializeComponent();
        }

        // https://stackoverflow.com/a/15218130
        private void DataGridCell_GotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);

                System.Windows.Controls.Control control = GetFirstChildByType<System.Windows.Controls.Control>(e.OriginalSource as DataGridCell);
                if (control != null)
                {
                    control.Focus();

                    if (control.GetType() == typeof(TextBox))
                    {
                        TextBox txtBox = (TextBox)control;
                        if (txtBox != null)
                            txtBox.CaretIndex = txtBox.Text.Length;
                    }
                }
            }
        }

        private T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
                if (child == null)
                    continue;

                T castedProp = child as T;
                if (castedProp != null)
                    return castedProp;

                castedProp = GetFirstChildByType<T>(child);

                if (castedProp != null)
                    return castedProp;
            }
            return null;
        }
    }
}
