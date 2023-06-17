using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.SpecializationCommandWindows;

/// <summary>
///     Interaction logic for SpecializationInsertWindow.xaml
/// </summary>
public partial class SpecializationInsertWindow
{
    public SpecializationInsertWindow()
    {
        InitializeComponent();
    }

    public Action<Specialization>? OnSpecializationInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Name can't be empty");
            return;
        }

        Specialization specialization = new()
        {
            Name = NameTextBox.Text
        };

        OnSpecializationInserted?.Invoke(specialization);
    }
}