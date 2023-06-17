using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.GradeCommandWindows;

/// <summary>
///     Interaction logic for GradeUpdateWindow.xaml
/// </summary>
public partial class GradeUpdateWindow : Window
{
    private readonly Grade _grade;

    public GradeUpdateWindow(Grade selectedGrade)
    {
        InitializeComponent();

        _grade = selectedGrade;

        StudentComboBox.ItemsSource = App.Current.Services.GetService<IStudentCollectionService>()?.GetAll();
        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();

        StudentComboBox.SelectedValue = selectedGrade.Student;
        SubjectComboBox.SelectedValue = selectedGrade.Subject;
        DateCalendar.DisplayDate = selectedGrade.Date;
        ValueTextBox.Text = selectedGrade.Value.ToString();
        IsThesisCheckBox.IsChecked = selectedGrade.IsThesis;
    }

    public Action<Grade>? OnGradeUpdated { get; set; }

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

        if (int.TryParse(ValueTextBox.Text, out var value) && value < 1 && value > 10)
        {
            MessageBox.Show("Value must be a number between 1 and 10");
            return;
        }

        _grade.Student = (Student)StudentComboBox.SelectedValue;
        _grade.Subject = (Subject)SubjectComboBox.SelectedValue;
        _grade.Date = DateCalendar.DisplayDate;
        _grade.Value = int.Parse(ValueTextBox.Text);
        _grade.IsThesis = IsThesisCheckBox.IsChecked ?? false;

        OnGradeUpdated?.Invoke(_grade);
    }
}