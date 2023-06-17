using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.YearCommandWindows;

/// <summary>
///     Interaction logic for YearUpdateWindow.xaml
/// </summary>
public partial class YearUpdateWindow
{
    private readonly Year _year;

    public YearUpdateWindow(Year selectedYear)
    {
        InitializeComponent();

        _year = selectedYear;

        ValueTextBox.Text = selectedYear.Value.ToString();
    }

    public Action<Year>? OnYearUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(ValueTextBox.Text, out _))
        {
            MessageBox.Show("Invalid value");
            return;
        }

        _year.Value = int.Parse(ValueTextBox.Text);

        OnYearUpdated?.Invoke(_year);
    }
}