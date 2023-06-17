using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.YearCommandWindows;

/// <summary>
///     Interaction logic for YearInsertWindow.xaml
/// </summary>
public partial class YearInsertWindow
{
    public YearInsertWindow()
    {
        InitializeComponent();
    }

    public Action<Year>? OnYearInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (ValueTextBox.Text == string.Empty)
        {
            MessageBox.Show("Value can't be empty");
            return;
        }

        if (!int.TryParse(ValueTextBox.Text, out _))
        {
            MessageBox.Show("Invalid value");
            return;
        }

        Year year = new()
        {
            Value = int.Parse(ValueTextBox.Text)
        };

        OnYearInserted?.Invoke(year);
    }
}