using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.AverageCommandWindows;

/// <summary>
///     Interaction logic for AverageInsertWindow.xaml
/// </summary>
public partial class AverageInsertWindow : Window
{
    public AverageInsertWindow()
    {
        InitializeComponent();

        StudentComboBox.ItemsSource = App.Current.Services.GetService<IStudentCollectionService>()?.GetAll();
        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();
    }

    public Action<Average>? OnAverageInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (StudentComboBox.SelectedValue == null)
        {
            MessageBox.Show("Student can't be empty");
            return;
        }

        if (SubjectComboBox.SelectedValue == null)
        {
            MessageBox.Show("Subject can't be empty");
            return;
        }

        if (!int.TryParse(ValueTextBox.Text, out var value) || value < 1 || value > 10)
        {
            MessageBox.Show("Value must be a number between 1 and 10");
            return;
        }

        Average average = new()
        {
            Student = (Student)StudentComboBox.SelectedValue,
            Subject = (Subject)SubjectComboBox.SelectedValue,
            Value = int.Parse(ValueTextBox.Text)
        };

        OnAverageInserted?.Invoke(average);
    }
}