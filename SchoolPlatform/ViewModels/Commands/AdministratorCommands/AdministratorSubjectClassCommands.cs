using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.SubjectClassCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorSubjectClassCommands
{
    private readonly ISubjectClassCollectionService? _subjectClassCollectionService;

    public AdministratorSubjectClassCommands()
    {
        _subjectClassCollectionService = App.Current.Services.GetService<ISubjectClassCollectionService>();

        SubjectClasses = new ObservableCollection<SubjectClass>();

        Refresh();

        if (_subjectClassCollectionService == null) return;

        InsertSubjectClassCommand = new RelayCommand(() =>
        {
            SubjectClassInsertWindow subjectClassInsertWindow = new();
            subjectClassInsertWindow.Show();

            subjectClassInsertWindow.OnSubjectClassInserted += subjectClass =>
            {
                _subjectClassCollectionService.Insert(subjectClass);
                Refresh();
                MessageBox.Show("SubjectClass added");
            };
        });

        DeleteSubjectClassCommand = new RelayCommand<SubjectClass>(selectedSubjectClass =>
        {
            if (selectedSubjectClass == null)
            {
                MessageBox.Show("You need to select a subject class first");
                return;
            }

            _subjectClassCollectionService.Delete(selectedSubjectClass);
            Refresh();
            MessageBox.Show("SubjectClass deleted");
        });

        UpdateSubjectClassCommand = new RelayCommand<SubjectClass>(selectedSubjectClass =>
        {
            if (selectedSubjectClass == null)
            {
                MessageBox.Show("You need to select a subject class first");
                return;
            }

            SubjectClassUpdateWindow subjectClassUpdateWindow = new(selectedSubjectClass);
            subjectClassUpdateWindow.Show();

            subjectClassUpdateWindow.OnSubjectClassUpdated += subjectClass =>
            {
                _subjectClassCollectionService.Update(subjectClass);
                Refresh();
                MessageBox.Show("SubjectClass updated");
            };
        });
    }

    public ObservableCollection<SubjectClass> SubjectClasses { get; }

    public IRelayCommand? InsertSubjectClassCommand { get; }
    public IRelayCommand? DeleteSubjectClassCommand { get; }
    public IRelayCommand? UpdateSubjectClassCommand { get; }

    private void Refresh()
    {
        if (_subjectClassCollectionService == null) return;

        SubjectClasses.Clear();

        foreach (var subjectClass in _subjectClassCollectionService.GetAll()) SubjectClasses.Add(subjectClass);
    }
}