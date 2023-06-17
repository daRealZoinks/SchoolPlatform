using System;
using System.Collections.Generic;
using System.Windows;
using View.Models.Entities;

namespace View.Views.TeacherWindows.GradeCommandWindows;

/// <summary>
///     Interaction logic for GradeInsertWindow.xaml
/// </summary>
public partial class GradeInsertWindow
{
    public GradeInsertWindow()
    {
        InitializeComponent();

        List<Student> students = new();
        List<Subject> subjects = new();

        foreach (var subjectClass in TeacherMainWindow.Teacher.SubjectClasses)
        {
            subjects.Add(subjectClass.Subject);

            students.AddRange(subjectClass.Class.Students);
        }

        StudentComboBox.ItemsSource = students;
        SubjectComboBox.ItemsSource = subjects;
    }

    public Action<Grade>? OnGradeInserted { get; set; }

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

        Grade grade = new()
        {
            Student = (Student)StudentComboBox.SelectedValue,
            Subject = (Subject)SubjectComboBox.SelectedValue,
            Date = DateCalendar.DisplayDate,
            Value = int.Parse(ValueTextBox.Text),
            IsThesis = IsThesisCheckBox.IsChecked ?? false
        };

        OnGradeInserted?.Invoke(grade);
    }
}