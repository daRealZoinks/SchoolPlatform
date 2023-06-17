using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.SubjectCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

internal class AdministratorSubjectCommands
{
    private readonly ISubjectCollectionService? _subjectCollectionService;

    public AdministratorSubjectCommands()
    {
        _subjectCollectionService = App.Current.Services.GetService<ISubjectCollectionService>();

        Subjects = new ObservableCollection<Subject>();

        Refresh();

        if (_subjectCollectionService == null) return;

        InsertSubjectCommand = new RelayCommand(() =>
        {
            SubjectInsertWindow subjectInsertWindow = new();
            subjectInsertWindow.Show();
            subjectInsertWindow.OnSubjectInserted += subject =>
            {
                _subjectCollectionService.Insert(subject);
                Refresh();
                MessageBox.Show("Subject added");
            };
        });

        DeleteSubjectCommand = new RelayCommand<Subject>(selectedSubject =>
        {
            if (selectedSubject == null)
            {
                MessageBox.Show("You need to select a subject first");
                return;
            }

            _subjectCollectionService.Delete(selectedSubject);
            Refresh();
            MessageBox.Show("Subject deleted");
        });

        UpdateSubjectCommand = new RelayCommand<Subject>(selectedSubject =>
        {
            if (selectedSubject == null)
            {
                MessageBox.Show("You need to select a subject first");
                return;
            }

            SubjectUpdateWindow subjectUpdateWindow = new(selectedSubject);
            subjectUpdateWindow.Show();
            subjectUpdateWindow.OnSubjectUpdated += teacher =>
            {
                _subjectCollectionService.Update(teacher);
                Refresh();
                MessageBox.Show("Subject updated");
            };
        });
    }

    public ObservableCollection<Subject> Subjects { get; }

    public IRelayCommand? InsertSubjectCommand { get; }
    public IRelayCommand? DeleteSubjectCommand { get; }
    public IRelayCommand? UpdateSubjectCommand { get; }

    private void Refresh()
    {
        if (_subjectCollectionService == null) return;

        Subjects.Clear();

        foreach (var subject in _subjectCollectionService!.GetAll()) Subjects.Add(subject);
    }
}