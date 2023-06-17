using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.AbsenceCommandWindows;

/// <summary>
///     Interaction logic for AbsenceInsertWindow.xaml
/// </summary>
public partial class AbsenceInsertWindow : Window
{
    public AbsenceInsertWindow()
    {
        InitializeComponent();

        StudentComboBox.ItemsSource = App.Current.Services.GetService<IStudentCollectionService>()?.GetAll();
        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();
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