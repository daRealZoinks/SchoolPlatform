using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.TeacherWindows;
using View.Views.TeacherWindows.GradeCommandWindows;

namespace View.ViewModels.Commands.TeacherCommands;

public class TeacherGradeCommands
{
    public TeacherGradeCommands()
    {
        var gradeCollectionService = App.Current.Services.GetService<IGradeCollectionService>();

        Grades = new ObservableCollection<Grade>();

        Refresh();

        if (gradeCollectionService == null) return;

        InsertGradeCommand = new RelayCommand(() =>
        {
            GradeInsertWindow gradeInsertWindow = new();
            gradeInsertWindow.Show();

            gradeInsertWindow.OnGradeInserted += grade =>
            {
                gradeCollectionService.Insert(grade);
                Refresh();
                MessageBox.Show("Grade added");
            };
        });

        DeleteGradeCommand = new RelayCommand<Grade>(selectedGrade =>
        {
            if (selectedGrade == null)
            {
                MessageBox.Show("You need to select a grade first");
                return;
            }

            gradeCollectionService.Delete(selectedGrade);
            Refresh();
            MessageBox.Show("Grade deleted");
        });

        UpdateGradeCommand = new RelayCommand<Grade>(selectedGrade =>
        {
            if (selectedGrade == null)
            {
                MessageBox.Show("You need to select a grade first");
                return;
            }

            GradeUpdateWindow gradeUpdateWindow = new(selectedGrade);
            gradeUpdateWindow.Show();

            gradeUpdateWindow.OnGradeUpdated += grade =>
            {
                gradeCollectionService.Update(grade);
                Refresh();
                MessageBox.Show("Grade updated");
            };
        });
    }

    public ObservableCollection<Grade> Grades { get; }

    public IRelayCommand? InsertGradeCommand { get; }
    public IRelayCommand? DeleteGradeCommand { get; }
    public IRelayCommand? UpdateGradeCommand { get; }

    private void Refresh()
    {
        Grades.Clear();

        foreach (var grade in TeacherMainWindow.Teacher.SubjectClasses.SelectMany(subjectClass =>
                     subjectClass.Subject.Grades))
            Grades.Add(grade);
    }
}