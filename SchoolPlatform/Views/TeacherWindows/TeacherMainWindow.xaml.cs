using System.Windows;
using View.Models.Entities;

namespace View.Views.TeacherWindows;

/// <summary>
///     Interaction logic for TeacherMainWindow.xaml
/// </summary>
public partial class TeacherMainWindow : Window
{
    public TeacherMainWindow(Teacher teacher)
    {
        InitializeComponent();

        Teacher = teacher;

        TeacherLabel.Content = $"Welcome, {Teacher.FirstName} {Teacher.LastName}";
    }

    public static Teacher Teacher { get; set; }

    private void AbsenceButton_Click(object sender, RoutedEventArgs e)
    {
        new AbsenceCRUDWindow().Show();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
        // d. Calcularea mediilor – doar la interventia profesorului (Atentie la materiile care au si teza!)
        // Media nu poate fi incheiata decat daca sunt cel putin 3 note si teza trecute.
        // (Se va sti dinainte care materie are teza si care nu are.
        // Atentie!
        // Acest lucru se va specifica atunci cand se va face cuplajul dintre materie si clasa pentru ca,
        // spre exemplu, Matematica are teza la clasa a 11 - a A, sectia de Mate - Info,
        // iar la clasa a 11 - a B nu are teza pt ca e sectie Stiinte - Sociale).
        // O nota nu va mai putea fi anulata dupa ce a fost incheiata media. 

        new AverageCRUDWindow().Show();
    }

    private void GradeButton_Click(object sender, RoutedEventArgs e)
    {
        new GradeCRUDWindow().Show();
    }
}