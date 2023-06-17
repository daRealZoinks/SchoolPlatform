using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.SubjectClassCommandWindows;

/// <summary>
///     Interaction logic for SubjectClassInsertWindow.xaml
/// </summary>
public partial class SubjectClassInsertWindow : Window
{
    public SubjectClassInsertWindow()
    {
        InitializeComponent();

        SubjectComboBox.ItemsSource = App.Current.Services.GetService<ISubjectCollectionService>()?.GetAll();
        ClassComboBox.ItemsSource = App.Current.Services.GetService<IClassCollectionService>()?.GetAll();
        TeacherComboBox.ItemsSource = App.Current.Services.GetService<ITeacherCollectionService>()?.GetAll();
    }

    public Action<SubjectClass>? OnSubjectClassInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
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

        SubjectClass subjectClass = new()
        {
            Subject = (Subject)SubjectComboBox.SelectedValue,
            Class = (Class)ClassComboBox.SelectedValue,
            Teacher = (Teacher)TeacherComboBox.SelectedValue
        };

        OnSubjectClassInserted?.Invoke(subjectClass);
    }
}