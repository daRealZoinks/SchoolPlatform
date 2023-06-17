using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.TeacherCommandWindow;

/// <summary>
///     Interaction logic for TeacherInsertWindow.xaml
/// </summary>
public partial class TeacherInsertWindow
{
    public TeacherInsertWindow()
    {
        InitializeComponent();
    }

    public Action<Teacher>? OnTeacherInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (FirstNameTextBox.Text == string.Empty)
        {
            MessageBox.Show("First name can't be empty");
            return;
        }

        if (LastNameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Last name can't be empty");
            return;
        }

        Teacher teacher = new()
        {
            FirstName = FirstNameTextBox.Text,
            LastName = LastNameTextBox.Text
        };

        OnTeacherInserted?.Invoke(teacher);
    }
}