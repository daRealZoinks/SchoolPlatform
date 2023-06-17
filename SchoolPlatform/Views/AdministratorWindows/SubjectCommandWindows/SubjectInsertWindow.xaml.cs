using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.SubjectCommandWindows;

/// <summary>
///     Interaction logic for SubjectInsertWindow.xaml
/// </summary>
public partial class SubjectInsertWindow : Window
{
    public SubjectInsertWindow()
    {
        InitializeComponent();
    }

    public Action<Subject>? OnSubjectInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Name can't be empty");
            return;
        }

        Subject subject = new()
        {
            Name = NameTextBox.Text
        };

        OnSubjectInserted?.Invoke(subject);
    }
}