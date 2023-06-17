using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.ClassCommandWindows;

/// <summary>
///     Interaction logic for ClassInsertWindow.xaml
/// </summary>
public partial class ClassInsertWindow
{
    public ClassInsertWindow()
    {
        InitializeComponent();

        ClassMasterComboBox.ItemsSource = App.Current.Services.GetService<ITeacherCollectionService>()?.GetAll();
        YearComboBox.ItemsSource = App.Current.Services.GetService<IYearCollectionService>()?.GetAll();
        SpecializationComboBox.ItemsSource =
            App.Current.Services.GetService<ISpecializationCollectionService>()?.GetAll();
    }

    public Action<Class>? OnClassInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Name can't be empty");
            return;
        }

        if (ClassMasterComboBox.SelectedValue == null)
        {
            MessageBox.Show("Class master can't be empty");
            return;
        }

        if (YearComboBox.SelectedValue == null)
        {
            MessageBox.Show("Year can't be empty");
            return;
        }

        if (SpecializationComboBox.SelectedValue == null)
        {
            MessageBox.Show("Specialization can't be empty");
            return;
        }

        Class classEntity = new()
        {
            Name = NameTextBox.Text,
            ClassMaster = (Teacher)ClassMasterComboBox.SelectedValue,
            Year = (Year)YearComboBox.SelectedValue,
            Specialization = (Specialization)SpecializationComboBox.SelectedValue
        };

        OnClassInserted?.Invoke(classEntity);
    }
}