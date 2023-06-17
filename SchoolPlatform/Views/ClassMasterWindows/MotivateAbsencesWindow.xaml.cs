using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using View.Models.Entities;
using View.ViewModels.Commands.ClassMasterCommands;

namespace View.Views.ClassMasterWindows;

/// <summary>
///     Interaction logic for MotivateAbsencesWindow.xaml
/// </summary>
public partial class MotivateAbsencesWindow
{
    private readonly ClassMasterAbsenceCommands _classMasterAbsenceCommands;

    public MotivateAbsencesWindow()
    {
        InitializeComponent();

        _classMasterAbsenceCommands = (ClassMasterAbsenceCommands)TryFindResource("ClassMasterAbsenceCommands");

        if (ClassMasterMainWindow.Class == null)
        {
            MessageBox.Show("You need be a class master");
            return;
        }

        StudentComboBox.ItemsSource = ClassMasterMainWindow.Class.Students;

        if (ClassMasterMainWindow.Class.SubjectClasses == null)
        {
            return;
        }

        var subjects = ClassMasterMainWindow.Class.SubjectClasses.Select(subjectClass => subjectClass.Subject).ToList();

        SubjectComboBox.ItemsSource = subjects;

        MotivatedComboBox.ItemsSource = Enum.GetValues(typeof(Motivated));
    }

    private void StudentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _classMasterAbsenceCommands.Student = (Student)StudentComboBox.SelectedItem;
    }

    private void SubjectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _classMasterAbsenceCommands.Subject = (Subject)SubjectComboBox.SelectedItem;
    }

    private void MotivatedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _classMasterAbsenceCommands.Motivated = (Motivated)MotivatedComboBox.SelectedItem;
    }
}