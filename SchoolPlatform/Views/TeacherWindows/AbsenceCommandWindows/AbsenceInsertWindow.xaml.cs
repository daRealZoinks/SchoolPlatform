using System;
using System.Collections.Generic;
using System.Windows;
using View.Models.Entities;

namespace View.Views.TeacherWindows.AbsenceCommandWindows;

/// <summary>
///     Interaction logic for AbsenceInsertWindow.xaml
/// </summary>
public partial class AbsenceInsertWindow : Window
{
    public AbsenceInsertWindow()
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

    public Action<Absence>? OnAbsenceInserted { get; set; }

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

        Absence absence = new()
        {
            Student = (Student)StudentComboBox.SelectedValue,
            Subject = (Subject)SubjectComboBox.SelectedValue,
            Date = DateCalendar.DisplayDate,
            Motivated = MotivatedCheckBox.IsChecked ?? false
        };

        OnAbsenceInserted?.Invoke(absence);
    }
}