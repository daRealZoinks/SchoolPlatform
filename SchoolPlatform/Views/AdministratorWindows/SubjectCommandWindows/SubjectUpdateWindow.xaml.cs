using System;
using System.Windows;
using View.Models.Entities;

namespace View.Views.AdministratorWindows.SubjectCommandWindows;

/// <summary>
///     Interaction logic for SubjectUpdateWindow.xaml
/// </summary>
public partial class SubjectUpdateWindow : Window
{
    private readonly Subject _subject;

    public SubjectUpdateWindow(Subject selectedSubject)
    {
        InitializeComponent();

        _subject = selectedSubject;
        NameTextBox.Text = selectedSubject.Name;
    }

    public Action<Subject>? OnSubjectUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Name can't be empty");
            return;
        }

        _subject.Name = NameTextBox.Text;

        OnSubjectUpdated?.Invoke(_subject);
    }
}