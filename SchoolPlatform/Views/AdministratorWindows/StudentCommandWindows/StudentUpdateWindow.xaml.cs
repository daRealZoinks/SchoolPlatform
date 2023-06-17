using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.StudentCommandWindows;

/// <summary>
///     Interaction logic for StudentUpdateWindow.xaml
/// </summary>
public partial class StudentUpdateWindow
{
    private readonly Student _student;

    public StudentUpdateWindow(Student selectedStudent)
    {
        InitializeComponent();

        _student = selectedStudent;

        ClassComboBox.ItemsSource = App.Current.Services.GetService<IClassCollectionService>()?.GetAll();

        FirstNameTextBox.Text = selectedStudent.FirstName;
        LastNameTextBox.Text = selectedStudent.LastName;
        ClassComboBox.SelectedValue = selectedStudent.Class;
    }

    public Action<Student>? OnStudentUpdated { get; set; }

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

        if (ClassComboBox.SelectedValue == null)
        {
            MessageBox.Show("Class can't be empty");
            return;
        }

        _student.FirstName = FirstNameTextBox.Text;
        _student.LastName = LastNameTextBox.Text;
        _student.Class = (Class)ClassComboBox.SelectedValue;

        OnStudentUpdated?.Invoke(_student);
    }
}