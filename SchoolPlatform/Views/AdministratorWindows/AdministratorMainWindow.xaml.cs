using System.Windows;
using View.AdministratorWindows;

namespace View.Views.AdministratorWindows;

/// <summary>
///     Interaction logic for AdministratorMainWindow.xaml
/// </summary>
public partial class AdministratorMainWindow
{
    public AdministratorMainWindow()
    {
        InitializeComponent();
    }

    private void AbsenceButton_Click(object sender, RoutedEventArgs e)
    {
        new AbsenceCRUDWindow().Show();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
        new AverageCRUDWindow().Show();
    }

    private void ClassButton_Click(object sender, RoutedEventArgs e)
    {
        new ClassCRUDWindow().Show();
    }

    private void GradeButton_Click(object sender, RoutedEventArgs e)
    {
        new GradeCRUDWindow().Show();
    }

    private void SpecializationButton_Click(object sender, RoutedEventArgs e)
    {
        new SpecializationCRUDWindow().Show();
    }

    private void StudentButton_Click(object sender, RoutedEventArgs e)
    {
        new StudentCRUDWindow().Show();
    }

    private void SubjectButton_Click(object sender, RoutedEventArgs e)
    {
        new SubjectCRUDWindow().Show();
    }

    private void SubjectClassButton_Click(object sender, RoutedEventArgs e)
    {
        new SubjectClassCRUDWindow().Show();
    }

    private void TeacherButton_Click(object sender, RoutedEventArgs e)
    {
        new TeacherCRUDWindow().Show();
    }

    private void UserButton_Click(object sender, RoutedEventArgs e)
    {
        new UserCRUDWindow().Show();
    }

    private void YearButton_Click(object sender, RoutedEventArgs e)
    {
        new YearCRUDWindow().Show();
    }
}