using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;

namespace View.Views.ClassMasterWindows;

/// <summary>
///     Interaction logic for ClassMasterMainWindow.xaml
/// </summary>
public partial class ClassMasterMainWindow
{
    public ClassMasterMainWindow(Teacher teacher)
    {
        InitializeComponent();

        ClassMasterLabel.Content = teacher;

        var classCollectionService = App.Current.Services.GetService<IClassCollectionService>();

        Class = classCollectionService?.GetAll().FirstOrDefault(x => x.ClassMaster == teacher);

        if (Class == null)
        {
            MessageBox.Show("You need be a class master");
            return;
        }

        ClassLabel.Content = Class;
    }

    public static Class? Class { get; set; }

    private void MotivateAbsencesButton_OnClick(object sender, RoutedEventArgs e)
    {
        new MotivateAbsencesWindow().Show();
    }

    private void ViewAveragesButton_OnClick(object sender, RoutedEventArgs e)
    {
        new ViewAveragesWindow().Show();
    }
}