using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.AbsenceCommandWindows;

/// <summary>
///     Interaction logic for AbsenceUpdateWindow.xaml
/// </summary>
public partial class AbsenceUpdateWindow : Window
{
    private readonly Absence _absence;

    public AbsenceUpdateWindow(Absence selectedAbsence)
    {
        InitializeComponent();

        _absence = selectedAbsence;

        StudentComboBox.ItemsSource = App.Current.Services.GetService<IStudentCollectionService>()?.GetAll();
        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();

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