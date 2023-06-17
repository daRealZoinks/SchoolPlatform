using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.SubjectClassCommandWindows;

/// <summary>
///     Interaction logic for SubjectClassUpdateWindow.xaml
/// </summary>
public partial class SubjectClassUpdateWindow : Window
{
    private readonly SubjectClass _subjectClass;

    public SubjectClassUpdateWindow(SubjectClass selectedSubjectClass)
    {
        InitializeComponent();

        _subjectClass = selectedSubjectClass;

        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();
        ClassComboBox.ItemsSource = App.Current.Services.GetService<IClassCollectionService>()?.GetAll();
        TeacherComboBox.ItemsSource = App.Current.Services.GetService<ITeacherCollectionService>()?.GetAll();

        SubjectComboBox.SelectedValue = selectedSubjectClass.Subject;
        ClassComboBox.SelectedValue = selectedSubjectClass.Class;
        TeacherComboBox.SelectedValue = selectedSubjectClass.Teacher;
    }

    public Action<SubjectClass>? OnSubjectClassUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        if (SubjectComboBox.SelectedValue == null)
        {
            MessageBox.Show("Subject can't be empty");
            return;
        }

        if (ClassComboBox.SelectedValue == null)
        {
            MessageBox.Show("Class can't be empty");
            return;
        }

        if (TeacherComboBox.SelectedValue == null)
        {
            MessageBox.Show("Teacher can't be empty");
            return;
        }

        _subjectClass.Subject = (Subject)SubjectComboBox.SelectedValue;
        _subjectClass.Class = (Class)ClassComboBox.SelectedValue;
        _subjectClass.Teacher = (Teacher)TeacherComboBox.SelectedValue;

        OnSubjectClassUpdated?.Invoke(_subjectClass);
    }
}