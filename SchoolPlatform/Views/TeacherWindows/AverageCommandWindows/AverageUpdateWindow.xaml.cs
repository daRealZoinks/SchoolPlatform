using System;
using System.Collections.Generic;
using System.Windows;
using View.Models.Entities;

namespace View.Views.TeacherWindows.AverageCommandWindows;

/// <summary>
///     Interaction logic for AverageUpdateWindow.xaml
/// </summary>
public partial class AverageUpdateWindow
{
    private readonly Average _average;

    public AverageUpdateWindow(Average selectedAverage)
    {
        InitializeComponent();

        _average = selectedAverage;

        List<Student> students = new();
        List<Subject> subjects = new();

        foreach (var subjectClass in TeacherMainWindow.Teacher.SubjectClasses)
        {
            subjects.Add(subjectClass.Subject);

            students.AddRange(subjectClass.Class.Students);
        }

        StudentComboBox.ItemsSource = students;
        SubjectComboBox.ItemsSource = subjects;

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