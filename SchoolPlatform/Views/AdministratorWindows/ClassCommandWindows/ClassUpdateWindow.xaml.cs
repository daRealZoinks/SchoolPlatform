using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.AdministratorWindows.ClassCommandWindows;

/// <summary>
///     Interaction logic for ClassUpdateWindow.xaml
/// </summary>
public partial class ClassUpdateWindow
{
    private readonly Class _class;

    public ClassUpdateWindow(Class selectedClass)
    {
        InitializeComponent();

        _class = selectedClass;

        ClassMasterComboBox.ItemsSource = App.Current.Services.GetService<ITeacherCollectionService>()?.GetAll();
        YearComboBox.ItemsSource = App.Current.Services.GetService<IYearCollectionService>()?.GetAll();
        SpecializationComboBox.ItemsSource =
            App.Current.Services.GetService<ISpecializationCollectionService>()?.GetAll();

        NameTextBox.Text = selectedClass.Name;
        ClassMasterComboBox.SelectedValue = selectedClass.ClassMaster;
        YearComboBox.SelectedValue = selectedClass.Year;
        SpecializationComboBox.SelectedValue = selectedClass.Specialization;
    }

    public Action<Class>? OnClassUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        _class.Name = NameTextBox.Text;
        _class.ClassMaster = (Teacher)ClassMasterComboBox.SelectedValue;
        _class.Year = (Year)YearComboBox.SelectedValue;
        _class.Specialization = (Specialization)SpecializationComboBox.SelectedValue;

        OnClassUpdated?.Invoke(_class);
    }
}