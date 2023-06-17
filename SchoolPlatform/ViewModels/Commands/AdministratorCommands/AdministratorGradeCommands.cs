using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.GradeCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorGradeCommands
{
    private readonly IGradeCollectionService? _gradeCollectionService;

    public AdministratorGradeCommands()
    {
        _gradeCollectionService = App.Current.Services.GetService<IGradeCollectionService>();

        Grades = new ObservableCollection<Grade>();

        Refresh();

        if (_gradeCollectionService == null) return;

        InsertGradeCommand = new RelayCommand(() =>
        {
            GradeInsertWindow gradeInsertWindow = new();
            gradeInsertWindow.Show();

            gradeInsertWindow.OnGradeInserted += grade =>
            {
                _gradeCollectionService.Insert(grade);
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

            _gradeCollectionService.Delete(selectedGrade);
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
                _gradeCollectionService.Update(grade);
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
        if (_gradeCollectionService == null) return;

        Grades.Clear();

        foreach (var grade in _gradeCollectionService.GetAll()) Grades.Add(grade);
    }
}