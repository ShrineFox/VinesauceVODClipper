﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace VinesauceVODClipper.Controls
{
    public partial class BrowseField : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(BrowseField),
                new PropertyMetadata(string.Empty, OnTextChanged));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public BrowseField()
        {
            InitializeComponent();
            _BrowseTxtBox.TextChanged += TextBox_TextChanged_Internal;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BrowseField;
            control?.OnPropertyChanged(nameof(Text));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = (sender as TextBox)?.Text;
        }

        public event EventHandler ButtonClicked;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public event TextChangedEventHandler TextChanged;
        private void TextBox_TextChanged_Internal(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}
