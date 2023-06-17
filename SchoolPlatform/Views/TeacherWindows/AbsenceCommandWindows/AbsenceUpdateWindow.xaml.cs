using System;
using System.Collections.Generic;
using System.Windows;
using View.Models.Entities;

namespace View.Views.TeacherWindows.AbsenceCommandWindows;

/// <summary>
///     Interaction logic for AbsenceUpdateWindow.xaml
/// </summary>
public partial class AbsenceUpdateWindow
{
    private readonly Absence _absence;

    public AbsenceUpdateWindow(Absence selectedAbsence)
    {
        InitializeComponent();

        _absence = selectedAbsence;

        List<Student> students = new();
        List<Subject> subjects = new();

        foreach (var subjectClass in TeacherMainWindow.Teacher.SubjectClasses)
        {
            subjects.Add(subjectClass.Subject);

            students.AddRange(subjectClass.Class.Students);
        }

        StudentComboBox.ItemsSource = students;
        SubjectComboBox.ItemsSource = subjects;

        StudentComboBox.SelectedValue = selectedAbsence.Student;
        SubjectComboBox.SelectedValue = selectedAbsence.Subject;
        DateCalendar.DisplayDate = selectedAbsence.Date;
        MotivatedCheckBox.IsChecked = selectedAbsence.Motivated;
    }

    public Action<Absence>? OnAbsenceUpdated { get; set; }

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

        _absence.Student = (Student)StudentComboBox.SelectedValue;
        _absence.Subject = (Subject)SubjectComboBox.SelectedValue;
        _absence.Date = DateCalendar.DisplayDate;
        _absence.Motivated = MotivatedCheckBox.IsChecked ?? false;

        OnAbsenceUpdated?.Invoke(_absence);
    }
}