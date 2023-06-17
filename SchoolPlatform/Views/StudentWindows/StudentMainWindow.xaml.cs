using System.Windows;
using View.Models.Entities;

namespace View.Views.StudentWindows;

/// <summary>
///     Interaction logic for StudentMainWindow.xaml
/// </summary>
public partial class StudentMainWindow
{
    public StudentMainWindow(Student student)
    {
        InitializeComponent();

        Student = student;

        StudentLabel.Content = $"Welcome, {Student.FirstName} {Student.LastName}";
    }

    public static Student Student { get; private set; }

    private void AbsenceButton_Click(object sender, RoutedEventArgs e)
    {
        new AbsenceWindow().Show();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
        new AverageWindow().Show();
    }

    private void GradeButton_Click(object sender, RoutedEventArgs e)
    {
        new GradeWindow().Show();
    }
}