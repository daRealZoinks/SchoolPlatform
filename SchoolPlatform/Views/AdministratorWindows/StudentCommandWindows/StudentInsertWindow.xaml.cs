using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.StudentCommandWindows;

/// <summary>
///     Interaction logic for StudentInsertWindow.xaml
/// </summary>
public partial class StudentInsertWindow
{
    public StudentInsertWindow()
    {
        InitializeComponent();

        ClassComboBox.ItemsSource = App.Current.Services.GetService<IClassCollectionService>()?.GetAll();
    }

    public Action<Student>? OnStudentInserted { get; set; }

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

        if (ClassComboBox.SelectedValue == null)
        {
            MessageBox.Show("Class can't be empty");
            return;
        }

        Student student = new()
        {
            FirstName = FirstNameTextBox.Text,
            LastName = LastNameTextBox.Text,
            Class = (Class)ClassComboBox.SelectedValue
        };

        OnStudentInserted?.Invoke(student);
    }
}