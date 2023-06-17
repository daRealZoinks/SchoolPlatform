using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.AverageCommandWindows;

/// <summary>
///     Interaction logic for AverageUpdateWindow.xaml
/// </summary>
public partial class AverageUpdateWindow : Window
{
    private readonly Average _average;

    public AverageUpdateWindow(Average selectedAverage)
    {
        InitializeComponent();

        _average = selectedAverage;

        StudentComboBox.ItemsSource = App.Current.Services.GetService<IStudentCollectionService>()?.GetAll();
        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();

        StudentComboBox.SelectedValue = selectedAverage.Student;
        SubjectComboBox.SelectedValue = selectedAverage.Subject;
        ValueTextBox.Text = selectedAverage.Value.ToString();
    }

    public Action<Average>? OnAverageUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        _average.Student = (Student)StudentComboBox.SelectedValue;
        _average.Subject = (Subject)SubjectComboBox.SelectedValue;
        _average.Value = int.Parse(ValueTextBox.Text);

        OnAverageUpdated?.Invoke(_average);
    }
}