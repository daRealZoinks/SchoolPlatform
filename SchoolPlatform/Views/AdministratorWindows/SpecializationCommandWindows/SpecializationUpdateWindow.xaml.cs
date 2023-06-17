using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.SpecializationCommandWindows;

/// <summary>
///     Interaction logic for SpecializationUpdateWindow.xaml
/// </summary>
public partial class SpecializationUpdateWindow
{
    private readonly Specialization _specialization;

    public SpecializationUpdateWindow(Specialization selectedSpecialization)
    {
        InitializeComponent();

        _specialization = selectedSpecialization;

        NameTextBox.Text = selectedSpecialization.Name;
    }

    public Action<Specialization>? OnSpecializationUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Name can't be empty");
            return;
        }

        _specialization.Name = NameTextBox.Text;

        OnSpecializationUpdated?.Invoke(_specialization);
    }
}