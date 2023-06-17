using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.TeacherCommandWindow;

/// <summary>
///     Interaction logic for TeacherUpdateWindow.xaml
/// </summary>
public partial class TeacherUpdateWindow
{
    private readonly Teacher _teacher;

    public TeacherUpdateWindow(Teacher selectedTeacher)
    {
        InitializeComponent();

        _teacher = selectedTeacher;

        FirstNameTextBox.Text = selectedTeacher.FirstName;
        LastNameTextBox.Text = selectedTeacher.LastName;
    }

    public Action<Teacher>? OnTeacherUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        _teacher.FirstName = FirstNameTextBox.Text;
        _teacher.LastName = LastNameTextBox.Text;

        OnTeacherUpdated?.Invoke(_teacher);
    }
}